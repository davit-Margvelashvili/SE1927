using System;
using System.Collections.Generic;

namespace ExtensionMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new List<int> { 10, 20, 30, 50 };
            var expectedNumbers = new List<int> { 1, 2, 3, 5 };

            var result = numbers.Select(n => n / 10);

            // 1. სატესტო მონაცემები

            // 2. ფუნქცია რომელსაც ვტესტავ  (ანუ რომელიც მუშაობს სატესტო მონაცემებზე)
            //   და მაძლევს რეალურ შედეგს

            // 3. მოსალოდნელი შედეგი

            // თუ მოსალოდნელი შედეგი ემთხვევა რეალურს მაშინ წარმატებულად მუშაობს ფუნქცია თუ არადა არ მუშაობს.

            Console.ReadLine();
        }
    }
}