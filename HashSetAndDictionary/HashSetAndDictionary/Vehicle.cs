using System;

namespace HashSetAndDictionary
{
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
}