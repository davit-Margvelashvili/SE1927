using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Mime;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

// delegate void Action();

// delegate void Action<T>(T arg);

// delegate void Action<T1, T2>(T1 arg1, T2 arg2);

// delegate void Action<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);

// delegate TResult Func<TResult>();

// delegate TResult Func<T, TResult>(T arg);

// delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);

// delegate TResult Func<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);

internal class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Cylinders { get; set; }
    public float Engine { get; set; }
    public string Drive { get; set; }
    public string Transmission { get; set; }
    public int CityMpg { get; set; }
    public int CombinedMpg { get; set; }
    public int HighwayMpg { get; set; }

    public float CityKml => ConvertMpgToKml(CityMpg);

    public float CombinedKml => ConvertMpgToKml(CombinedMpg);

    public float HighwayKml => ConvertMpgToKml(HighwayMpg);

    private static float ConvertMpgToKml(int consumption)
    {
        return (float)Math.Round(235.21f / consumption, 2);
    }

    /// <summary>
    /// Converts the string representation of a vehicle to Vehicle object
    /// </summary>
    /// <param name="s">A string containing a vehicle data to convert (make,model,cylinders,engine,drive,transmission,city,combined,highway)</param>
    /// <returns></returns>
    public static Vehicle Parse(string s)
    {
        // make,model,cylinders,engine,drive,trany,city,combined,highway
        // Alfa Romeo, Spider Veloce 2000,4,2,Rear - Wheel Drive,Manual 5 - spd,19,21,25

        string[] data = s.Split(',');

        if (data.Length != 9)
            throw new FormatException($"Invalid format string: {s}");

        int idx = 0;
        Vehicle newVehicle = new Vehicle
        {
            Make = data[idx++],
            Model = data[idx++],
            Cylinders = int.Parse(data[idx++]),
            Engine = float.Parse(data[idx++]),
            Drive = data[idx++],
            Transmission = data[idx++],
            CityMpg = int.Parse(data[idx++]),
            CombinedMpg = int.Parse(data[idx++]),
            HighwayMpg = int.Parse(data[idx]),
        };

        return newVehicle;
    }
}

namespace Generics
{
    internal class Program
    {
        private static void Main()
        {
            string[] data = File.ReadAllLines(@"..\..\vehicles.csv");

            // დავალება: რაც აქ გავაკეთეთ მასივის გამოყენებით გააკეთეთ List-ის გამოყენებით!!!!

            Vehicle[] vehicles = Array.ConvertAll(data, Vehicle.Parse);

            Vehicle[] BMWs = Array.FindAll(vehicles, v => v.Make.Contains("BMW"));

            Vehicle[] fords = Array.FindAll(vehicles, v => v.Make.Contains("Ford"));
            Vehicle[] mercedes = Array.FindAll(vehicles, v => v.Make.Contains("Mercedes"));

            // input-ში მოთავსებულია მანქანების შესახებ მონაცემები ტექსტების სახით თქვენი მიზანია ეს მონაცემები აქციოთ ობიექტებად რომელსაც
            // დაამუშავებთ.

            Array.Sort(vehicles, (x, y) => y.CombinedMpg.CompareTo(x.CombinedMpg));

            Vehicle[] mostEfficient10 = new Vehicle[10];

            Array.Copy(vehicles, mostEfficient10, mostEfficient10.Length);

            /*
             * 1. იპივეთ ყველა BMW
             * 2. დაალაგეთ მანქანები წვის მიხედვით
             * 3. იპოვეთ 10 ყველაზე ეკონომიური მანქანა
             *
             */

            Console.WriteLine();

            Vehicle car = Vehicle.Parse("Alfa Romeo,Spider Veloce 2000,4,2,Rear-Wheel Drive,Manual 5-spd,19,21,25");
            Console.WriteLine($"MPG: City {car.CityMpg}, Combined {car.CombinedMpg}, Highway {car.HighwayMpg}");
            Console.WriteLine($"Kml: City {car.CityKml}, Combined {car.CombinedKml}, Highway {car.HighwayKml}");

            Console.ReadLine();
        }

        private static int ConsumptionComparison(Vehicle x, Vehicle y)
        {
            return y.CombinedMpg.CompareTo(x.CombinedMpg);
        }

        // ზუსტად ესეთი ფუნქცია აქვს Array კლასს. Array.ConvertAll
        private static TOutput[] ConvertAll<TInput, TOutput>(TInput[] input, Func<TInput, TOutput> converter)
        {
            TOutput[] output = new TOutput[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = converter(input[i]);
            }

            return output;
        }

        private void Sort<T>(T[] collection, Func<T, T, bool> comparer)
        {
            for (int i = 0; i < collection.Length - 1; i++)
            {
                for (int j = i + 1; j < collection.Length; j++)
                {
                    if (comparer(collection[i], collection[j]))
                    {
                        // Swap
                    }
                }
            }
        }
    }
}