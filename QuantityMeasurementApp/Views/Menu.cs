using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Views
{
    public class Menu
    {
        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n===== Quantity Measurement Application =====");
                Console.WriteLine("1. Compare Quantities");
                Console.WriteLine("2. Convert Quantity");
                Console.WriteLine("3. Add Quantities");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CompareQuantities();
                        break;

                    case "2":
                        ConvertQuantity();
                        break;

                    case "3":
                        AddQuantities();
                        break;

                    case "4":
                        isRunning = false;
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void CompareQuantities()
        {
            Console.WriteLine("\nSelect Measurement Type:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter your choice: ");

            string? typeChoice = Console.ReadLine();

            switch (typeChoice)
            {
                case "1":
                    CompareLength();
                    break;

                case "2":
                    CompareWeight();
                    break;

                case "3":
                    CompareVolume();
                    break;

                default:
                    Console.WriteLine("Invalid measurement type.");
                    break;
            }
        }

        private void ConvertQuantity()
        {
            Console.WriteLine("\nSelect Measurement Type:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter your choice: ");

            string? typeChoice = Console.ReadLine();

            switch (typeChoice)
            {
                case "1":
                    ConvertLength();
                    break;

                case "2":
                    ConvertWeight();
                    break;

                case "3":
                    ConvertVolume();
                    break;

                default:
                    Console.WriteLine("Invalid measurement type.");
                    break;
            }
        }

        private void AddQuantities()
        {
            Console.WriteLine("\nSelect Measurement Type:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter your choice: ");

            string? typeChoice = Console.ReadLine();

            switch (typeChoice)
            {
                case "1":
                    AddLength();
                    break;

                case "2":
                    AddWeight();
                    break;

                case "3":
                    AddVolume();
                    break;

                default:
                    Console.WriteLine("Invalid measurement type.");
                    break;
            }
        }

        // ---------------- Length ----------------

        private void CompareLength()
        {
            var first = ReadLengthQuantity("first");
            var second = ReadLengthQuantity("second");

            Console.WriteLine($"\nResult: {first.Equals(second)}");
        }

        private void ConvertLength()
        {
            var quantity = ReadLengthQuantity();
            LengthUnit targetUnit = ReadLengthUnit("target");

            var result = quantity.ConvertTo(targetUnit);

            Console.WriteLine($"\nConverted Result: {result.Value} {result.Unit}");
        }

        private void AddLength()
        {
            var first = ReadLengthQuantity("first");
            var second = ReadLengthQuantity("second");

            Console.WriteLine("\nDo you want to specify target unit? (y/n)");
            string? choice = Console.ReadLine();

            if (choice?.ToLower() == "y")
            {
                LengthUnit targetUnit = ReadLengthUnit("target");
                var result = first.Add(second, targetUnit);
                Console.WriteLine($"\nAddition Result: {result.Value} {result.Unit}");
            }
            else
            {
                var result = first.Add(second);
                Console.WriteLine($"\nAddition Result: {result.Value} {result.Unit}");
            }
        }

        private Quantity<LengthUnit> ReadLengthQuantity(string label = "")
        {
            Console.WriteLine($"\nEnter {(string.IsNullOrWhiteSpace(label) ? "" : label + " ")}length value:");
            double value = ReadDouble();

            LengthUnit unit = ReadLengthUnit();
            return new Quantity<LengthUnit>(value, unit);
        }

        private LengthUnit ReadLengthUnit(string label = "")
        {
            Console.WriteLine($"\nSelect {(string.IsNullOrWhiteSpace(label) ? "" : label + " ")}length unit:");
            Console.WriteLine("1. FEET");
            Console.WriteLine("2. INCH");
            Console.WriteLine("3. YARD");
            Console.WriteLine("4. CENTIMETER");
            Console.Write("Enter your choice: ");

            string? input = Console.ReadLine();

            return input switch
            {
                "1" => LengthUnit.FEET,
                "2" => LengthUnit.INCH,
                "3" => LengthUnit.YARD,
                "4" => LengthUnit.CENTIMETER,
                _ => throw new ArgumentException("Invalid length unit choice.")
            };
        }

        // ---------------- Weight ----------------

        private void CompareWeight()
        {
            var first = ReadWeightQuantity("first");
            var second = ReadWeightQuantity("second");

            Console.WriteLine($"\nResult: {first.Equals(second)}");
        }

        private void ConvertWeight()
        {
            var quantity = ReadWeightQuantity();
            WeightUnit targetUnit = ReadWeightUnit("target");

            var result = quantity.ConvertTo(targetUnit);

            Console.WriteLine($"\nConverted Result: {result.Value} {result.Unit}");
        }

        private void AddWeight()
        {
            var first = ReadWeightQuantity("first");
            var second = ReadWeightQuantity("second");

            Console.WriteLine("\nDo you want to specify target unit? (y/n)");
            string? choice = Console.ReadLine();

            if (choice?.ToLower() == "y")
            {
                WeightUnit targetUnit = ReadWeightUnit("target");
                var result = first.Add(second, targetUnit);
                Console.WriteLine($"\nAddition Result: {result.Value} {result.Unit}");
            }
            else
            {
                var result = first.Add(second);
                Console.WriteLine($"\nAddition Result: {result.Value} {result.Unit}");
            }
        }

        private Quantity<WeightUnit> ReadWeightQuantity(string label = "")
        {
            Console.WriteLine($"\nEnter {(string.IsNullOrWhiteSpace(label) ? "" : label + " ")}weight value:");
            double value = ReadDouble();

            WeightUnit unit = ReadWeightUnit();
            return new Quantity<WeightUnit>(value, unit);
        }

        private WeightUnit ReadWeightUnit(string label = "")
        {
            Console.WriteLine($"\nSelect {(string.IsNullOrWhiteSpace(label) ? "" : label + " ")}weight unit:");
            Console.WriteLine("1. KILOGRAM");
            Console.WriteLine("2. GRAM");
            Console.Write("Enter your choice: ");

            string? input = Console.ReadLine();

            return input switch
            {
                "1" => WeightUnit.KILOGRAM,
                "2" => WeightUnit.GRAM,
                _ => throw new ArgumentException("Invalid weight unit choice.")
            };
        }

        // ---------------- Volume ----------------

        private void CompareVolume()
        {
            var first = ReadVolumeQuantity("first");
            var second = ReadVolumeQuantity("second");

            Console.WriteLine($"\nResult: {first.Equals(second)}");
        }

        private void ConvertVolume()
        {
            var quantity = ReadVolumeQuantity();
            VolumeUnit targetUnit = ReadVolumeUnit("target");

            var result = quantity.ConvertTo(targetUnit);

            Console.WriteLine($"\nConverted Result: {result.Value} {result.Unit}");
        }

        private void AddVolume()
        {
            var first = ReadVolumeQuantity("first");
            var second = ReadVolumeQuantity("second");

            Console.WriteLine("\nDo you want to specify target unit? (y/n)");
            string? choice = Console.ReadLine();

            if (choice?.ToLower() == "y")
            {
                VolumeUnit targetUnit = ReadVolumeUnit("target");
                var result = first.Add(second, targetUnit);
                Console.WriteLine($"\nAddition Result: {result.Value} {result.Unit}");
            }
            else
            {
                var result = first.Add(second);
                Console.WriteLine($"\nAddition Result: {result.Value} {result.Unit}");
            }
        }

        private Quantity<VolumeUnit> ReadVolumeQuantity(string label = "")
        {
            Console.WriteLine($"\nEnter {(string.IsNullOrWhiteSpace(label) ? "" : label + " ")}volume value:");
            double value = ReadDouble();

            VolumeUnit unit = ReadVolumeUnit();
            return new Quantity<VolumeUnit>(value, unit);
        }

        private VolumeUnit ReadVolumeUnit(string label = "")
        {
            Console.WriteLine($"\nSelect {(string.IsNullOrWhiteSpace(label) ? "" : label + " ")}volume unit:");
            Console.WriteLine("1. LITRE");
            Console.WriteLine("2. MILLILITRE");
            Console.WriteLine("3. GALLON");
            Console.Write("Enter your choice: ");

            string? input = Console.ReadLine();

            return input switch
            {
                "1" => VolumeUnit.LITRE,
                "2" => VolumeUnit.MILLILITRE,
                "3" => VolumeUnit.GALLON,
                _ => throw new ArgumentException("Invalid volume unit choice.")
            };
        }

        // ---------------- Common Helper ----------------

        private double ReadDouble()
        {
            while (true)
            {
                Console.Write("Enter value: ");
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                {
                    return value;
                }

                Console.WriteLine("Invalid number. Please enter a valid numeric value.");
            }
        }
    }
}