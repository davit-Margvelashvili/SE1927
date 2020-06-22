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

            // CreateXDocWithElements(vehicles);

            // CreateXDocWithAttributes(vehicles);

            var xDoc = XDocument.Load(new FileStream(@"..\..\..\vehiclesWithAttributes.xml", FileMode.Open));
            var bmws = ReadXDoc(xDoc);

            Console.ReadLine();
        }

        private static List<Vehicle> ReadXDoc(XDocument xDoc)
        {
            return xDoc
                .Root
                .Descendants("Car")
                .Where(e =>
                    e.Attribute("Make").Value.Contains("BMW"))
                .Select(e => new Vehicle
                {
                    Make = e.Attribute("Make").Value,
                    Model = e.Attribute("Model").Value,
                    Transmission = e.Attribute("Transmission").Value,
                    Drive = e.Attribute("Drive").Value,
                    Engine = e.Attribute("Engine").Value.ToFloat(),
                    Cylinders = e.Attribute("Cylinders").Value.ToInt(),
                    HighwayMpg = e.Element("Consumption").Attribute("Highway").Value.ToInt(),
                    CityMpg = e.Element("Consumption").Attribute("City").Value.ToInt(),
                    CombinedMpg = e.Element("Consumption").Attribute("Combined").Value.ToInt(),
                })
                .ToList();
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
            xDoc.Save(new FileStream(@"..\..\..\vehiclesWithAttributes.xml", FileMode.OpenOrCreate));
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

            xDoc.Save(new FileStream(@"..\..\..\vehiclesWithElements.xml", FileMode.OpenOrCreate));
        }
    }

    internal static class PrimitiveExt
    {
        public static int ToInt(this string self) => int.Parse(self);

        public static double ToDouble(this string self) => double.Parse(self);

        public static float ToFloat(this string self) => float.Parse(self);

        public static decimal ToDecimal(this string self) => decimal.Parse(self);
    }
}