using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Xunit;
using Xunit.Abstractions;

namespace LINQ.Tests
{
    public class LinqTests
    {
        public ITestOutputHelper Output { get; }
        private const string DataPath = @"..\..\..\vehicles.csv";
        public string[] RawData { get; }
        public List<Vehicle> Vehicles { get; }

        public LinqTests(ITestOutputHelper output)
        {
            Output = output;
            RawData = File.ReadAllLines(DataPath);

            Vehicles = RawData
               .Skip(1)
               .Where(s => !string.IsNullOrWhiteSpace(s))
               .Select(Vehicle.Parse)
               .ToList();
        }

        [Fact]
        public void SelectVehiclesFromStringArray()
        {
            Assert.NotEmpty(Vehicles);
        }

        [Fact]
        public void FilterMercedesFromVehicles()
        {
            var mercedes = Vehicles
                .Where(v => v.Make.Contains("mercedes", StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            var allAreMercedes = mercedes.All(v => v.Make.Contains("mercedes", StringComparison.InvariantCultureIgnoreCase));

            Assert.True(allAreMercedes);
        }

        [Fact]
        public void OrderVehiclesByNameThanByConsumption()
        {
            var orderedVehicles = Vehicles
                .Distinct(new GenericEqualityComparer<Vehicle>((v1, v2) => v1.Make == v2.Make && v1.Model == v2.Model))
                .OrderBy(v => v.Make.ToLower())
                .ThenBy(v => v.Model.ToLower())
                .ThenByDescending(v => v.CombinedMpg)
                .ToList();
        }

        [Fact]
        public void FindMinConsumption()
        {
            var minConsumption = Vehicles.Min(v => v.CombinedKml);

            Assert.Equal(4.06f, minConsumption);
        }

        [Fact]
        public void FindVehicleObjectWithMinConsumption()
        {
            var vehicle = Vehicles.Aggregate((min, current) => min.CombinedKml < current.CombinedKml ? min : current);

            Assert.Equal(4.06f, vehicle.CombinedKml);
        }

        [Fact]
        public void GroupVehiclesByMake()
        {
            var vehicleGroups = Vehicles
                .Distinct(new GenericEqualityComparer<Vehicle>((v1, v2) => v1.Make == v2.Make && v1.Model == v2.Model))
                .OrderBy(v => v.Make)
                .ThenBy(v => v.Model)
                .ThenByDescending(v => v.CombinedMpg)
                .GroupBy(v => v.Make);

            foreach (var group in vehicleGroups)
            {
                Output.WriteLine($"გჯუფი: {group.Key}");
                Output.WriteLine("---------------------------------------------");
                foreach (var vehicle in group)
                {
                    Output.WriteLine($"\t\t {vehicle}");
                }
            }
        }
    }
}