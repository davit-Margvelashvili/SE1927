using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace ReflectionApp
{
    internal class Program
    {
        private static void Main()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            Generator.GenerateFlatClasses(executingAssembly);

            //Type[] assemblyTypes = executingAssembly.GetTypes();

            //foreach (var type in assemblyTypes)
            //{
            //    Console.WriteLine(type.Name);

            //    Console.WriteLine("------------------------------");
            //}

            //var className = ReadLine("Enter Class Name you want to create");
            //Type selectedType = assemblyTypes.First(t => t.Name == className);
            //object instance = Activator.CreateInstance(selectedType);

            //PropertyInfo[] properties = selectedType.GetProperties();
            //InitializeProperties(properties, instance);

            //MethodInfo[] methods = selectedType.GetMethods();
            //PrintMethods(methods);

            //string methodName = ReadLine("Enter method name you want to call");
            //MethodInfo method = methods.First(m => m.Name == methodName);
            //method.Invoke(instance, null);

            Console.ReadLine();
        }

        private static void InitializeProperties(PropertyInfo[] properties, object obj)
        {
            foreach (var property in properties)
            {
                Console.Write($"{property.PropertyType.Name} {property.Name}: ");
                string valueString = Console.ReadLine();
                object value = Convert.ChangeType(valueString, property.PropertyType);
                property.SetValue(obj, value);
            }
        }

        private static string ReadLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private static void PrintProperties(PropertyInfo[] properties)
        {
            Console.WriteLine("----- Properties ------------");
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.PropertyType.Name} {property.Name}");
            }
        }

        private static void PrintMethods(MethodInfo[] methods)
        {
            Console.WriteLine("------ Methods -----------");
            foreach (var method in methods.Where(m => !m.IsSpecialName))
            {
                Console.WriteLine($"{method.ReturnType} {method.Name} ()");
            }
        }
    }
}