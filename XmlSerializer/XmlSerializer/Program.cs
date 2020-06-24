using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace XmlSerializer
{
    internal class Program
    {
        private static void Main()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Gia",
                    LastName = "Bagashvili",
                    Email = "Gia@gmail.com",
                    Gender = "Male",
                    Account = new Account
                    {
                        Id = 1,
                        Balance = 1024m,
                        Currency = "GEL",
                        Iban = "GB3129832183913289381283"
                    }
                },
                new Employee {Id = 2, FirstName = "Jemal", LastName = "Bagashvili", Email = "Jemal@gmail.com", Gender = "Male"},
            };

            var element = XmlSerializer.Serialize(employees);

            Console.ReadLine();
        }

        private static void ShowValidationResults(IEnumerable<ValidationResult> results)
        {
            foreach (var result in results)
            {
                if (!string.IsNullOrEmpty(result.ErrorMessage))
                {
                    var defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{result.MemberNames.First()} {result.ErrorMessage}");
                    Console.ForegroundColor = defaultColor;
                }
            }
        }

        public static IEnumerable<ValidationResult> Validate<T>(T obj)
        {
            var type = obj.GetType();
            var propertiesWithMaxLength = type
                .GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(MaxLengthAttribute), false).Any());

            foreach (var property in propertiesWithMaxLength)
            {
                var attr = property.GetCustomAttribute<MaxLengthAttribute>();

                if (property.GetValue(obj) is string prop && prop.Length > attr.Length)
                    yield return new ValidationResult($"Max length must be {attr.Length}", new[] { property.Name });
            }

            var propertiesWithRange = type
                .GetProperties()
                .Where(p => p.GetCustomAttributes<RangeAttribute>(false).Any());

            foreach (var property in propertiesWithRange)
            {
                var attr = property.GetCustomAttribute<RangeAttribute>();

                if (property.GetValue(obj) is int prop && attr.Minimum is int min && attr.Maximum is int max)
                {
                    if (prop < min || prop > max)
                    {
                        yield return new ValidationResult($"Value must be in range [{min},{max}]", new[] { property.Name });
                    }
                }
            }
        }
    }
}