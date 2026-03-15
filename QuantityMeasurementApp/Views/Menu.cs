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
            Console.WriteLine("=== Quantity Measurement System ===\n");

            DisplayStaticComparisons();

            while (true)
            {
                ShowOptions();
                string? choice = Console.ReadLine();
                if (choice == "4" || choice?.ToLower() == "exit") break;
                HandleChoice(choice);
            }

            Console.WriteLine("\nApplication closed!");
        }

        private void DisplayStaticComparisons()
        {
            Console.WriteLine("--- Sample Comparisons ---");
            Console.WriteLine($"1 ft = 12 in? : {QuantityMeasurementService.AreQuantitiesEqual(1, LengthUnit.FEET, 12, LengthUnit.INCH)}");
            Console.WriteLine($"2 ft = 24 in? : {QuantityMeasurementService.AreQuantitiesEqual(2, LengthUnit.FEET, 24, LengthUnit.INCH)}\n");
        }

        private void ShowOptions()
        {
            Console.WriteLine("Select option:");
            Console.WriteLine("1. Compare same unit");
            Console.WriteLine("2. Compare different units");
            Console.WriteLine("3. Legacy comparison");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");
        }

        private void HandleChoice(string? choice)
        {
            switch (choice)
            {
                case "1": CompareSameUnit(); break;
                case "2": CompareDifferentUnits(); break;
                case "3": LegacyComparison(); break;
                default: Console.WriteLine("Invalid option.\n"); break;
            }
        }

        private void CompareSameUnit()
        {
            Console.WriteLine("\n--- Same Unit Comparison ---");
            Console.WriteLine("1. Feet  2. Inch");
            string? unitChoice = Console.ReadLine();
            LengthUnit unit = unitChoice == "1" ? LengthUnit.FEET : LengthUnit.INCH;

            Console.Write($"Enter first value in {unit.GetSymbol()}: ");
            string? first = Console.ReadLine();
            Console.Write($"Enter second value in {unit.GetSymbol()}: ");
            string? second = Console.ReadLine();

            Quantity? q1 = _service.ParseQuantityInput(first, unit);
            Quantity? q2 = _service.ParseQuantityInput(second, unit);

            if (q1 == null || q2 == null) { Console.WriteLine("Invalid input.\n"); return; }

            bool result = _service.CompareQuantityEquality(q1, q2);
            Console.WriteLine($"Result: {(result ? "Equal" : "Not Equal")}\n");
        }

        private void CompareDifferentUnits()
        {
            Console.WriteLine("\n--- Cross Unit Comparison ---");
            Console.Write("Value in feet: ");
            string? feetInput = Console.ReadLine();
            Console.Write("Value in inches: ");
            string? inchInput = Console.ReadLine();

            Quantity? feetQty = _service.ParseQuantityInput(feetInput, LengthUnit.FEET);
            Quantity? inchQty = _service.ParseQuantityInput(inchInput, LengthUnit.INCH);

            if (feetQty == null || inchQty == null) { Console.WriteLine("Invalid input.\n"); return; }

            bool result = _service.CompareQuantityEquality(feetQty, inchQty);
            Console.WriteLine($"Result: {(result ? "Equal" : "Not Equal")}\n");
        }

        private void LegacyComparison()
        {
            Console.WriteLine("\n--- Legacy Comparison ---");
            Console.WriteLine("1. Feet  2. Inch");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("First feet: ");
                Quantity? f1 = _service.ParseFeetInput(Console.ReadLine());
                Console.Write("Second feet: ");
                Quantity? f2 = _service.ParseFeetInput(Console.ReadLine());
                Console.WriteLine($"Result: {(_service.CompareFeetEquality(f1, f2) ? "Equal" : "Not Equal")}\n");
            }
            else if (choice == "2")
            {
                Console.Write("First inch: ");
                Quantity? i1 = _service.ParseInchInput(Console.ReadLine());
                Console.Write("Second inch: ");
                Quantity? i2 = _service.ParseInchInput(Console.ReadLine());
                Console.WriteLine($"Result: {(_service.CompareInchEquality(i1, i2) ? "Equal" : "Not Equal")}\n");
            }
            else Console.WriteLine("Invalid option.\n");
        }
    }
}