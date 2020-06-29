using System;

namespace ABedirUniversity.CSharp.DataModels
{
    public class Term
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}