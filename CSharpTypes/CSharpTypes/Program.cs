using System;
using System.Collections.Specialized;

// https://www.tutorialsteacher.com/csharp/csharp-data-types   --- C#-ის ტიპები

namespace CSharpTypes
{
    internal class Program
    {
        private static void Main()
        {
            string choice;

            do
            {
                Console.Write("Enter Number: ");
                int number1 = int.Parse(Console.ReadLine());

                Console.Write("Enter Number: ");
                int number2 = int.Parse(Console.ReadLine());

                Console.Write("Choose Operation [+,-,*,/]: ");

                string operation = Console.ReadLine();

                Console.WriteLine(true);

                if (operation == "+")
                    Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
                else if (operation == "-")
                    Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
                else if (operation == "*")
                    Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
                else if (operation == "/")
                    Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
                else
                    Console.WriteLine($"Invalid Operation '{operation}'");

                switch (operation)
                {
                    case "+":
                        Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
                        break;

                    case "-":
                        Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
                        break;

                    case "*":
                        Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
                        break;

                    case "/":
                        Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
                        break;

                    default:
                        Console.WriteLine($"Invalid Operation '{operation}'");
                        break;
                }

                Console.Write("Try again? <y/n> ");
                choice = Console.ReadLine();
            } while (choice == "y" || choice == "Y");
        }
    }
}