using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using LINQ.Tests;

namespace XML
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var vehicles = File.ReadAllLines(@"..\..\..\Vehicles.csv")
                 .Skip(1)
                 .Where(s => !string.IsNullOrWhiteSpace(s))
                 .Select(Vehicle.Parse)
                 .ToList();

            CreateXDocWithElements(vehicles);

            CreateXDocWithAttributes(vehicles);

            Console.ReadLine();
        }

        private static void CreateXDocWithAttributes(List<Vehicle> vehicles)
        {
            var rootElementWithAttributes = new XElement("Cars", vehicles.Select(v =>
                new XElement("Car",
                    new XAttribute(nameof(v.Make), v.Make),
                    new XAttribute(nameof(v.Model), v.Model),
                    new XAttribute(nameof(v.Cylinders), v.Cylinders),
                    new XAttribute(nameof(v.Engine), v.Engine),
                    new XAttribute(nameof(v.Drive), v.Drive),
                    new XAttribute(nameof(v.Transmission), v.Transmission),
                    new XElement("Consumption",
                        new XAttribute("City", v.CityMpg),
                        new XAttribute("Combined", v.CombinedMpg),
                        new XAttribute("Highway", v.HighwayMpg)))));

            var xDoc = new XDocument(rootElementWithAttributes);
            xDoc.Save(new FileStream("vehiclesWithAttributes.xml", FileMode.OpenOrCreate));
        }

        private static void CreateXDocWithElements(List<Vehicle> vehicles)
        {
            var rootElementWithElements = new XElement("Cars", vehicles.Select(v =>
                new XElement("Car",
                    new XElement(nameof(v.Make), v.Make),
                    new XElement(nameof(v.Model), v.Model),
                    new XElement(nameof(v.Cylinders), v.Cylinders),
                    new XElement(nameof(v.Engine), v.Engine),
                    new XElement(nameof(v.Drive), v.Drive),
                    new XElement(nameof(v.Transmission), v.Transmission),
                    new XElement("City", v.CityMpg),
                    new XElement("Combined", v.CombinedMpg),
                    new XElement("Highway", v.HighwayMpg))));

            var xDoc = new XDocument(rootElementWithElements);

            xDoc.Save(new FileStream("vehiclesWithElements.xml", FileMode.OpenOrCreate));
        }
    }
}