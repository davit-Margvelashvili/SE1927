using System;
using System.Collections.Generic;
using System.Linq;
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

        public abstract void Talk(ILogger logger);
    }

    internal class Student : Person
    {
        public double GPA { get; set; }
        public Subject Subject { get; set; }

        public override void Talk(ILogger logger)
        {
            logger.Log($"Hello, I am student {FirstName} {LastName}. I am studying {Subject.Name}");
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

        public override void Talk(ILogger logger)
        {
            logger.Log($"Hello, I am lecturer {FirstName} {LastName}. I am teaching {Subject.Name}. My salary is {Salary}");
        }
    }

    internal class Administration : Employee
    {
        public string Position { get; set; }

        public override void Talk(ILogger logger)
        {
            logger.Log($"Hello, my name is {FirstName} {LastName}. I am working on position {Position}. My salary is {Salary}");
        }
    }

    internal class Subject
    {
        public int Length { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
    }
}