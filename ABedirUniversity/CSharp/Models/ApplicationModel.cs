namespace ABedirUniversity.CSharp
{
    public class ApplicationModel
    {
        public int Id { get; set; }
        public BasicInformation BasicInfo { get; set; }
        public PersonalInformation PersonalInfo { get; set; }
        public SecurityInformation SecurityInfo { get; set; }
    }
}