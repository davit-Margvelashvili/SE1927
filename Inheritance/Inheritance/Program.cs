using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }

        public virtual string GetInfo()
        {
            return $"{{FistName: {FirstName}, LastName: {LastName}, PrivateNumber: {PrivateNumber}}}";
        }

        public abstract void Talk();
    }

    internal class Student : Person
    {
        public double GPA { get; set; }
        public Subject Subject { get; set; }

        public override void Talk()
        {
            Console.WriteLine($"Hello, I am student {FirstName} {LastName}. I am studying {Subject.Name}");
        }

        public override string GetInfo()
        {
            return $"{{FistName: {FirstName}, LastName: {LastName}, PrivateNumber: {PrivateNumber}, GPA: {GPA} }}";
        }
    }

    internal abstract class Employee : Person
    {
        public decimal Salary { get; set; }
    }

    internal class Lecturer : Employee    // Lecturer : Employee --- ლექტორი არის თანამშრომელი --- ამ მიმართებას ქვია მემკვიდრეობა
    {
        public Subject Subject { get; set; }  // ლექტორს აქვს საგანი --- ამ  მიმართებას ქვია კომპოზიცია

        public override void Talk()
        {
            Console.WriteLine($"Hello, I am lecturer {FirstName} {LastName}. I am teaching {Subject.Name}. My salary is {Salary}");
        }
    }

    internal class Administration : Employee
    {
        public string Position { get; set; }

        public override void Talk()
        {
            Console.WriteLine($"Hello, my name is {FirstName} {LastName}. I am working on position {Position}. My salary is {Salary}");
        }
    }

    internal class Subject
    {
        public int Length { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
    }

    internal class Program
    {
        private static void Main()
        {
            Lecturer lecturer = new Lecturer
            {
                FirstName = "Davit",
                LastName = "Margvelashvili",
                PrivateNumber = "010031283918",
                Salary = 1200m,
                Subject = new Subject
                {
                    Credit = 5,
                    Length = 3,
                    Name = "C#"
                }
            };

            Student student = new Student
            {
                FirstName = "David",
                LastName = "Fradkin",
                PrivateNumber = "898931211323",
                GPA = 3.8,
                Subject = new Subject
                {
                    Credit = 5,
                    Length = 3,
                    Name = "C#"
                }
            };

            Administration administration = new Administration
            {
                FirstName = "Salome",
                LastName = "Lobjanidze",
                PrivateNumber = "898931211323",
                Salary = 600m,
                Position = "Yvelaferchiki"
            };

            Greating(lecturer);
            PresentYourself(lecturer);

            Console.WriteLine("\n-----------------------------------------------\n");

            Greating(student);
            PresentYourself(student);

            Console.WriteLine("\n-----------------------------------------------\n");

            Greating(administration);
            PresentYourself(administration);

            Person person = student;
            Console.WriteLine(person.GetInfo());
            Console.WriteLine(student.GetInfo());

            Console.ReadLine();
        }

        private static void Greating(Person person)
        {
            Console.WriteLine($"Hello, {person.FirstName} {person.LastName}");
        }

        private static void PresentYourself(Person person)
        {
            Console.WriteLine("Ladies and Gentlemen now listen to one of out member...");
            person.Talk();
        }
    }
}