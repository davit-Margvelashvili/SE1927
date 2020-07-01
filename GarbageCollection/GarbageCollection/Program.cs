using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

namespace GarbageCollection
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    internal class FileDataReader : IDisposable
    {
        private Stream stream;

        public FileDataReader()
        {
            stream = new MemoryStream();
        }

        public void Method()
        {
            throw new Exception();
        }

        ~FileDataReader() // Finalizer
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
            stream?.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }

    internal class Program
    {
        private static void Main()
        {
            using (var reader = new FileDataReader()) //  Dispose გამოიძახება მეთოდის ბოლოში using ბლოკის დასრულების თანავე
            {
            }

            // using დაიყვანება ამ კონსტრუქციაზე
            var fileReader = new FileDataReader();
            try
            {
            }
            finally
            {
                fileReader.Dispose();
            }

            using var fileDataReader = new FileDataReader(); //  Dispose გამოიძახება მეთოდის ბოლოში

            if (Console.ReadLine() == "gc")
            {
                Console.WriteLine("GC Called");

                GC.Collect();
            }

            Console.ReadLine();
        }
    }
}