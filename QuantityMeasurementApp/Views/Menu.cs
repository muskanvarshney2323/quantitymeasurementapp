using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Views
{
    // This class handles all console-based interactions with the user
    // Refactored to work with the generic Quantity implementation
    public class Menu
    {
        // Service layer object for performing calculations and comparisons
        private readonly QuantityMeasurementService _service;

        // Default constructor initializes service dependency
        public Menu()
        {
            _service = new QuantityMeasurementService();
        }

        // Displays menu options and controls application flow
        public void Display()
        {
            Console.WriteLine("=== Welcome to Quantity Measurement System ===");
            Console.WriteLine("UC3: Generic Quantity Implementation using DRY Concept\n");

            // Demonstrating static comparison methods
            DisplayStaticComparisons();

            while (true)
            {
                ShowMenuOptions();
                string? userChoice = Console.ReadLine();

                if (userChoice == "4" || userChoice?.ToLower() == "exit")
                    break;

                HandleUserChoice(userChoice);
            }

            Console.WriteLine("\nApplication closed. Have a great day!");
        }

        // Shows predefined comparison examples including unit conversion
        private void DisplayStaticComparisons()
        {
            Console.WriteLine("--- Sample Static Comparisons ---");
            Console.WriteLine(
                $"Feet vs Feet: 1.0 ft & 1.0 ft => {QuantityMeasurementService.AreQuantitiesEqual(1.0, LengthUnit.FEET, 1.0, LengthUnit.FEET)}"
            );
            Console.WriteLine(
                $"Feet vs Feet: 1.0 ft & 2.0 ft => {QuantityMeasurementService.AreQuantitiesEqual(1.0, LengthUnit.FEET, 2.0, LengthUnit.FEET)}"
            );
            Console.WriteLine(
                $"Inch vs Inch: 1.0 in & 1.0 in => {QuantityMeasurementService.AreQuantitiesEqual(1.0, LengthUnit.INCH, 1.0, LengthUnit.INCH)}"
            );
            Console.WriteLine(
                $"Inch vs Inch: 1.0 in & 2.0 in => {QuantityMeasurementService.AreQuantitiesEqual(1.0, LengthUnit.INCH, 2.0, LengthUnit.INCH)}"
            );
            Console.WriteLine(
                $"Feet vs Inch: 1.0 ft & 12.0 in => {QuantityMeasurementService.AreQuantitiesEqual(1.0, LengthUnit.FEET, 12.0, LengthUnit.INCH)}"
            );
            Console.WriteLine(
                $"Inch vs Feet: 12.0 in & 1.0 ft => {QuantityMeasurementService.AreQuantitiesEqual(12.0, LengthUnit.INCH, 1.0, LengthUnit.FEET)}\n"
            );
        }

        // Displays available options to the user
        private void ShowMenuOptions()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Compare values with same unit");
            Console.WriteLine("2. Compare values with different units");
            Console.WriteLine("3. Use legacy Feet/Inch comparison");
            Console.WriteLine("4. Exit program");
            Console.Write("Your selection (1-4): ");
        }

        // Routes user input to appropriate screen
        private void HandleUserChoice(string? choice)
        {
            switch (choice)
            {
                case "1":
                    SameUnitComparison();
                    break;
                case "2":
                    CrossUnitComparison();
                    break;
                case "3":
                    LegacyComparisonMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Please try again.\n");
                    break;
            }
        }

        // Handles comparison where both values use the same unit
        private void SameUnitComparison()
        {
            Console.WriteLine("\n--- Same Unit Comparison ---");
            Console.WriteLine("Choose measurement unit:");
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inches");
            Console.Write("Selection: ");

            string? unitChoice = Console.ReadLine();
            LengthUnit unit = unitChoice == "1" ? LengthUnit.FEET : LengthUnit.INCH;
            string unitLabel = unit == LengthUnit.FEET ? "feet" : "inches";

            Console.WriteLine($"Enter first value in {unitLabel}:");
            string? firstInput = Console.ReadLine();

            Console.WriteLine($"Enter second value in {unitLabel}:");
            string? secondInput = Console.ReadLine();

            Quantity? q1 = _service.ParseQuantityInput(firstInput, unit);
            Quantity? q2 = _service.ParseQuantityInput(secondInput, unit);

            if (q1 == null || q2 == null)
            {
                DisplayError("Invalid data entered. Numbers only allowed.");
                return;
            }

            bool result = _service.CompareQuantityEquality(q1, q2);
            DisplayResult(q1.ToString(), q2.ToString(), result);
        }

        // Handles comparison between feet and inches
        private void CrossUnitComparison()
        {
            Console.WriteLine("\n--- Cross Unit Comparison ---");

            Console.WriteLine("Provide value in feet:");
            string? feetInput = Console.ReadLine();

            Console.WriteLine("Provide value in inches:");
            string? inchInput = Console.ReadLine();

            Quantity? feetQty = _service.ParseQuantityInput(feetInput, LengthUnit.FEET);
            Quantity? inchQty = _service.ParseQuantityInput(inchInput, LengthUnit.INCH);

            if (feetQty == null || inchQty == null)
            {
                DisplayError("Invalid input detected. Please enter numeric values.");
                return;
            }

            bool result = _service.CompareQuantityEquality(feetQty, inchQty);
            DisplayResult(feetQty.ToString(), inchQty.ToString(), result);
        }

        // Menu for legacy (old class-based) comparison
        private void LegacyComparisonMenu()
        {
            Console.WriteLine("\n--- Legacy Measurement Comparison ---");
            Console.WriteLine("1. Compare Feet values");
            Console.WriteLine("2. Compare Inch values");
            Console.Write("Selection: ");

            string? option = Console.ReadLine();

            if (option == "1")
                LegacyFeetComparison();
            else if (option == "2")
                LegacyInchComparison();
            else
                Console.WriteLine("Invalid selection.\n");
        }

        // Legacy feet comparison
        private void LegacyFeetComparison()
        {
            Console.WriteLine("\n--- Feet Comparison (Legacy) ---");

            string? input1 = PromptInput("Enter first feet value:");
            string? input2 = PromptInput("Enter second feet value:");

            Feet? f1 = _service.ParseFeetInput(input1);
            Feet? f2 = _service.ParseFeetInput(input2);

            if (f1 == null || f2 == null)
            {
                DisplayError("Incorrect input format.");
                return;
            }

            bool result = _service.CompareFeetEquality(f1, f2);
            DisplayResult(f1.ToString(), f2.ToString(), result);
        }

        // Legacy inch comparison
        private void LegacyInchComparison()
        {
            Console.WriteLine("\n--- Inch Comparison (Legacy) ---");

            string? input1 = PromptInput("Enter first inch value:");
            string? input2 = PromptInput("Enter second inch value:");

            Inch? i1 = _service.ParseInchInput(input1);
            Inch? i2 = _service.ParseInchInput(input2);

            if (i1 == null || i2 == null)
            {
                DisplayError("Invalid input provided.");
                return;
            }

            bool result = _service.CompareInchEquality(i1, i2);
            DisplayResult(i1.ToString(), i2.ToString(), result);
        }

        // Displays prompt and reads user input
        private string? PromptInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        // Shows comparison output
        private void DisplayResult(string first, string second, bool equal)
        {
            Console.WriteLine($"\nValue 1: {first}");
            Console.WriteLine($"Value 2: {second}");
            Console.WriteLine($"Comparison Result: {(equal ? "Equal" : "Not Equal")}\n");
            Console.WriteLine("--------------------------------------\n");
        }

        // Prints error messages
        private void DisplayError(string error)
        {
            Console.WriteLine($"{error}\n");
        }
    }
}