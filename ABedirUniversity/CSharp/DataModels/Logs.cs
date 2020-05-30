using System;

namespace ABedirUniversity.CSharp.DataModels
{
    public class Logs
    {
        public string ErrorMessage { get; set; }
        public string ErrorLocation { get; set; }
        public string UserIpAddress { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}