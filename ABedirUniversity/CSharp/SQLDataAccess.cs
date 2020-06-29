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
        public static List<StudentApplicationListItem> SearchApplicationsByName(string query)
        {
            try
            {
                string command = "SELECT sa.ID, sa.ApplicationStatus, pi.FirstName, pi.LastName, si.UserCreateDate " +
                    "FROM (((StudentApplication sa " +
                    "JOIN Student st ON sa.StudentID = st.ID) " +
                    "JOIN PersonalInformation pi ON st.PersonalInfoID = pi.ID) " +
                    "JOIN SecurityInformation si ON st.SecurityInfoID = si.ID) " +
                    "WHERE pi.FirstName LIKE '%"+ query + "%' OR pi.LastName LIKE '%" + query + "%'";
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
        public static List<Class> GetTermClasses(int termId)
        {
            try
            {
                string command = "SELECT Class.ID, Class.Name, Class.Description FROM Class " +
                    "JOIN TermClasses tc ON tc.ClassID = Class.ID WHERE tc.TermID = " + termId;

                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<Class>(command);

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetStudentTerms");
                return null;
            }
        }
        public static List<Class> GetClassAssignments(int classId)
        {
            try
            {
                string command = "SELECT Assignment.ID, Assignment.Name, Assignment.Type, Assignment.Description FROM Assignment " +
                    "JOIN ClassAssignments ca ON ca.AssignmentID = Assignment.ID WHERE ca.ClassID = " + classId;

                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<Class>(command);

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetClassAssignments");
                return null;
            }
        }
        public static List<Term> GetStudentTerms(int studentId)
        {
            try
            {
                string command = "SELECT Term.ID, Term.Name, Term.StartDate, Term.EndDate FROM Term " +
                    "JOIN StudentTerms st ON st.TermID = Term.ID WHERE st.StudentID = " + studentId;
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<Term>(command);

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetStudentTerms");
                return null;
            }
        }
        public static List<Term> GetTermDetails(int termId)
        {
            try
            {
                string command = "SELECT * FROM Term WHERE ID = " + termId;
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<Term>(command);

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetApplicationDetails");
                return null;
            }
        }
        public static List<Class> GetClassDetails(int classId)
        {
            try
            {
                string command = "SELECT * FROM Class WHERE ID = @classId";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<Class>(command, new { classId });

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetClassDetails");
                return null;
            }
        }
        public static List<Class> GetAssignmentDetails(int assignmentId)
        {
            try
            {
                string command = "SELECT * FROM Assignment WHERE ID = @assignmentId";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    var output = cnn.Query<Class>(command, new { assignmentId });

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetAssignmentDetails");
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
        public static int GetStudentIDFromUsername(string userName)
        {
            int studentId = -1;
            try
            {
                string command = "SELECT Student.ID FROM Student " +
                    "JOIN SecurityInformation si ON " +
                    "Student.SecurityInfoID = si.ID and " +
                    "si.Username = '" + userName + "' and " +
                    "UserType = 'student'";
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    studentId = cnn.Query<int>(command).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "GetStudentIDFromUsername");
            }
            return studentId;
        }
        public static void InsertStudentTerm(int studentId, int termId)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string command = @"
                        INSERT INTO StudentTerms(StudentID, TermID)
                        VALUES("+ studentId + ", "+ termId + ")";

                    cnn.Execute(command);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertStudentTerm");
            }
        }
        public static void AddClassToTerm(int termId, int classId)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string command = @"
                        INSERT INTO TermClasses(TermID, ClassID)
                        VALUES(" + termId + ", " + classId + ")";

                    cnn.Execute(command);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "AddClassToTerm");
            }
        }
        public static void AddAssignmentToClass(int classId, int assignmentId)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string command = @"
                        INSERT INTO ClassAssignments(ClassID, AssignmentID)
                        VALUES(" + classId + ", " + assignmentId + ")";

                    cnn.Execute(command);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "AddAssignmentToClass");
            }
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
                        VALUES(@StudentID, @ApplicationStatus, @SubmitDateTime);
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
        public static int InsertAssignment(Assignment assignmentToInsert)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO Assignment(Name, Type, Description)
                        VALUES(@Name, @Type, @Description);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, assignmentToInsert).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertAssignment");
                return rowID;
            }
            return rowID;
        }
        public static int InsertTerm(Term termToInsert)
        {
            int rowID = -1;
            try
            {
                using (IDbConnection cnn = new SqlConnection(dbConnectionString))
                {
                    string sql = @"
                        INSERT INTO Term(Name, StartDate, EndDate)
                        VALUES(@Name, @StartDate, @EndDate);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    rowID = cnn.Query<int>(sql, termToInsert).Single();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "InsertTerm");
                return rowID;
            }
            return rowID;
        }
        public static bool DeleteTerm(string termId)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(dbConnectionString))
                {
                    string sqlDeleteCommand = "DELETE FROM Term WHERE ID = " + termId + "; " +
                        "DELETE FROM StudentTerms WHERE TermID = " + termId + "; ";
                    connection.Execute(sqlDeleteCommand);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "DeleteTerm");
                return false;
            }
            return true;
        }
        public static bool RemoveClassFromTerm(string classId)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(dbConnectionString))
                {
                    string sqlDeleteCommand = "DELETE FROM TermClasses WHERE classId = " + classId;
                    connection.Execute(sqlDeleteCommand);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "RemoveClassFromTerm");
                return false;
            }
            return true;
        }
        public static bool DeleteAssignment(string assignmentId)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(dbConnectionString))
                {
                    string sqlDeleteCommand = "DELETE FROM Assignment WHERE ID = " + assignmentId + "; " +
                        "DELETE FROM ClassAssignments WHERE AssignmentID = " + assignmentId + ";";
                    connection.Execute(sqlDeleteCommand);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "DeleteAssignment");
                return false;
            }
            return true;
        }
        public static bool DeleteClass(string classId)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(dbConnectionString))
                {
                    string sqlDeleteCommand = "DELETE FROM Class WHERE Id = " + classId;
                    connection.Execute(sqlDeleteCommand);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString(), "DeleteClass");
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