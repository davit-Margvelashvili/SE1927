using System.ComponentModel.DataAnnotations;

namespace XmlSerializer
{
    public class Student
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [Range(16, 60)]
        public int Age { get; set; }
    }
}