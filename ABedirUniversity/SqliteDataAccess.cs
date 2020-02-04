using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace ABedirUniversity
{
    public class SqliteDataAccess
    {
        public static List<StudentApplicationModel> LoadApplications()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StudentApplicationModel>("select * from StudentApplications", new DynamicParameters());
                return output.ToList();
            }
        }
        public static bool SaveApplication(StudentApplicationModel application)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    string sqlInsertCommand = "INSERT INTO StudentApplications(FirstName, LastName, Username, Password, Email, PhoneNumber, Address1, Address2, City, State, Zip)" +
                                              "VALUES(@FirstName, @LastName, @Username, @Password, @Email, @PhoneNumber, @Address1, @Address2, @City, @State, @Zip)";
                    cnn.Execute(sqlInsertCommand, application);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private static string LoadConnectionString(string id = "Default")
        {
            ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[id];
            string fixedConnectionString = c.ConnectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            return fixedConnectionString;
        }
    }
}