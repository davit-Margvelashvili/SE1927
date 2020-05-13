using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal abstract class Logger
    {
        public abstract void Log(string message);
    }

    internal interface ILogger
    {
        void Log(string message);
    }

    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    internal class FileLogger : ILogger
    {
        private readonly string _fileName;

        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }

        public void Log(string message)
        {
            File.AppendAllLines(_fileName, new[] { message });
        }
    }

    internal class UniversalLogger : ILogger
    {
        private readonly FileLogger _fileLogger;
        private readonly ConsoleLogger _consoleLogger;

        public UniversalLogger(string fileName)
        {
            _fileLogger = new FileLogger(fileName);
            _consoleLogger = new ConsoleLogger();
        }

        public void Log(string message)
        {
            _consoleLogger.Log(message);
            _fileLogger.Log(message);
        }
    }

    internal class Program
    {
        private static void Main()
        {
            ILogger logger = new UniversalLogger("UniversalLoggerLog.txt");

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

            logger.Log("lecturer object created");

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

            logger.Log("student object created");

            Administration administration = new Administration
            {
                FirstName = "Salome",
                LastName = "Lobjanidze",
                PrivateNumber = "898931211323",
                Salary = 600m,
                Position = "Yvelaferchiki"
            };

            logger.Log("administrator object created");

            Greating(lecturer, logger);
            PresentYourself(lecturer, logger);

            logger.Log("\n-----------------------------------------------\n");

            Greating(student, logger);
            PresentYourself(student, logger);

            logger.Log("\n-----------------------------------------------\n");

            Greating(administration, logger);
            PresentYourself(administration, logger);

            // S.O.L.I.D

            // Single Responsibility +

            // Open-Close

            // Liskov Substitution

            // Interface Segregation

            // Dependency Inversion +

            // Dependency Inversion --- იყავი დამოკიდებული აბსტრაქტულ ტიპზე, არ იყო დამოკიდებული კონკრეტულ ტიპზე

            //  Dependency Inversion გვაძლევს Dependency Injection-ის საშუალებას.

            Person person = student;
            logger.Log(person.GetInfo());
            logger.Log(student.GetInfo());

            Console.ReadLine();
        }

        private static void Greating(Person person, ILogger logger)
        {
            logger.Log($"Hello, {person.FirstName} {person.LastName}");
        }

        private static void PresentYourself(Person person, ILogger logger)
        {
            logger.Log("Ladies and Gentlemen now listen to one of out member...");
            person.Talk(logger);
        }
    }
}