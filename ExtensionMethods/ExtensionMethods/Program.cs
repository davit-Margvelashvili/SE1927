using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text.Json;

namespace ExtensionMethods
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return this.ToJson();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var numbersArray = new[] { 10, 20, 30, 17, 50 };
            var numbersList = new List<int> { 10, 20, 30, 17, 50 };

            var numbers = Algorithms.Select(Algorithms.Where(numbersList, n => n % 2 == 0), n => n / 2);

            numbers = numbersList
                .Where(n => n % 2 == 0)
                .Select(n => n / 2);

            var manager = new Employee
            {
                FirstName = "Zura",
                LastName = "Kusrashvili",
                PrivateNumber = "01002080567",
                Salary = 5500.60m
            };

            // JSON = JavaScript Object Notation

            // FirstName,LastName,PrivateNumber,Salary
            // "Zura","Kusrashvili","01002080567",5500.60m
            // "Davit","Margvelashvili","01002080567",5500.60m

            //var managerAsJson = JsonSerializer.Serialize(manager);
            //var zura = JsonSerializer.Deserialize<Employee>(managerAsJson);

            var zura = manager.DeepCopy();

            manager.Salary *= 11;

            var employees = new List<Employee>
            {
                manager,
                new Employee
                {
                    FirstName = "Davit",
                    LastName = "Margvelashvili",
                    PrivateNumber = "01002080567",
                    Salary = 5500.60m
                }
            };

            var employeesCopy = new List<Employee>(employees); // Shallow Copy

            employeesCopy.Add(new Employee
            {
                FirstName = "saxeli",
                LastName = "gvariashvili",
                Salary = -900,
                PrivateNumber = "0000000001"
            });

            var emp = employeesCopy[1];
            emp.Salary *= 11;

            var employeesDeepCopy = employees.DeepCopy();

            employeesDeepCopy[1].Salary *= 2000;

            Console.WriteLine(employees.ToJson(true));

            Console.WriteLine(manager.ToJson());

            Console.WriteLine(numbersList.ToJson());

            Console.ReadLine();
        }
    }

    internal static class ObjectExtensions
    {
        public static string ToJson(this object self, bool writeIndented = false) =>
            JsonSerializer.Serialize(self, new JsonSerializerOptions { WriteIndented = writeIndented });

        public static T DeepCopy<T>(this T self)
        {
            var jsonText = JsonSerializer.Serialize(self);
            return JsonSerializer.Deserialize<T>(jsonText);
        }
    }

    internal static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string self) => string.IsNullOrWhiteSpace(self);
    }

    internal static class Algorithms
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            var result = new List<TResult>();
            foreach (var item in source)
            {
                result.Add(selector(item));
            }

            return result;
        }
    }
}