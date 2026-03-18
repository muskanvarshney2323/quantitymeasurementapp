using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Views
{
    public class Menu
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n=== Quantity Measurement Menu ===");
                Console.WriteLine("1. Length");
                Console.WriteLine("2. Weight");
                Console.WriteLine("3. Volume");
                Console.WriteLine("4. Temperature");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        HandleLength();
                        break;
                    case "2":
                        HandleWeight();
                        break;
                    case "3":
                        HandleVolume();
                        break;
                    case "4":
                        HandleTemperature();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ---------------- LENGTH ----------------
        private void HandleLength()
        {
            Console.WriteLine("\nLength Operations:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Divide");
            Console.WriteLine("4. Convert");

            Console.Write("Enter choice: ");
            string? choice = Console.ReadLine();

            // Keep your existing UC13 logic here
            Console.WriteLine("Length functionality already implemented.");
        }

        // ---------------- WEIGHT ----------------
        private void HandleWeight()
        {
            Console.WriteLine("\nWeight Operations:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Divide");
            Console.WriteLine("4. Convert");

            Console.Write("Enter choice: ");
            string? choice = Console.ReadLine();

            Console.WriteLine("Weight functionality already implemented.");
        }

        // ---------------- VOLUME ----------------
        private void HandleVolume()
        {
            Console.WriteLine("\nVolume Operations:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Divide");
            Console.WriteLine("4. Convert");

            Console.Write("Enter choice: ");
            string? choice = Console.ReadLine();

            Console.WriteLine("Volume functionality already implemented.");
        }

        // ---------------- TEMPERATURE ----------------
        private void HandleTemperature()
        {
            Console.WriteLine("\nTemperature Operations:");
            Console.WriteLine("1. Equality Check");
            Console.WriteLine("2. Convert");

            Console.Write("Enter choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TemperatureEquality();
                    break;
                case "2":
                    TemperatureConversion();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        // -------- Temperature Equality --------
        private void TemperatureEquality()
        {
            Console.WriteLine("\nEnter first temperature value:");
            double value1 = Convert.ToDouble(Console.ReadLine());

            TemperatureScale unit1 = ReadTemperatureUnit();

            Console.WriteLine("Enter second temperature value:");
            double value2 = Convert.ToDouble(Console.ReadLine());

            TemperatureScale unit2 = ReadTemperatureUnit();

            var temp1 = new Quantity<TemperatureScale>(value1, unit1);
            var temp2 = new Quantity<TemperatureScale>(value2, unit2);

            Console.WriteLine(temp1.Equals(temp2)
                ? "Temperatures are equal."
                : "Temperatures are NOT equal.");
        }

        // -------- Temperature Conversion --------
        private void TemperatureConversion()
        {
            Console.WriteLine("\nEnter temperature value:");
            double value = Convert.ToDouble(Console.ReadLine());

            TemperatureScale fromUnit = ReadTemperatureUnit();

            Console.WriteLine("Convert to:");
            TemperatureScale toUnit = ReadTemperatureUnit();

            var quantity = new Quantity<TemperatureScale>(value, fromUnit);
            var result = quantity.ConvertTo(toUnit);

            Console.WriteLine($"Converted Value: {result.Value} {toUnit}");
        }

        // -------- Helper method --------
        private TemperatureScale ReadTemperatureUnit()
        {
            Console.WriteLine("Select unit:");
            Console.WriteLine("1. Celsius");
            Console.WriteLine("2. Fahrenheit");
            Console.WriteLine("3. Kelvin");

            string? choice = Console.ReadLine();

            return choice switch
            {
                "1" => TemperatureScale.CELSIUS,
                "2" => TemperatureScale.FAHRENHEIT,
                "3" => TemperatureScale.KELVIN,
                _ => throw new ArgumentException("Invalid unit selection.")
            };
        }
    }
}