using System;

namespace ABedirUniversity.CSharp
{
    public class SecurityInformation
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public string IPAddress { get; set; }
        public string Status { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime UserCreateDate { get; set; }
    }
}