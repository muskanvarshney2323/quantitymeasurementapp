using System;
using QuantityMeasurementApp.Enums;
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

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n=== Quantity Measurement Application ===");
                Console.WriteLine("1. Compare Length");
                Console.WriteLine("2. Convert Length");
                Console.WriteLine("3. Add Length");
                Console.WriteLine("4. Compare Weight");
                Console.WriteLine("5. Convert Weight");
                Console.WriteLine("6. Add Weight");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CompareLength();
                        break;
                    case "2":
                        ConvertLength();
                        break;
                    case "3":
                        AddLength();
                        break;
                    case "4":
                        CompareWeight();
                        break;
                    case "5":
                        ConvertWeight();
                        break;
                    case "6":
                        AddWeight();
                        break;
                    case "0":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void CompareLength()
        {
            Console.Write("Enter first length value: ");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter first length unit (FEET, INCH, YARD, CENTIMETER): ");
            LengthUnit unit1 = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            Console.Write("Enter second length value: ");
            double value2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second length unit (FEET, INCH, YARD, CENTIMETER): ");
            LengthUnit unit2 = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            Quantity<LengthUnit> first = new Quantity<LengthUnit>(value1, unit1);
            Quantity<LengthUnit> second = new Quantity<LengthUnit>(value2, unit2);

            bool result = _service.AreEqual(first, second);

            Console.WriteLine($"Are equal: {result}");
        }

        private void ConvertLength()
        {
            Console.Write("Enter length value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter current length unit (FEET, INCH, YARD, CENTIMETER): ");
            LengthUnit fromUnit = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            Console.Write("Enter target length unit (FEET, INCH, YARD, CENTIMETER): ");
            LengthUnit targetUnit = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            Quantity<LengthUnit> quantity = new Quantity<LengthUnit>(value, fromUnit);
            Quantity<LengthUnit> result = _service.Convert(quantity, targetUnit);

            Console.WriteLine($"Converted result: {result}");
        }

        private void AddLength()
        {
            Console.Write("Enter first length value: ");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter first length unit (FEET, INCH, YARD, CENTIMETER): ");
            LengthUnit unit1 = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            Console.Write("Enter second length value: ");
            double value2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second length unit (FEET, INCH, YARD, CENTIMETER): ");
            LengthUnit unit2 = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            Console.Write("Enter target length unit (FEET, INCH, YARD, CENTIMETER): ");
            LengthUnit targetUnit = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            Quantity<LengthUnit> first = new Quantity<LengthUnit>(value1, unit1);
            Quantity<LengthUnit> second = new Quantity<LengthUnit>(value2, unit2);

            Quantity<LengthUnit> result = _service.Add(first, second, targetUnit);

            Console.WriteLine($"Addition result: {result}");
        }

        private void CompareWeight()
        {
            Console.Write("Enter first weight value: ");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter first weight unit (GRAM, KILOGRAM, TONNE): ");
            WeightUnit unit1 = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            Console.Write("Enter second weight value: ");
            double value2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second weight unit (GRAM, KILOGRAM, TONNE): ");
            WeightUnit unit2 = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            Quantity<WeightUnit> first = new Quantity<WeightUnit>(value1, unit1);
            Quantity<WeightUnit> second = new Quantity<WeightUnit>(value2, unit2);

            bool result = _service.AreEqual(first, second);

            Console.WriteLine($"Are equal: {result}");
        }

        private void ConvertWeight()
        {
            Console.Write("Enter weight value: ");
            double value = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter current weight unit (GRAM, KILOGRAM, TONNE): ");
            WeightUnit fromUnit = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            Console.Write("Enter target weight unit (GRAM, KILOGRAM, TONNE): ");
            WeightUnit targetUnit = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            Quantity<WeightUnit> quantity = new Quantity<WeightUnit>(value, fromUnit);
            Quantity<WeightUnit> result = _service.Convert(quantity, targetUnit);

            Console.WriteLine($"Converted result: {result}");
        }

        private void AddWeight()
        {
            Console.Write("Enter first weight value: ");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter first weight unit (GRAM, KILOGRAM, TONNE): ");
            WeightUnit unit1 = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            Console.Write("Enter second weight value: ");
            double value2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second weight unit (GRAM, KILOGRAM, TONNE): ");
            WeightUnit unit2 = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            Console.Write("Enter target weight unit (GRAM, KILOGRAM, TONNE): ");
            WeightUnit targetUnit = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            Quantity<WeightUnit> first = new Quantity<WeightUnit>(value1, unit1);
            Quantity<WeightUnit> second = new Quantity<WeightUnit>(value2, unit2);

            Quantity<WeightUnit> result = _service.Add(first, second, targetUnit);

            Console.WriteLine($"Addition result: {result}");
        }
    }
}