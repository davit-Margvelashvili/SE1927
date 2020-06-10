using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace Events
{
    /// <summary>
    /// Publisher - არის ტიპი ვინც გამოსცემს ინფორამაციას.  აქვს ივენთი (ტექნიკურად ეს არის დელეგატი)
    /// </summary>
    public class Thermometer
    {
        public string Location { get; }

        private double _temperature;

        public Thermometer(string location)
        {
            Location = location;
        }

        /// <summary>
        /// ივენთი - event - არის კლასის შიგნით არსებული დელეგატი რომელსაც იყენებ შეტყობინებების დასაგზავნად
        /// </summary>
        public event EventHandler<double> TemperatureChanged;

        public double Temperature
        {
            get => _temperature;
            set
            {
                if (value != _temperature)
                {
                    _temperature = value;

                    TemperatureChanged?.Invoke(this, _temperature); // ინვეთის გამოცემა (აღძვრა)
                }
            }
        }
    }

    /// <summary>
    /// Subscriber - არის ტიპი ვისაც აინტერესებს ინფორამაცია. ამას აქვს მეთოდი (ფუნქცია) რომელსაც უმატებს Publisher-ის ივენთს (დელეგატს)
    /// </summary>
    public class MinTemperatureDisplay
    {
        public double Temperature { get; private set; }
        private bool _isFirstTime = true;

        /// <summary>
        /// ივენთის ჰენდლერი - Event Handler
        /// </summary>
        /// <param name="newTemperature">ივენთის არგუმენტი - event arg</param>
        public void OnTemperatureChanged(object sender, double newTemperature)
        {
            if (sender is Thermometer thermometer)
            {
                if (_isFirstTime)
                {
                    Temperature = newTemperature;
                    _isFirstTime = false;
                }
                else if (newTemperature < Temperature)
                {
                    Temperature = newTemperature;
                }
                Console.WriteLine($"{thermometer.Location}: Min Temperature: {Temperature}");
            }
        }
    }

    public class MaxTemperatureDisplay
    {
        public double Temperature { get; private set; }
        private bool _isFirstTime = true;

        public void OnTemperatureChanged(object sender, double newTemperature)
        {
            if (sender is Thermometer thermometer)
            {
                if (_isFirstTime)
                {
                    Temperature = newTemperature;
                    _isFirstTime = false;
                }
                else if (newTemperature > Temperature)
                {
                    Temperature = newTemperature;
                }
                Console.WriteLine($"{thermometer.Location}: Max Temperature: {Temperature}");
            }
        }
    }

    public class AverageTemperatureDisplay
    {
        private double _temperatureSum = 0;
        private int _temperatureCount = 0;

        public double Temperature { get; private set; }

        public void OnTemperatureChanged(object sender, double newTemperature)
        {
            if (sender is Thermometer thermometer)
            {
                _temperatureSum += newTemperature;
                _temperatureCount++;

                Temperature = Math.Round(_temperatureSum / _temperatureCount, 2);
                Console.WriteLine($"{thermometer.Location}: Average Temperature: {Temperature}");
            }
        }
    }

    public class CurrentTemperatureDisplay
    {
        public double Temperature { get; private set; }

        public void OnTemperatureChanged(object sender, double newTemperature)
        {
            if (sender is Thermometer thermometer)
            {
                Temperature = newTemperature;
                Console.WriteLine($"{thermometer.Location}: Current Temperature: {Temperature}");
            }
        }
    }

    internal class Program
    {
        private static void Main()
        {
            var thermometer1 = new Thermometer("Bedroom");
            var thermometer2 = new Thermometer("Living room");

            var bedroomMinDisplay = new MinTemperatureDisplay();
            var bedroomMaxDisplay = new MaxTemperatureDisplay();
            var bedroomAverageDisplay = new AverageTemperatureDisplay();
            var bedroomCurrentDisplay = new CurrentTemperatureDisplay();

            var livingRoomMinDisplay = new MinTemperatureDisplay();
            var livingRoomMaxDisplay = new MaxTemperatureDisplay();
            var livingRoomAverageDisplay = new AverageTemperatureDisplay();
            var livingRoomCurrentDisplay = new CurrentTemperatureDisplay();

            thermometer1.TemperatureChanged += bedroomMinDisplay.OnTemperatureChanged;
            thermometer1.TemperatureChanged += bedroomMaxDisplay.OnTemperatureChanged;
            thermometer1.TemperatureChanged += bedroomAverageDisplay.OnTemperatureChanged;
            thermometer1.TemperatureChanged += bedroomCurrentDisplay.OnTemperatureChanged; // მიანიჭებს და ძველ მონაცემებს დაკარგავს

            thermometer2.TemperatureChanged += livingRoomMinDisplay.OnTemperatureChanged;
            thermometer2.TemperatureChanged += livingRoomMaxDisplay.OnTemperatureChanged;
            thermometer2.TemperatureChanged += livingRoomAverageDisplay.OnTemperatureChanged;
            thermometer2.TemperatureChanged += livingRoomCurrentDisplay.OnTemperatureChanged;

            var random = new Random();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                thermometer1.Temperature = random.Next(5, 20);
                Console.WriteLine("---------------------------------------");
                thermometer2.Temperature = random.Next(10, 30);
                Console.WriteLine("---------------------------------------");

                Thread.Sleep(2000);
            }

            Console.ReadLine();
        }

        public static void MyMethod()
        {
            Action<double> action;
        }
    }
}