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
                System.Console.WriteLine("\n=== Quantity Measurement Menu ===");
                System.Console.WriteLine("1. Length");
                System.Console.WriteLine("2. Weight");
                System.Console.WriteLine("3. Volume");
                System.Console.WriteLine("4. Temperature");
                System.Console.WriteLine("5. Exit");

                System.Console.Write("Enter your choice: ");
                string? choice = System.Console.ReadLine();

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
                        System.Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void HandleLength()
        {
            System.Console.WriteLine("\nLength Operations:");
            System.Console.WriteLine("1. Add");
            System.Console.WriteLine("2. Subtract");
            System.Console.WriteLine("3. Divide");
            System.Console.WriteLine("4. Convert");

            System.Console.Write("Enter choice: ");
            string? choice = System.Console.ReadLine();

            System.Console.WriteLine("Length functionality already implemented.");
        }

        private void HandleWeight()
        {
            System.Console.WriteLine("\nWeight Operations:");
            System.Console.WriteLine("1. Add");
            System.Console.WriteLine("2. Subtract");
            System.Console.WriteLine("3. Divide");
            System.Console.WriteLine("4. Convert");

            System.Console.Write("Enter choice: ");
            string? choice = System.Console.ReadLine();

            System.Console.WriteLine("Weight functionality already implemented.");
        }

        private void HandleVolume()
        {
            System.Console.WriteLine("\nVolume Operations:");
            System.Console.WriteLine("1. Add");
            System.Console.WriteLine("2. Subtract");
            System.Console.WriteLine("3. Divide");
            System.Console.WriteLine("4. Convert");

            System.Console.Write("Enter choice: ");
            string? choice = System.Console.ReadLine();

            System.Console.WriteLine("Volume functionality already implemented.");
        }

        private void HandleTemperature()
        {
            System.Console.WriteLine("\nTemperature Operations:");
            System.Console.WriteLine("1. Equality Check");
            System.Console.WriteLine("2. Convert");

            System.Console.Write("Enter choice: ");
            string? choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TemperatureEquality();
                    break;
                case "2":
                    TemperatureConversion();
                    break;
                default:
                    System.Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void TemperatureEquality()
        {
            System.Console.WriteLine("\nEnter first temperature value:");
            double value1 = Convert.ToDouble(System.Console.ReadLine());

            TemperatureScale unit1 = ReadTemperatureUnit();

            System.Console.WriteLine("Enter second temperature value:");
            double value2 = Convert.ToDouble(System.Console.ReadLine());

            TemperatureScale unit2 = ReadTemperatureUnit();

            var temp1 = new Quantity<TemperatureScale>(value1, unit1);
            var temp2 = new Quantity<TemperatureScale>(value2, unit2);

            System.Console.WriteLine(temp1.Equals(temp2)
                ? "Temperatures are equal."
                : "Temperatures are NOT equal.");
        }

        private void TemperatureConversion()
        {
            System.Console.WriteLine("\nEnter temperature value:");
            double value = Convert.ToDouble(System.Console.ReadLine());

            TemperatureScale fromUnit = ReadTemperatureUnit();

            System.Console.WriteLine("Convert to:");
            TemperatureScale toUnit = ReadTemperatureUnit();

            var quantity = new Quantity<TemperatureScale>(value, fromUnit);
            var result = quantity.ConvertTo(toUnit);

            System.Console.WriteLine($"Converted Value: {result.Value} {toUnit}");
        }

        private TemperatureScale ReadTemperatureUnit()
        {
            System.Console.WriteLine("Select unit:");
            System.Console.WriteLine("1. Celsius");
            System.Console.WriteLine("2. Fahrenheit");
            System.Console.WriteLine("3. Kelvin");

            string? choice = System.Console.ReadLine();

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