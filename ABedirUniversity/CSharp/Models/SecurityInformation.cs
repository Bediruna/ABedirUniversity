using System;

namespace ABedirUniversity.CSharp
{
    public class SecurityInformation
    {
        public int Id { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public string UserIpAddress { get; set; }
    }
}