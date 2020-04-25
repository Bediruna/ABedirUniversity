using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ABedirUniversity.CSharp
{
    public class Logger
    {
        readonly static string dbConnectionString = "Persist Security Info=False;server=db825511962.hosting-data.io,1433;Initial Catalog=db825511962;User ID=dbo825511962;Password=ABedirDB2020.";
        public static void LogError(string errorMessage, string errorLocation)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sqlInsertCommand = "INSERT INTO Logs(ErrorMessage, ErrorLocation, UserIpAddress, CreateDateTime)" +
                                              "VALUES(@ErrorMessage, @ErrorLocation, @UserIpAddress, @CreateDateTime)";
                    cnn.Execute(sqlInsertCommand, new { ErrorMessage = errorMessage, ErrorLocation = errorLocation, UserIpAddress = CustomUtilities.GetIPAddress(), CreateDateTime = DateTime.Now });
                }
            }
            catch { }
        }
    }
}