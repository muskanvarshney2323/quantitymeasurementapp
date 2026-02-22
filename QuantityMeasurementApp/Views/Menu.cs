using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Views
{
    // Handles all console-based interactions with the user
    // Responsible for menu display, input collection, and output presentation
    public class Menu
    {
        // Service object used for measurement operations
        private readonly QuantityMeasurementService _measurementService;

        // Initializes required service dependencies
        public Menu()
        {
            _measurementService = new QuantityMeasurementService();
        }

        // Entry point for displaying the menu and managing flow
        public void Display()
        {
            Console.WriteLine("=== Quantity Measurement Application ===");
            Console.WriteLine("UC1 & UC2: Feet and Inch Equality Check\n");

            // Show predefined comparison examples
            DisplayStaticComparisons();

            // Keep running until user chooses to exit
            while (true)
            {
                PrintMainOptions();
                string? userChoice = Console.ReadLine();

                if (userChoice == "3" || userChoice?.ToLower() == "exit")
                    break;

                HandleUserSelection(userChoice);
            }

            Console.WriteLine("\nThank you for using the Quantity Measurement Application!");
        }

        // Displays static comparison outputs
        private void DisplayStaticComparisons()
        {
            Console.WriteLine("--- Static Comparison Samples ---");

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
                $"Inch: 1.0 in vs 2.0 in -> Equal? {QuantityMeasurementService.AreInchEqual(1.0, 2.0)}\n"
            );
        }

        // Prints the main menu choices
        private void PrintMainOptions()
        {
            Console.WriteLine("Select measurement type:");
            Console.WriteLine("1. Compare Feet");
            Console.WriteLine("2. Compare Inches");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your option (1-3): ");
        }

        // Routes user choice to the correct screen
        private void HandleUserSelection(string? choice)
        {
            switch (choice)
            {
                case "1":
                    HandleFeetComparison();
                    break;

                case "2":
                    HandleInchComparison();
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again.\n");
                    break;
            }
        }

        // Handles feet comparison workflow
        private void HandleFeetComparison()
        {
            Console.WriteLine("\n--- Feet Comparison ---");

            string? firstInput = ReadInput("Enter first value in feet:");
            string? secondInput = ReadInput("Enter second value in feet:");

            Feet? firstFeet = _measurementService.ParseFeetInput(firstInput);
            Feet? secondFeet = _measurementService.ParseFeetInput(secondInput);

            if (firstFeet == null || secondFeet == null)
            {
                DisplayError("Invalid input detected. Please enter numeric values only.");
                return;
            }

            bool result = _measurementService.CompareFeetEquality(firstFeet, secondFeet);
            DisplayResult(firstFeet.ToString(), secondFeet.ToString(), result);
        }

        // Handles inch comparison workflow
        private void HandleInchComparison()
        {
            Console.WriteLine("\n--- Inch Comparison ---");

            string? firstInput = ReadInput("Enter first value in inches:");
            string? secondInput = ReadInput("Enter second value in inches:");

            Inch? firstInch = _measurementService.ParseInchInput(firstInput);
            Inch? secondInch = _measurementService.ParseInchInput(secondInput);

            if (firstInch == null || secondInch == null)
            {
                DisplayError("Invalid input detected. Please enter numeric values only.");
                return;
            }

            bool result = _measurementService.CompareInchEquality(firstInch, secondInch);
            DisplayResult(firstInch.ToString(), secondInch.ToString(), result);
        }

        // Reads user input after showing a prompt
        private string? ReadInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        // Displays comparison outcome
        private void DisplayResult(string first, string second, bool isEqual)
        {
            Console.WriteLine($"\nFirst measurement : {first}");
            Console.WriteLine($"Second measurement: {second}");
            Console.WriteLine($"Result            : {(isEqual ? "Equal" : "Not Equal")}\n");
            Console.WriteLine("----------------------------------------\n");
        }

        // Displays error message
        private void DisplayError(string message)
        {
            Console.WriteLine($"{message}\n");
        }
    }
}