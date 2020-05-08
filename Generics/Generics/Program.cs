using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    internal class StudentScoreComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }

    internal class StudentNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    // დელეგატი არის ტიპი (ობიექტი) რომელსაც შეუძლია ფუნქციის დამახსოვრება
    internal delegate bool Predicate<T>(T x, T y);

    internal class Program
    {
        public static bool CompareScore(Student x, Student y)
        {
            return x.Score < y.Score;
        }

        public static bool CompareName(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name) == -1;
        }

        public static bool CompareName2(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name) == 1;
        }

        private static void Main(string[] args)
        {
            int[] intNumbers = { 1, 2, 3, 4, 5, 6 };

            double[] doubleNumbers = { 1.1, 2.2, 3.3, 4.4 };

            Student[] students =
            {
                new Student {Score = 20,  Name = "Davit"},
                new Student {Score = 10,  Name = "Gia"},
                new Student {Score = 30,  Name = "Avto"},
                new Student {Score = 15,  Name = "Malxazi"},
            };

            Sort(students, CompareName);
            Sort(students, CompareScore);
            Sort(students, CompareName2);

            Console.WriteLine(IndexOf(intNumbers, 7));

            Console.WriteLine(IndexOf(intNumbers, 4));

            Console.WriteLine(IndexOf(doubleNumbers, 2.2));

            Console.ReadLine();
        }

        private static int CompareDouble(double x, double y)
        {
            throw new NotImplementedException();
        }

        // Generic
        private static void PrintArray<T>(T[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                Console.WriteLine(collection[i]);
            }
        }

        private static int IndexOf<T>(T[] collection, T value)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        // დაწერეთ ძებნის ფუნქცია რომელიც პარამეტრად მიიღებს პრედიკატს (შერჩევის კრიტერიუმი) დაა დააბრუნებს
        // ნაპოვნი ობიექტის ინდესს

        private static void Sort<T>(T[] collection, Predicate<T> comparer/*მჭირდება ობიექტი რომელსაც შეეძლება ფუნქციის დამარხსოვრება*/)
        {
            for (int i = 0; i < collection.Length - 1; i++)
            {
                for (int j = i + 1; j < collection.Length; j++)
                {
                    if (comparer(collection[j], collection[i]))
                    {
                        T temp = collection[i];
                        collection[i] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
        }
    }
}