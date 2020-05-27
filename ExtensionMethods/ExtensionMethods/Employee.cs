namespace ExtensionMethods
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return this.ToJson();
        }
    }
}