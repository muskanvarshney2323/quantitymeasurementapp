using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Views
{
    public class Menu
    {
        private readonly QuantityMeasurementService _service;

        public Menu()
        {
            _service = new QuantityMeasurementService();
        }

        public void Display()
        {
            Console.WriteLine("=== Quantity Measurement Application ===");
            Console.WriteLine("Feet, Inch and Quantity Equality Check\n");

            ShowStaticExamples();

            while (true)
            {
                ShowOptions();
                string? choice = Console.ReadLine();

                if (choice == "4" || choice?.ToLower() == "exit")
                    break;

                ProcessChoice(choice);
            }

            Console.WriteLine("\nThank you for using Quantity Measurement Application!");
        }

        private void ShowStaticExamples()
        {
            Console.WriteLine("--- Sample Comparisons ---");
            Console.WriteLine(
                $"Feet: 1.0 ft vs 1.0 ft -> Equal? {QuantityMeasurementService.AreFeetEqual(1.0, 1.0)}"
            );
            Console.WriteLine(
                $"Feet: 1.0 ft vs 2.0 ft -> Equal? {QuantityMeasurementService.AreFeetEqual(1.0, 2.0)}"
            );
            Console.WriteLine(
                $"Inch: 1.0 in vs 1.0 in -> Equal? {QuantityMeasurementService.AreInchEqual(1.0, 1.0)}"
            );
            Console.WriteLine(
                $"Inch: 1.0 in vs 2.0 in -> Equal? {QuantityMeasurementService.AreInchEqual(1.0, 2.0)}"
            );
            Console.WriteLine(
                $"Quantity: 1.0 ft vs 12.0 in -> Equal? {_service.AreQuantitiesEqual(1.0, LengthUnit.FEET, 12.0, LengthUnit.INCH)}\n"
            );
        }

        private void ShowOptions()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Compare Feet");
            Console.WriteLine("2. Compare Inches");
            Console.WriteLine("3. Compare Quantities");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
        }

        private void ProcessChoice(string? choice)
        {
            switch (choice)
            {
                case "1":
                    CompareFeet();
                    break;

                case "2":
                    CompareInches();
                    break;

                case "3":
                    CompareQuantities();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }

        private void CompareFeet()
        {
            Console.WriteLine("\n--- Feet Comparison ---");

            string? firstInput = ReadInput("Enter first value in feet: ");
            string? secondInput = ReadInput("Enter second value in feet: ");

            Feet? firstFeet = _service.ParseFeetInput(firstInput);
            Feet? secondFeet = _service.ParseFeetInput(secondInput);

            if (firstFeet == null || secondFeet == null)
            {
                Console.WriteLine("Invalid numeric input.\n");
                return;
            }

            bool result = _service.CompareFeetEquality(firstFeet, secondFeet);

            Console.WriteLine($"\nFirst  : {firstFeet}");
            Console.WriteLine($"Second : {secondFeet}");
            Console.WriteLine($"Result : {(result ? "Equal" : "Not Equal")}\n");
        }

        private void CompareInches()
        {
            Console.WriteLine("\n--- Inch Comparison ---");

            string? firstInput = ReadInput("Enter first value in inches: ");
            string? secondInput = ReadInput("Enter second value in inches: ");

            Inch? firstInch = _service.ParseInchInput(firstInput);
            Inch? secondInch = _service.ParseInchInput(secondInput);

            if (firstInch == null || secondInch == null)
            {
                Console.WriteLine("Invalid numeric input.\n");
                return;
            }

            bool result = _service.CompareInchEquality(firstInch, secondInch);

            Console.WriteLine($"\nFirst  : {firstInch}");
            Console.WriteLine($"Second : {secondInch}");
            Console.WriteLine($"Result : {(result ? "Equal" : "Not Equal")}\n");
        }

        private void CompareQuantities()
        {
            Console.WriteLine("\n--- Quantity Comparison ---");

            string? firstValueInput = ReadInput("Enter first value: ");
            LengthUnit firstUnit = ReadUnit("Select first unit (FEET / INCH / YARD / CENTIMETER): ");

            string? secondValueInput = ReadInput("Enter second value: ");
            LengthUnit secondUnit = ReadUnit("Select second unit (FEET / INCH / YARD / CENTIMETER): ");

            Quantity? firstQuantity = _service.ParseQuantityInput(firstValueInput, firstUnit);
            Quantity? secondQuantity = _service.ParseQuantityInput(secondValueInput, secondUnit);

            if (firstQuantity == null || secondQuantity == null)
            {
                Console.WriteLine("Invalid numeric input.\n");
                return;
            }

            bool result = _service.CompareQuantityEquality(firstQuantity, secondQuantity);

            Console.WriteLine($"\nFirst  : {firstQuantity}");
            Console.WriteLine($"Second : {secondQuantity}");
            Console.WriteLine($"Result : {(result ? "Equal" : "Not Equal")}\n");
        }

        private LengthUnit ReadUnit(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (Enum.TryParse(input, true, out LengthUnit unit))
                    return unit;

                Console.WriteLine("Invalid unit. Please enter FEET, INCH, YARD, or CENTIMETER.");
            }
        }

        private string? ReadInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}