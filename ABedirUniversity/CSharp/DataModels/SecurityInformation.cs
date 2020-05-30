using System;

namespace ABedirUniversity.CSharp.DataModels
{
    public class SecurityInformation:DataSuperClass
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public string IPAddress { get; set; }
        public string UserStatus { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime UserCreateDate { get; set; }
        public string UserType { get; set; }
    }
}