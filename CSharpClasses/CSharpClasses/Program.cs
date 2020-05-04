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
        public string _firstName;
        public string _lastName;

        /// <summary>
        /// უნდა იყოს 18-დან 65 წლის ჩათვლით
        /// </summary>
        public uint _age;

        /// <summary>
        /// უნდა იყოს 0-დან 100-ის ჩათვლით
        /// </summary>
        public byte _score;
    }

    internal class FileLogger
    {
        private string _fileName;

        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }

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

            student._firstName = "Davit";
            student._lastName = "Margvelashvili";
            student._age = 26;

            logger.Log("Student object Initialized\n");

            Console.ReadLine();
        }
    }
}