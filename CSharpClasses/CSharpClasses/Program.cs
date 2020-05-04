using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClasses
{
    internal class Student
    {
        // auto-property : ფუნქცია
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private uint _age;

        //Full Property : ფუნქცია
        public uint Age
        {
            get { return _age; }
            set
            {
                if (value >= 18 && value <= 65)
                {
                    _age = value;
                }
            }
        }

        private byte _score;

        //Full Property : ფუნქცია
        public byte Score
        {
            get { return _score; }
            set
            {
                if (value <= 100)
                {
                    _score = value;
                }
            }
        }

        // მეთოდი : ფუნქცია
        public void Talk()
        {
            Console.WriteLine($"Hello, I am {FirstName} {LastName}. I am {Age} years old.");
        }
    }

    internal class FileLogger
    {
        private string _fileName;

        // კონსტრუქტორი : ფუნქცია
        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }

        // მეთოდი : ფუნქცია
        public void Log(string message)
        {
            File.AppendAllText(_fileName, message);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            FileLogger logger = new FileLogger("4.5.2020_log.txt");

            Student student = new Student();
            logger.Log("Student object created\n");

            student.FirstName = "Davit";
            student.LastName = "Margvelashvili";
            student.Age = 26;
            student.Age = 75;

            uint studentAge = student.Age;

            Console.WriteLine(student.Age);

            student.Talk();

            logger.Log("Student object Initialized\n");

            Console.ReadLine();
        }
    }
}