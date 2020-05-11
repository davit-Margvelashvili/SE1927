using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        private static void Main()
        {
            string[] data = File.ReadAllLines(@"..\..\vehicles.csv");

            // data-ში მოთავსებულია მანქანების შესახებ მონაცემები ტექსტების სახით თქვენი მიზანია ეს მონაცემები აქციოთ ობიექტებად რომელსაც
            // დაამუშავებთ.

            /*
             * 1. იპივეთ ყველა BMW
             * 2. დაალაგეთ მანქანები წვის მიხედვით
             * 3. იპოვეთ 10 ყველაზე ეკონომიური მანქანა
             *
             *
             */

            Console.ReadLine();
        }
    }
}