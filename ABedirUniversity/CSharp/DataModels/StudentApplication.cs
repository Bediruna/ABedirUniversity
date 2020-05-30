using System;

namespace ABedirUniversity.CSharp.DataModels
{
    public class StudentApplication : DataSuperClass
    {
        public int StudentID{ get; set;}
        public string ApplicationStatus { get; set; }
        public DateTime SubmitDateTime { get; set; }
    }
}