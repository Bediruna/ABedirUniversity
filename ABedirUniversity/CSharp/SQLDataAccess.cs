using ABedirUniversity.CSharp.DataModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ABedirUniversity.CSharp
{
    public class SQLDataAccess
    {
        //readonly static string dbConnectionString = "Persist Security Info=False;server=db825511962.hosting-data.io,1433;Initial Catalog=db825511962;User ID=dbo825511962;Password=ABedirDB2020.";
        readonly static string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

        public static List<Class> GetClasses()
        {
            try
            {
                string command = "SELECT * FROM Class";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<Class>(command, new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetClasses");
                return null;
            }
        }
        public static List<StudentApplicationListItem> GetStudentApplications()
        {
            try
            {
                string command = "SELECT sa.ID, sa.ApplicationStatus, pi.FirstName, pi.LastName, si.UserCreateDate " +
                    "FROM (((StudentApplication sa " +
                    "JOIN Student st ON sa.StudentID = st.ID) " +
                    "JOIN PersonalInformation pi ON st.PersonalInfoID = pi.ID) " +
                    "JOIN SecurityInformation si ON st.SecurityInfoID = si.ID) " +
                    "WHERE sa.ApplicationStatus != 'Active'";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<StudentApplicationListItem>(command, new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetStudentApplications");
                return null;
            }
        }
        public static List<StudentApplicationListItem> GetActiveStudents()
        {
            try
            {
                string command = "SELECT sa.ID, sa.ApplicationStatus, pi.FirstName, pi.LastName, si.UserCreateDate " +
                    "FROM (((StudentApplication sa " +
                    "JOIN Student st ON sa.StudentID = st.ID) " +
                    "JOIN PersonalInformation pi ON st.PersonalInfoID = pi.ID) " +
                    "JOIN SecurityInformation si ON st.SecurityInfoID = si.ID) " +
                    "WHERE sa.ApplicationStatus = 'Active'";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<StudentApplicationListItem>(command, new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetStudentApplications");
                return null;
            }
        }
        public static List<StudentApplicationListItem> GetNewStudentApplications()
        {
            try
            {
                string command = "SELECT sa.ID, sa.ApplicationStatus, pi.FirstName, pi.LastName, si.UserCreateDate " +
                    "FROM (((StudentApplication sa " +
                    "JOIN Student st ON sa.StudentID = st.ID) " +
                    "JOIN PersonalInformation pi ON st.PersonalInfoID = pi.ID) " +
                    "JOIN SecurityInformation si ON st.SecurityInfoID = si.ID) " +
                    "WHERE sa.SubmitDateTime >= DATEADD(month,-1,GETDATE()) AND sa.ApplicationStatus != 'Active'";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<StudentApplicationListItem>(command, new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetApplications");
                return null;
            }
        }
        public static List<StudentApplicationDetailItem> GetApplicationDetails(int applicationId)
        {
            try
            {
                string command = "SELECT sa.ID, sa.ApplicationStatus, pi.FirstName, pi.LastName, si.UserName, pi.PhoneNumber, pi.EmailAddress, ai.Address, ai.Address2, ai.City, ai.State, ai.ZipCode, si.UserCreateDate " +
                    "FROM((((StudentApplication sa JOIN Student st ON sa.StudentID = st.ID) " +
                    "JOIN PersonalInformation pi ON st.PersonalInfoID = pi.ID) " +
                    "JOIN SecurityInformation si ON st.SecurityInfoID = si.ID) " +
                    "JOIN AddressInformation ai ON st.AddressInfoID = ai.ID) " +
                    "WHERE sa.ID = @applicationId";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<StudentApplicationDetailItem>(command, new { applicationId });

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetApplicationDetails");
                return null;
            }
        }
        public static SecurityInformation GetSecurityInfo(string userName, string userType)
        {
            SecurityInformation securityInformation = new SecurityInformation();
            try
            {
                string command = "SELECT UserStatus, HashedPassword, PasswordSalt FROM SecurityInformation WHERE Username = @Username and UserType = @UserType";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var reader = cnn.ExecuteReader(command, new { Username = userName, UserType = userType });

                    while (reader.Read())
                    {
                        securityInformation.UserStatus = reader["UserStatus"].ToString();
                        securityInformation.HashedPassword = reader["HashedPassword"].ToString();
                        securityInformation.PasswordSalt = reader["PasswordSalt"].ToString();
                    }
                    return securityInformation;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetAccountSalt");
                return null;
            }
        }
        public static string GetHashedPassword(string userName, string applicantType)
        {
            try
            {
                string command = "SELECT HashedPassword FROM StudentApplication WHERE Username = '" + userName + "' and ApplicantType = '" + applicantType + "'";
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
        public static bool IsUsernameAvailable(string userName, string userType)
        {
            try
            {
                string command = "SELECT Username FROM SecurityInformation WHERE Username = '" + userName + "' and UserType = '" + userType + "'";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.ExecuteScalar(command, new DynamicParameters());
                    return output == null;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "CheckUsernameExistance");
            }
            return false;
        }
        public static int InsertStudentApplication(StudentApplication application)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO StudentApplication(StudentID, ApplicationStatus, SubmitDateTime)
                        VALUES(@StudentID, @Status, @SubmitDateTime);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, application).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertStudentApplication");
                return rowID;
            }
            return rowID;
        }
        public static int InsertSecurityInfo(SecurityInformation securityInfo)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO SecurityInformation(Username, HashedPassword, PasswordSalt, IPAddress, UserStatus, LastLoginDate, UserCreateDate, UserType)
                        VALUES(@Username, @HashedPassword, @PasswordSalt, @IPAddress, @UserStatus, @LastLoginDate, @UserCreateDate, @UserType);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, securityInfo).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertSecurityInfo");
                return rowID;
            }
            return rowID;
        }
        public static int InsertPersonalInfo(PersonalInformation personalInfo)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO PersonalInformation(FirstName, LastName, PhoneNumber, EmailAddress)
                        VALUES(@FirstName, @LastName, @PhoneNumber, @EmailAddress);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, personalInfo).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertPersonalInfo");
                return rowID;
            }
            return rowID;
        }
        public static int InsertAddressInfo(AddressInformation addressInfo)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO AddressInformation(Address, Address2, City, State, ZipCode)
                        VALUES(@Address, @Address2, @City, @State, @ZipCode);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, addressInfo).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertAddressInfo");
                return rowID;
            }
            return rowID;
        }
        public static int InsertStudent(Student student)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO Student(SecurityInfoID, PersonalInfoID, AddressInfoID)
                        VALUES(@SecurityInfoID, @PersonalInfoID, @AddressInfoID);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, student).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertStudent");
                return rowID;
            }
            return rowID;
        }
        public static int InsertClass(Class classToInsert)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO Class(Name, Description)
                        VALUES(@Name, @Description);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, classToInsert).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertStudent");
                return rowID;
            }
            return rowID;
        }
        public static bool UpdateApplicationStatus(string applicationId, string newStatus)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(dbConnectionString))
                {
                    string sqlUpdateCommand = "UPDATE StudentApplication SET ApplicationStatus = '" + newStatus + "' WHERE Id = " + applicationId;
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
    }
}