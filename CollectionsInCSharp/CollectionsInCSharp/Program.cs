using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace CollectionsInCSharp
{
    internal class Program
    {
        private static void Main()
        {
            // 1. ძრავშია ჩაშენებული
            // 2. ფიქსირებული ზომა
            // 3. სპეციფიკური სინტაქსი ???

            //List<int> numbers = new List<int>{10,20, 30};

            //int[] numbers = new int[3] { 10, 20, 30 };

            //int[] numbers = new int[] { 10, 20, 30 };

            int[] numbers = { 30, 10, 30, 40, 20, 50 };

            int index = Array.IndexOf(numbers, 30);
            int lastIndex = Array.LastIndexOf(numbers, 30);

            int[] numbersCopy = new int[6];

            Array.Copy(numbers, 1, numbersCopy, 2, 3);

            //   Array.Clear(numbersCopy, 0, numbersCopy.Length);

            Array.Sort(numbers);
            Array.Reverse(numbers);
            Array.Resize(ref numbersCopy, 10);

            Random random = new Random();

            List<int> ints = new List<int>();

            Console.WriteLine($"numbersList.Capacity: {ints.Capacity}");
            Console.WriteLine($"numbersList.Count: {ints.Count}");

            for (int i = 0; i < 129; i++)
            {
                ints.Add(random.Next(10, 20));
                Console.WriteLine($"numbersList.Capacity: {ints.Capacity}");
                Console.WriteLine($"numbersList.Count: {ints.Count}");
            }

            //// არასწორია
            //for (int i = 0; i < numbersList.Capacity; i++)
            //{
            //    Console.WriteLine(numbersList[i]);
            //}

            // სწორია
            for (int i = 0; i < ints.Count; i++)
            {
                Console.WriteLine(ints[i]);
            }

            int[] numberArray = new int[10];

            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = random.Next(10, 20);
            }

            List<int> numbersList = new List<int>(100);

            for (int i = 0; i < numbersList.Capacity; i++)
            {
                numbersList.Add(random.Next(10, 20));
            }
            numbersList.Add(random.Next(10, 20));

            ////  შეცდომააა!!!!
            //for (int i = 0; i < numbersList.Count; i++)
            //{
            //    numbersList.Add(random.Next(10, 20));
            //}

            index = numbersList.IndexOf(15);
            lastIndex = numbersList.LastIndexOf(15);
            index = numbersList.LastIndexOf(150);

            //numbersList.Sort();
            //numbersList.Reverse();

            Console.WriteLine($"numbersList.Capacity: {numbersList.Capacity}");
            Console.WriteLine($"numbersList.Count: {numbersList.Count}");

            numbersList.TrimExcess();
            Console.WriteLine($"numbersList.Capacity: {numbersList.Capacity}");
            Console.WriteLine($"numbersList.Count: {numbersList.Count}");

            numbersList.Remove(15); // შლის პირველივე 15-ს
            numbersList.RemoveAt(2); // წაშლი მე-2 ინდექსზე მყოფ ობიექტს
            numbersList.RemoveRange(3, 5); // წაშლი მე-3 ინდექსიდან 5-ცალს წაშლის

            //// შეცდომააა!!!!
            //for (int i = 0; i < numbersList.Capacity; i++)
            //{
            //    numbersList[i] = random.Next(10, 20);
            //}

            Console.ReadLine();
        }
    }
}