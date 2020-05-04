using System;
using System.Collections.Generic;
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
        public int _age;
        public int _score;
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
            // write in file;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Student student = new Student();
            student._firstName = "Davit";
            student._lastName = "Margvelashvili";
            student._age = 26;
            student._age = -26;

            FileLogger logger = new FileLogger("4/5/2020_log.txt");

            logger.Log("Student object created");
        }
    }
}