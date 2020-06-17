using System;

namespace ReflectionApp
{
    public class Teacher : Person
    {
        public string Subject { get; set; }
        public int Experience { get; set; }

        public void AboutMe()
        {
            Console.WriteLine($"Hello, I am {FirstName} {LastName} and I teach {Subject} for {Experience} year(s)");
        }
    }
}