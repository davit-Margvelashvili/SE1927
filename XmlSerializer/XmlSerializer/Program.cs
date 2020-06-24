using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace XmlSerializer
{
    public class Student
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [Range(16, 60)]
        public int Age { get; set; }
    }

    internal class Program
    {
        private static void Main()
        {
            var student = new Student
            {
                Age = 77,
                FirstName = "Zura",
                LastName = "Kusrashvili"
            };

            var crazyStudent = new Student
            {
                Age = 20,
                FirstName = "Hubert Blaine Wolfeschlegelsteinhausenbergerdorff Sr.",
                LastName = "Adolph Blaine Charles David Earl Frederick Gerald Hubert Irvin John Kenneth Lloyd Martin Nero Oliver Paul Quincy Randolph Sherman Thomas Uncas Victor William Xerxes Yancy Zeus "
            };

            var results = Validate(student);
            ShowValidationResults(results);

            var otherResult = Validate(crazyStudent);
            ShowValidationResults(otherResult);

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