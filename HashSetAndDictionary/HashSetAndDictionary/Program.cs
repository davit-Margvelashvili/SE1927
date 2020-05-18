using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace HashSetAndDictionary
{
    internal class VehicleNameEqualityComparer : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            return x.Make == y.Make;
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.Make.Length;
        }
    }

    internal class VehicleMakeAndModelEqualityComparer : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            return x.Make == y.Make && x.Model == y.Model;
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.Make.Length + obj.Model.Length;
        }
    }

    internal class Program
    {
        private static void Main()
        {
            // VehiclesHashSet();

            // NumbersHashSetManipulation();

            var numbersDictionary = new Dictionary<string, int>();

            numbersDictionary.Add("four", 4);
            //numbersDictionary.Add("four", 4); // ArgumentException ისვრის თუ Key მეორდება

            numbersDictionary.TryAdd("four", 4); // თუ დაამატა აბრუნებს True-ს თუ ვერა - False-ს

            numbersDictionary["four"] = 44;
            numbersDictionary["ოთხი"] = 4;
            numbersDictionary["ხუთი"] = 5;

            int four = numbersDictionary["four"];  // ამოიღებს და მნიშნველობას
            //int ten = numbersDictionary["ათი"]; // ვერ იპოვის და ისვრის KeyNotFoundException-ს

            if (numbersDictionary.TryGetValue("four", out four))
                Console.WriteLine(four);

            if (numbersDictionary.TryGetValue("ათი", out int ten))
                Console.WriteLine(ten);

            foreach (var key in numbersDictionary.Keys)
            {
                Debug.Write($"{key}  ");
            }

            Debug.WriteLine("");

            foreach (var value in numbersDictionary.Values)
            {
                Debug.Write($"{value}  ");
            }

            int num = 10;

            if (Vehicle.TryParse("Subaru,Loyale,4,1.8,Front-Wheel Drive,Manual 5-spd,22,25,29", out var vehicle))
                Console.WriteLine(vehicle.Make);

            if (Vehicle.TryParse("Subaru,Loyale", out vehicle))
                Console.WriteLine(vehicle.Make);

            Increment(ref num);

            // 0. დაწერეთ ლათინურად დაწერილი ქართული ტექსტის ქართულ სიმბოლოებზე გადაყვანის
            //    პროგრამა

            // 1. გაასწორეთ რომ არასწორი ბრძანების შემთხვევაში არ იქრეშებოდეს
            // 2. დაუმატეთ ბრძანებები
            while (true)
            {
                var commands = new Dictionary<string, Action>
                {
                    ["hello"] = () => Console.WriteLine("Hello, Sir..."),
                    ["what time is it?"] = () => Console.WriteLine($"It's {DateTime.Now.TimeOfDay}"),
                    ["good bye!"] = () => Console.WriteLine($"Bye, Bye..."),
                };

                var command = ReadLine("-> ");

                var action = commands[command];

                action();
            }

            Console.ReadLine();
        }

        private static string ReadLine(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private static void Increment(ref int number)
        {
            number++;
        }

        private static void VehiclesHashSet()
        {
            var data = File.ReadAllLines(@"..\..\..\Vehicles.csv");

            var vehicles = Array.ConvertAll(data, Vehicle.Parse);

            var makes = new HashSet<Vehicle>(vehicles, new VehicleNameEqualityComparer());
            var makesAndModels = new HashSet<Vehicle>(vehicles, new VehicleMakeAndModelEqualityComparer());
        }

        private static void NumbersHashSetManipulation()
        {
            var numbersSet = new HashSet<int> { 1, 2, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            if (numbersSet.Add(2))
                Console.WriteLine("Successfully Added: 2");
            else
                Console.WriteLine("Failed Adding: 2");

            if (numbersSet.Add(10))
                Console.WriteLine("Successfully Added: 10");
            else
                Console.WriteLine("Failed Adding: 10");

            var otherSet = new HashSet<int> { 1, 2, 3, 11, 12, 13 };

            //  numbersSet.UnionWith(otherSet); // AUB  იგივე	A+B-A∩B

            // numbersSet.IntersectWith(otherSet); // A∩B

            //numbersSet.ExceptWith(otherSet); //   A\B იგივე  A-B

            // numbersSet.SymmetricExceptWith(otherSet); //  AUB\A∩B

            var smallSet = new HashSet<int> { 2, 3 };
            if (smallSet.IsSubsetOf(numbersSet))
                Console.WriteLine("smallSet Is Subset Of numbersSet");

            if (smallSet.IsProperSubsetOf(numbersSet))
                Console.WriteLine("smallSet Is Proper Subset Of numbersSet");

            if (smallSet.IsSubsetOf(smallSet))
                Console.WriteLine("smallSet Is Subset Of smallSet");

            if (!smallSet.IsProperSubsetOf(smallSet))
                Console.WriteLine("smallSet Is NOT Proper Subset Of smallSet");

            if (numbersSet.IsSupersetOf(smallSet))
                Console.WriteLine("numbersSet Is Superset Of smallSet");

            if (numbersSet.IsProperSupersetOf(smallSet))
                Console.WriteLine("numbersSet Is Proper Superset Of smallSet");

            if (smallSet.IsSupersetOf(smallSet))
                Console.WriteLine("smallSet Is Superset Of smallSet");

            if (!smallSet.IsProperSupersetOf(smallSet))
                Console.WriteLine("smallSet Is NOT Proper Superset Of smallSet");

            if (numbersSet.Overlaps(otherSet))
                Console.WriteLine("numbersSet Overlaps otherSet");

            var first = new HashSet<int> { 1, 2, 3, 4 };
            var second = new HashSet<int> { 1, 4, 2, 3 };

            if (first.SetEquals(second))
                Console.WriteLine("first SetEquals second");
        }
    }
}