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

    public delegate bool Predicate<T>(T arg);

    internal delegate bool Predicate<T1, T2>(T1 x, T2 y);

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
                new Student {Score = 10,  Name = "Gia"},
                new Student {Score = 20,  Name = "Davit"},
                new Student {Score = 30,  Name = "Avto"},
                new Student {Score = 40,  Name = "Davit"},
                new Student {Score = 15,  Name = "Malxazi"},
                new Student {Score = 60,  Name = "Davit"},
            };

            string name = Console.ReadLine();

            int index = FindIndex(students, s => s.Name == name);
            index = FindIndex(students, s => s.Name == "Gio");
            index = FindIndex(students, s => s.Name.StartsWith("Gi"));

            Student student = Find(students, delegate (Student s) { return s.Name == "Davit"; });

            //Predicate<Student> del = delegate (Student s) { return s.Name == "Davit"; };
            //Predicate<Student> del =  (s) => { return s.Name == "Davit"; };
            Predicate<Student> del = s => s.Name == "Davit";

            //Sort(students, CompareName);
            //Sort(students, CompareScore);
            //Sort(students, CompareName2);

            Student firtStudent = Array.Find(students, FindByName);
            Student lastStudent = Array.FindLast(students, FindByName);
            Student[] allStudents = Array.FindAll(students, FindByName);

            int firstIndex = Array.FindIndex(students, FindByName);
            int lastIndex = Array.FindLastIndex(students, FindByName);

            Array.Sort(students, StudentCompare);

            int number = 7;
            Console.WriteLine(IndexOf(intNumbers, number));

            Console.WriteLine(IndexOf(intNumbers, 4));

            Console.WriteLine(IndexOf(doubleNumbers, 2.2));

            Console.ReadLine();
        }

        private static int StudentCompare(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name);
        }

        private static bool FindByName(Student arg)
        {
            return arg.Name == "Davit";
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
        private static int FindIndex<T>(T[] collection, Predicate<T> predicate)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (predicate(collection[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private static T Find<T>(T[] collection, Predicate<T> predicate)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (predicate(collection[i]))
                {
                    return collection[i];
                }
            }

            return default;
        }

        private static void Sort<T>(T[] collection, Predicate<T, T> comparer/*მჭირდება ობიექტი რომელსაც შეეძლება ფუნქციის დამარხსოვრება*/)
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