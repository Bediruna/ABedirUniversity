using System;

namespace ABedirUniversity.CSharp.DataModels
{
    public class StudentApplicationListItem
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime UserCreateDate { get; set; }
    }
}