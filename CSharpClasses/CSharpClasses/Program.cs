using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClasses
{
    // https://www.w3schools.com/cs/cs_properties.asp
    // https://www.c-sharpcorner.com/article/understanding-properties-in-C-Sharp/

    internal class Student
    {
        // auto-property : ფუნქცია
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private uint _age;

        //Full Property : ფუნქცია
        public uint Age
        {
            // გამოიძახება მნიშნველობის ამოღების დროს
            get { return _age; }

            // გამოიძახება მნიშნველობის მინიჭების დროს
            set
            {
                // value ინახავს იმ მნიშვნელობას რომლის მინიჭებასაც ვცდილობთ
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

    /*

    დაწერეთ ანგარიშის კლასი რომელსაც ექნება
    •	ანგარიშის ნომერი(22ნიშნა)
    •	ვალუტა(სამნიშნა)
    •	თანხა(არ უნდა იყოს უარყოფითი)

    დაწერეთ კლიენტის კლასი რომელსაც ექნება
    •	სახელი
    •	გვარი
    •	პირადი ნომერი(11 ნიშნა)
    •	ანგარიში

    მოახდინეთ თქვენ მიერ შექმნილი კლასების დემონსტრირება კონსოლში

    */

    internal class Account
    {
        private string _accountNumber;
        private string _currency;
        private decimal _balance;

        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }

            set
            {
                if (value.Length == 22 && value.StartsWith("GE"))
                    _accountNumber = value;
            }
        }

        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                if (value.Length == 3)
                    _currency = value;
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                    _balance = value;
            }
        }
    }

    internal class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string _privateNumber;

        public string PrivateNumber
        {
            get
            {
                return _privateNumber;
            }
            set
            {
                if (value.Length == 11)
                    _privateNumber = value;
            }
        }

        public Account Account { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Homework

            Account acc = new Account();
            acc.AccountNumber = "GE29TB0000000101904917";
            acc.AccountNumber = "RU29TB0000000101904917";
            acc.Balance = 50.55m;
            acc.Balance = -50.55m;
            acc.Currency = "GEL";
            acc.Currency = "GELA";

            // ობიექტის property-ებზე მნიშნველობის მინიჭების შემოკლებული ვარიანტი
            // იგივეს აკეთებს რასაც ზემოთ დაწერილი კოდი
            Account acc2 = new Account
            {
                AccountNumber = "GE29TB0000000101904917",
                Balance = 50.55m,
                Currency = "GEL"
            };

            Customer customer = new Customer();
            customer.FirstName = "Jemal";
            customer.LastName = "Bagashvili";
            customer.PrivateNumber = "01001077267";
            customer.PrivateNumber = "01001";
            customer.Account = acc;

            Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.PrivateNumber}");
            Console.WriteLine($"{customer.Account.AccountNumber} {customer.Account.Currency} {customer.Account.Balance}");

            #endregion Homework

            #region Student

            //FileLogger logger = new FileLogger("4.5.2020_log.txt");

            //Student student = new Student();
            //logger.Log("Student object created\n");

            //student.FirstName = "Davit";
            //student.LastName = "Margvelashvili";
            //student.Age = 26;
            //student.Age = 75;

            //uint studentAge = student.Age;

            //Console.WriteLine(student.Age);

            //student.Talk();

            //logger.Log("Student object Initialized\n");

            #endregion Student

            Console.ReadLine();
        }
    }
}