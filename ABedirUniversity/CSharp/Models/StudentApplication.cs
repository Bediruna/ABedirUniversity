using System;

namespace ABedirUniversity.CSharp
{
    public class StudentApplication
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public string ApplicantType { get; set; }
    }
}