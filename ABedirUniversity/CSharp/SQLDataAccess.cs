using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ABedirUniversity.CSharp
{
    public class SQLDataAccess
    {
        readonly static string dbConnectionString = "Persist Security Info=False;server=db825511962.hosting-data.io,1433;Initial Catalog=db825511962;User ID=dbo825511962;Password=ABedirDB2020.";
        public static List<BasicInformation> GetApplications()
        {
            try
            {
                string command = "SELECT Id, FirstName, LastName, CreateDate, UpdateDate, Status FROM StudentApplications";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<BasicInformation>(command, new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetApplications");
                return GetSampleApplications();
            }
        }
        public static List<StudentApplication> GetApplicationDetails(int applicationId)
        {
            try
            {
                string command = "SELECT Id, Status, FirstName, LastName, UserName, Email, PhoneNumber, Address1, Address2, City, State, ZipCode, CreateDate, UpdateDate" +
                    " FROM StudentApplications WHERE Id = " + applicationId;
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<StudentApplication>(command, new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetApplicationDetails");
                return GetSampleApplication();
            }
        }
        public static string GetAccountSalt(string userName, string applicantType)
        {
            try
            {
                string command = "SELECT PasswordSalt FROM StudentApplications WHERE UserName = '" + userName + "' and ApplicantType = '" + applicantType + "'";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.ExecuteScalar(command, new DynamicParameters());
                    return output.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetAccountSalt");
                return "";
            }
        }
        public static string GetHashedPassword(string userName, string applicantType)
        {
            try
            {
                string command = "SELECT HashedPassword FROM StudentApplications WHERE UserName = '" + userName + "' and ApplicantType = '" + applicantType + "'";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.ExecuteScalar(command, new DynamicParameters());
                    return output.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetHashedPassword");
                return "";
            }
        }
        public static bool SaveApplication(StudentApplication application)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sqlInsertCommand = "INSERT INTO StudentApplications(FirstName, LastName, UserName, HashedPassword, Email, PhoneNumber, Address1, Address2, City, State, ZipCode, Status, CreateDate, UpdateDate, PasswordSalt, ApplicantType)" +
                                              "VALUES(@FirstName, @LastName, @UserName, @HashedPassword, @Email, @PhoneNumber, @Address1, @Address2, @City, @State, @ZipCode, @Status, @CreateDate, @UpdateDate, @PasswordSalt, @ApplicantType)";
                    cnn.Execute(sqlInsertCommand, application);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "SaveApplication");
                return false;
            }
            return true;
        }
        public static bool UpdateApplicationStatus(string applicationId, string newStatus)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(dbConnectionString))
                {
                    string sqlUpdateCommand = "UPDATE StudentApplications SET Status = '" + newStatus + "' WHERE Id = " + applicationId;
                    connection.Execute(sqlUpdateCommand);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "UpdateApplicationStatus");
                return false;
            }
            return true;
        }
        #region temp sample code
        public static List<StudentApplication> GetSampleApplication()
        {
            return new List<StudentApplication>
            {
                new StudentApplication()
                {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Test",
                    UserName = "JoeUser",
                    Email = "joe@email.com",
                    PhoneNumber = "(407) 555-5555",
                    Address1 = "123 Elm St",
                    Address2 = "Apt 2",
                    City = "Elmsfield",
                    State = "Florida",
                    ZipCode = "32884",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Status = "Active"
                }
            };
        }
        public static List<BasicInformation> GetSampleApplications()
        {
            return new List<BasicInformation>
            {
                new BasicInformation()
                {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Test",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Status = "Active"
                },
                new BasicInformation()
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Status = "Active"
                },
                new BasicInformation()
                {
                    Id = 3,
                    FirstName = "Dwight",
                    LastName = "Schrute",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Status = "Active"
                },
                new BasicInformation()
                {
                    Id = 4,
                    FirstName = "Pam",
                    LastName = "Halpert",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Status = "Active"
                },
                new BasicInformation()
                {
                    Id = 5,
                    FirstName = "Jim",
                    LastName = "Halper",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Status = "Active"
                }
            };
        }
        #endregion
    }
}