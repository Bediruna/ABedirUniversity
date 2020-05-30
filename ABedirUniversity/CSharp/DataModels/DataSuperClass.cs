namespace ABedirUniversity.CSharp.DataModels
{
    public abstract class DataSuperClass
    {
        public int ID { get; set; }
        public bool IsValid { get; set; }
        public string ValidationError { get; set; } = "";
    }
}