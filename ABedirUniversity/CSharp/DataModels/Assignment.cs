namespace ABedirUniversity.CSharp.DataModels
{
    public class Assignment : DataSuperClass
    {
        public int ClassID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}