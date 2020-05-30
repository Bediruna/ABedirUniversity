using System;

namespace ABedirUniversity.CSharp.DataModels
{
    public class Term : DataSuperClass
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}