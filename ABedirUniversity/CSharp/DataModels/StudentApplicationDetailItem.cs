using System;

namespace ABedirUniversity.CSharp.DataModels
{
    public class StudentApplicationDetailItem
    {

        public int ID { get; set; }
        public string ApplicationStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime UserCreateDate { get; set; }
    }
}