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

        public static int AccrueDueSalaries()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    @"UPDATE Employees
SET TotalEarned = TotalEarned + (Salary * DATEDIFF(MINUTE, LastSalaryTime, GETDATE())),
    WorkedMinutes = WorkedMinutes + DATEDIFF(MINUTE, LastSalaryTime, GETDATE()),
    LastSalaryTime = DATEADD(MINUTE, DATEDIFF(MINUTE, LastSalaryTime, GETDATE()), LastSalaryTime)
WHERE LastSalaryTime IS NOT NULL
  AND DATEDIFF(MINUTE, LastSalaryTime, GETDATE()) >= 1",
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
        }

        public static void MarkSalaryClockNow()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            ExecuteNonQuery(
                connection,
                @"UPDATE Employees
SET LastSalaryTime = GETDATE()");
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
    }
}
