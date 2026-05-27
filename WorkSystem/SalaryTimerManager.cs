using Microsoft.Data.SqlClient;

namespace WorkSystem
{
    internal static class SalaryTimerManager
    {
        private const string ConnectionString =
            @"Server=.\SQLEXPRESS;
    Database=EmployeeDB;
    Trusted_Connection=True;
    TrustServerCertificate=True;";

        public static void EnsureDatabase()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            ExecuteNonQuery(
                connection,
                @"IF COL_LENGTH('Employees', 'WorkedMinutes') IS NULL
BEGIN
    ALTER TABLE Employees
    ADD WorkedMinutes INT NOT NULL
    CONSTRAINT DF_Employees_WorkedMinutes DEFAULT(0)
END");

            ExecuteNonQuery(
                connection,
                @"IF COL_LENGTH('Employees', 'LastSalaryTime') IS NULL
BEGIN
    ALTER TABLE Employees
    ADD LastSalaryTime DATETIME NULL
END");

            ExecuteNonQuery(
                connection,
                @"UPDATE Employees
SET LastSalaryTime = GETDATE()
WHERE LastSalaryTime IS NULL");

            ExecuteNonQuery(
                connection,
                @"IF OBJECT_ID('AppSettings', 'U') IS NULL
BEGIN
    CREATE TABLE AppSettings
    (
        SettingKey NVARCHAR(100) NOT NULL PRIMARY KEY,
        SettingValue NVARCHAR(4000) NOT NULL
    )
END");

            ExecuteNonQuery(
                connection,
                @"IF NOT EXISTS (SELECT 1 FROM AppSettings WHERE SettingKey = 'SalaryTimerRunning')
BEGIN
    INSERT INTO AppSettings (SettingKey, SettingValue)
    VALUES ('SalaryTimerRunning', '0')
END");

            ExecuteNonQuery(
                connection,
                @"IF NOT EXISTS (SELECT 1 FROM AppSettings WHERE SettingKey = 'SalaryTimerStoppedAt')
BEGIN
    INSERT INTO AppSettings (SettingKey, SettingValue)
    VALUES ('SalaryTimerStoppedAt', '')
END");
        }

        public static bool IsRunning()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"SELECT SettingValue
FROM AppSettings
WHERE SettingKey = 'SalaryTimerRunning'",
                    connection);

            object? value = cmd.ExecuteScalar();

            return value?.ToString() == "1";
        }

        public static void SetRunning(bool isRunning)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"UPDATE AppSettings
SET SettingValue = @Value
WHERE SettingKey = 'SalaryTimerRunning'",
                    connection);

            cmd.Parameters.AddWithValue("@Value", isRunning ? "1" : "0");
            cmd.ExecuteNonQuery();
        }

        public static void SaveStopTime()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"UPDATE AppSettings
SET SettingValue = CONVERT(NVARCHAR(30), GETDATE(), 126)
WHERE SettingKey = 'SalaryTimerStoppedAt'",
                    connection);

            cmd.ExecuteNonQuery();
        }

        public static void ResumeFromSavedStopTime()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"DECLARE @StoppedAt DATETIME =
    TRY_CONVERT(
        DATETIME,
        NULLIF((SELECT SettingValue FROM AppSettings WHERE SettingKey = 'SalaryTimerStoppedAt'), ''),
        126
    )

IF @StoppedAt IS NOT NULL
BEGIN
    UPDATE Employees
    SET LastSalaryTime =
        DATEADD(SECOND, CAST(DATEDIFF_BIG(SECOND, @StoppedAt, SYSDATETIME()) AS INT), LastSalaryTime)
    WHERE LastSalaryTime IS NOT NULL

    UPDATE AppSettings
    SET SettingValue = ''
    WHERE SettingKey = 'SalaryTimerStoppedAt'
END",
                    connection);

            cmd.ExecuteNonQuery();
        }

        public static int AccrueDueSalaries()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"UPDATE Employees
SET TotalEarned = TotalEarned + (Salary * Due.FullPeriods),
    WorkedMinutes = WorkedMinutes + Due.FullPeriods,
    LastSalaryTime = DATEADD(MINUTE, Due.FullPeriods, LastSalaryTime)
FROM Employees
CROSS APPLY
(
    SELECT CAST(DATEDIFF_BIG(MILLISECOND, LastSalaryTime, SYSDATETIME()) / 60000 AS INT) AS FullPeriods
) AS Due
WHERE LastSalaryTime IS NOT NULL
  AND Due.FullPeriods >= 1",
                    connection);

            return cmd.ExecuteNonQuery();
        }

        public static void Reset()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            ExecuteNonQuery(
                connection,
                @"UPDATE Employees
SET TotalEarned = 0,
    WorkedMinutes = 0,
    LastSalaryTime = GETDATE()");

            SetRunning(false);
            ClearStopTime();
        }

        public static int GetSecondsUntilNextAccrual()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"SELECT ISNULL(
    MIN(
        CASE
            WHEN DATEDIFF_BIG(MILLISECOND, LastSalaryTime, SYSDATETIME()) >= 60000 THEN 0
            ELSE CEILING((60000.0 - DATEDIFF_BIG(MILLISECOND, LastSalaryTime, SYSDATETIME())) / 1000.0)
        END
    ),
    60
)
FROM Employees
WHERE LastSalaryTime IS NOT NULL",
                    connection);

            return Math.Clamp(Convert.ToInt32(cmd.ExecuteScalar()), 0, 60);
        }

        public static int GetTotalWorkedMinutes()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"SELECT ISNULL(SUM(WorkedMinutes), 0)
FROM Employees",
                    connection);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        private static void ClearStopTime()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"UPDATE AppSettings
SET SettingValue = ''
WHERE SettingKey = 'SalaryTimerStoppedAt'",
                    connection);

            cmd.ExecuteNonQuery();
        }
    }
}
