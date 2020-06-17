using System;

namespace ReflectionApp
{
    public class Student : Person
    {
        public double Score { get; set; }

        public void Talk()
        {
            Console.WriteLine($"Hello I am {FirstName} {LastName} and I am {Age} years old. ");
        }
    }
}