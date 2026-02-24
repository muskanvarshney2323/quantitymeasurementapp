using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Views
{
    // Handles all console-based interaction with the user
    // Includes support for Feet, Inches, Yards, and Centimeters
    public class Menu
    {
        // Business logic layer
        private readonly QuantityMeasurementService _service;

        // Utility helper for unit conversions
        private readonly LengthUnitExtensions _unitHelper;

        // Initialize required services
        public Menu()
        {
            _service = new QuantityMeasurementService();
            _unitHelper = new LengthUnitExtensions();
        }

        // Entry point for displaying the menu system
        public void Display()
        {
            Console.WriteLine("=== Quantity Measurement System ===");
            Console.WriteLine("Extended Version: Yards & Centimeters Included\n");

            DisplayPredefinedExamples();

            while (true)
            {
                PrintMainOptions();

                string? input = Console.ReadLine();

                if (input == "5" || input?.ToLower() == "exit")
                    break;

                HandleMainSelection(input);
            }

            Console.WriteLine("\nApplication closed. Goodbye!");
        }

        // Shows predefined equality examples for demonstration
        private void DisplayPredefinedExamples()
        {
            Console.WriteLine("--- Sample Comparisons ---");

            Console.WriteLine($"1 ft vs 1 ft → {_service.IsQuantityEqual(1, LengthUnit.FEET, 1, LengthUnit.FEET)}");
            Console.WriteLine($"1 in vs 1 in → {_service.IsQuantityEqual(1, LengthUnit.INCH, 1, LengthUnit.INCH)}");
            Console.WriteLine($"1 yd vs 1 yd → {_service.IsQuantityEqual(1, LengthUnit.YARD, 1, LengthUnit.YARD)}");
            Console.WriteLine($"1 cm vs 1 cm → {_service.IsQuantityEqual(1, LengthUnit.CENTIMETER, 1, LengthUnit.CENTIMETER)}");

            Console.WriteLine("\n--- Mixed Unit Comparisons ---");

            Console.WriteLine($"1 yd vs 3 ft → {_service.IsQuantityEqual(1, LengthUnit.YARD, 3, LengthUnit.FEET)}");
            Console.WriteLine($"1 yd vs 36 in → {_service.IsQuantityEqual(1, LengthUnit.YARD, 36, LengthUnit.INCH)}");
            Console.WriteLine($"30.48 cm vs 1 ft → {_service.IsQuantityEqual(30.48, LengthUnit.CENTIMETER, 1, LengthUnit.FEET)}");

            Console.WriteLine("\n----------------------------------------\n");
        }

        // Prints available options
        private void PrintMainOptions()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Compare same units");
            Console.WriteLine("2. Compare different units");
            Console.WriteLine("3. Advanced unit demonstration");
            Console.WriteLine("4. Original Feet/Inch comparison");
            Console.WriteLine("5. Exit");
            Console.Write("Choice (1-5): ");
        }

        // Handles main menu selection
        private void HandleMainSelection(string? choice)
        {
            switch (choice)
            {
                case "1":
                    SameUnitScreen();
                    break;
                case "2":
                    CrossUnitScreen();
                    break;
                case "3":
                    AdvancedScreen();
                    break;
                case "4":
                    LegacyScreen();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.\n");
                    break;
            }
        }

        // Compare values using the same unit
        private void SameUnitScreen()
        {
            Console.WriteLine("\n--- Same Unit Comparison ---");
            LengthUnit unit = AskForUnit();

            Console.WriteLine($"Enter first value in {LengthUnitExtensions.GetUnitName(unit)}:");
            Quantity? q1 = _service.ConvertToQuantity(Console.ReadLine(), unit);

            Console.WriteLine($"Enter second value in {LengthUnitExtensions.GetUnitName(unit)}:");
            Quantity? q2 = _service.ConvertToQuantity(Console.ReadLine(), unit);

            if (q1 is null || q2 is null)
            {
                ShowError("Invalid numeric input.");
                return;
            }

            bool result = _service.CheckQuantityMatch(q1, q2);
            ShowResult(q1.ToString(), q2.ToString(), result);
        }

        // Compare two values with different units
        private void CrossUnitScreen()
        {
            Console.WriteLine("\n--- Cross Unit Comparison ---");

            Console.WriteLine("Select first unit:");
            LengthUnit unit1 = AskForUnit();

            Console.WriteLine("Select second unit:");
            LengthUnit unit2 = AskForUnit();

            Console.WriteLine($"Enter value in {LengthUnitExtensions.GetUnitName(unit1)}:");
            Quantity? q1 = _service.ConvertToQuantity(Console.ReadLine(), unit1);

            Console.WriteLine($"Enter value in {LengthUnitExtensions.GetUnitName(unit2)}:");
            Quantity? q2 = _service.ConvertToQuantity(Console.ReadLine(), unit2);

            if (q1 is null || q2 is null)
            {
                ShowError("Invalid numeric input.");
                return;
            }

            bool result = _service.CheckQuantityMatch(q1, q2);
            ShowResult(q1.ToString(), q2.ToString(), result);

            ExplainConversion(q1, q2);
        }

        // Demonstrates chained conversions
        private void AdvancedScreen()
        {
            Console.WriteLine("\n--- Advanced Demonstration ---");

            Console.WriteLine("Example: 2 yd = 6 ft = 72 in");
            Console.WriteLine($"2 yd vs 72 in → {_service.IsQuantityEqual(2, LengthUnit.YARD, 72, LengthUnit.INCH)}");

            Console.WriteLine("\nExample: 30.48 cm = 1 ft");
            Console.WriteLine($"30.48 cm vs 1 ft → {_service.IsQuantityEqual(30.48, LengthUnit.CENTIMETER, 1, LengthUnit.FEET)}");

            Console.WriteLine("\n----------------------------------------\n");
        }

        // Old implementation support
        private void LegacyScreen()
        {
            Console.WriteLine("\n--- Original Class Comparison ---");
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inches");
            Console.Write("Select option: ");

            string? input = Console.ReadLine();

            if (input == "1")
                LegacyFeet();
            else if (input == "2")
                LegacyInch();
            else
                Console.WriteLine("Invalid option.\n");
        }

        private void LegacyFeet()
        {
            Feet? f1 = _service.ConvertFeetInput(GetInput("Enter first value in feet:"));
            Feet? f2 = _service.ConvertFeetInput(GetInput("Enter second value in feet:"));

            if (f1 is null || f2 is null)
            {
                ShowError("Invalid input.");
                return;
            }

            ShowResult(f1.ToString(), f2.ToString(), _service.MatchFeetValues(f1, f2));
        }

        private void LegacyInch()
        {
            Inch? i1 = _service.ConvertInchInput(GetInput("Enter first value in inches:"));
            Inch? i2 = _service.ConvertInchInput(GetInput("Enter second value in inches:"));

            if (i1 is null || i2 is null)
            {
                ShowError("Invalid input.");
                return;
            }

            ShowResult(i1.ToString(), i2.ToString(), _service.MatchInchValues(i1, i2));
        }

        // Ask user to select unit
        private LengthUnit AskForUnit()
        {
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inches");
            Console.WriteLine("3. Yards");
            Console.WriteLine("4. Centimeters");
            Console.Write("Choice: ");

            return Console.ReadLine() switch
            {
                "1" => LengthUnit.FEET,
                "2" => LengthUnit.INCH,
                "3" => LengthUnit.YARD,
                "4" => LengthUnit.CENTIMETER,
                _ => LengthUnit.FEET
            };
        }

        private void ExplainConversion(Quantity q1, Quantity q2)
        {
            double v1 = q1.Value * _unitHelper.GetConversionFactorToFeet(q1.Unit);
            double v2 = q2.Value * _unitHelper.GetConversionFactorToFeet(q2.Unit);

            Console.WriteLine("\n--- Conversion to Feet ---");
            Console.WriteLine($"{q1} = {v1:F6} ft");
            Console.WriteLine($"{q2} = {v2:F6} ft");
            Console.WriteLine($"Difference = {Math.Abs(v1 - v2):F6} ft\n");
        }

        private string? GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private void ShowResult(string m1, string m2, bool equal)
        {
            Console.WriteLine($"\n{m1} vs {m2}");
            Console.WriteLine(equal ? "Result: Equal\n" : "Result: Not Equal\n");
        }

        private void ShowError(string message)
        {
            Console.WriteLine($"Error: {message}\n");
        }
    }
}