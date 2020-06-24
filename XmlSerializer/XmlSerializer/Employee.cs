namespace XmlSerializer
{
    [XmlObject]
    public class Employee
    {
        [XmlProperty]
        public int Id { get; set; }

        [XmlProperty]
        public string FirstName { get; set; }

        [XmlProperty]
        public string LastName { get; set; }

        [XmlProperty]
        public string Email { get; set; }

        [XmlProperty]
        public string Gender { get; set; }

        [XmlProperty]
        public Account Account { get; set; }

        public string FullName { get; set; }
    }
}