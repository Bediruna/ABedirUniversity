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
            using (IDbConnection cnn = new SqlConnection(dbConnectionString))
            {
                string sqlInsertCommand = "INSERT INTO Logs(ErrorMessage, ErrorLocation, UserIpAddress, CreateDateTime)" +
                                          "VALUES(" + errorMessage + ", " + errorLocation + ", " + CustomUtilities.GetIPAddress() + ", " + DateTime.Now + ")";
                cnn.Execute(sqlInsertCommand);
            }
            //try
            //{
            //    using (IDbConnection cnn = new SqlConnection(dbConnectionString))
            //    {
            //        string sqlInsertCommand = "INSERT INTO Logs(ErrorMessage, ErrorLocation, UserIpAddress, CreateDateTime)" +
            //                                  "VALUES("+ errorMessage + ", " + errorLocation + ", " + CustomUtilities.GetIPAddress() + ", "+ DateTime.Now +")";
            //        cnn.Execute(sqlInsertCommand);
            //    }
            //}
            //catch { }
        }
    }
}