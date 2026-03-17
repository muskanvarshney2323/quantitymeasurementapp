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

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("  Quantity Measurement  ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Length Operations (UC1–UC8)");
                Console.WriteLine("2. Weight Operations (UC9)");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowLengthMenu();
                        break;
                    case "2":
                        ShowWeightMenu();
                        break;
                    case "3":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ===================== LENGTH MENU =====================

        private void ShowLengthMenu()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("  Length Operations - UC8");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Compare Two Lengths");
            Console.WriteLine("2. Convert Length");
            Console.WriteLine("3. Add Two Lengths");
            Console.WriteLine("4. Add Two Lengths (Specify Target Unit)");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CompareLengths();
                    break;
                case "2":
                    ConvertLength();
                    break;
                case "3":
                    AddLengths();
                    break;
                case "4":
                    AddLengthsWithTarget();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }

        private void CompareLengths()
        {
            try
            {
                Console.WriteLine("\nEnter First Quantity:");
                double value1 = ReadDouble("Value: ");
                LengthUnit unit1 = ReadLengthUnit();

                Console.WriteLine("\nEnter Second Quantity:");
                double value2 = ReadDouble("Value: ");
                LengthUnit unit2 = ReadLengthUnit();

                bool result = _service.AreLengthsEqual(value1, unit1, value2, unit2);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"Result: {(result ? "Equal (True)" : "Not Equal (False)")}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        private void ConvertLength()
        {
            try
            {
                Console.WriteLine("\nEnter Quantity to Convert:");
                double value = ReadDouble("Value: ");
                LengthUnit sourceUnit = ReadLengthUnit();

                Console.WriteLine("\nConvert To:");
                LengthUnit targetUnit = ReadLengthUnit();

                double result = _service.ConvertLength(value, sourceUnit, targetUnit);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"{value} {sourceUnit} = {result} {targetUnit}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        private void AddLengths()
        {
            try
            {
                Console.WriteLine("\nEnter First Quantity:");
                double value1 = ReadDouble("Value: ");
                LengthUnit unit1 = ReadLengthUnit();

                Console.WriteLine("\nEnter Second Quantity:");
                double value2 = ReadDouble("Value: ");
                LengthUnit unit2 = ReadLengthUnit();

                Quantity result = _service.AddLengths(value1, unit1, value2, unit2);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"{value1} {unit1} + {value2} {unit2} = {result.Value} {result.Unit}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        private void AddLengthsWithTarget()
        {
            try
            {
                Console.WriteLine("\nEnter First Quantity:");
                double value1 = ReadDouble("Value: ");
                LengthUnit unit1 = ReadLengthUnit();

                Console.WriteLine("\nEnter Second Quantity:");
                double value2 = ReadDouble("Value: ");
                LengthUnit unit2 = ReadLengthUnit();

                Console.WriteLine("\nSelect Target Unit:");
                LengthUnit targetUnit = ReadLengthUnit();

                Quantity result = _service.AddLengths(value1, unit1, value2, unit2, targetUnit);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"{value1} {unit1} + {value2} {unit2} = {result.Value} {result.Unit}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        // ===================== WEIGHT MENU =====================

        private void ShowWeightMenu()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("  Weight Operations - UC9");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Compare Two Weights");
            Console.WriteLine("2. Convert Weight");
            Console.WriteLine("3. Add Two Weights");
            Console.WriteLine("4. Add Two Weights (Specify Target Unit)");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CompareWeights();
                    break;
                case "2":
                    ConvertWeight();
                    break;
                case "3":
                    AddWeights();
                    break;
                case "4":
                    AddWeightsWithTarget();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }

        private void CompareWeights()
        {
            try
            {
                Console.WriteLine("\nEnter First Quantity:");
                double value1 = ReadDouble("Value: ");
                WeightUnit unit1 = ReadWeightUnit();

                Console.WriteLine("\nEnter Second Quantity:");
                double value2 = ReadDouble("Value: ");
                WeightUnit unit2 = ReadWeightUnit();

                bool result = _service.AreWeightsEqual(value1, unit1, value2, unit2);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"Result: {(result ? "Equal (True)" : "Not Equal (False)")}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        private void ConvertWeight()
        {
            try
            {
                Console.WriteLine("\nEnter Quantity to Convert:");
                double value = ReadDouble("Value: ");
                WeightUnit sourceUnit = ReadWeightUnit();

                Console.WriteLine("\nConvert To:");
                WeightUnit targetUnit = ReadWeightUnit();

                double result = _service.ConvertWeight(value, sourceUnit, targetUnit);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"{value} {sourceUnit} = {result} {targetUnit}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        private void AddWeights()
        {
            try
            {
                Console.WriteLine("\nEnter First Quantity:");
                double value1 = ReadDouble("Value: ");
                WeightUnit unit1 = ReadWeightUnit();

                Console.WriteLine("\nEnter Second Quantity:");
                double value2 = ReadDouble("Value: ");
                WeightUnit unit2 = ReadWeightUnit();

                QuantityWeight result = _service.AddWeights(value1, unit1, value2, unit2);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"{value1} {unit1} + {value2} {unit2} = {result.Value} {result.Unit}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        private void AddWeightsWithTarget()
        {
            try
            {
                Console.WriteLine("\nEnter First Quantity:");
                double value1 = ReadDouble("Value: ");
                WeightUnit unit1 = ReadWeightUnit();

                Console.WriteLine("\nEnter Second Quantity:");
                double value2 = ReadDouble("Value: ");
                WeightUnit unit2 = ReadWeightUnit();

                Console.WriteLine("\nSelect Target Unit:");
                WeightUnit targetUnit = ReadWeightUnit();

                QuantityWeight result = _service.AddWeights(value1, unit1, value2, unit2, targetUnit);

                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"{value1} {unit1} + {value2} {unit2} = {result.Value} {result.Unit}");
                Console.WriteLine("---------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
        }

        // ===================== INPUT HELPERS =====================

        private LengthUnit ReadLengthUnit()
        {
            while (true)
            {
                Console.WriteLine("Select Unit:");
                Console.WriteLine("1. Feet");
                Console.WriteLine("2. Inch");
                Console.WriteLine("3. Yard");
                Console.WriteLine("4. Centimeter");
                Console.Write("Choice: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1": return LengthUnit.FEET;
                    case "2": return LengthUnit.INCH;
                    case "3": return LengthUnit.YARD;
                    case "4": return LengthUnit.CENTIMETER;
                    default:
                        Console.WriteLine("Invalid unit selection. Try again.");
                        break;
                }
            }
        }

        private WeightUnit ReadWeightUnit()
        {
            while (true)
            {
                Console.WriteLine("Select Unit:");
                Console.WriteLine("1. Kilogram");
                Console.WriteLine("2. Gram");
                Console.WriteLine("3. Pound");
                Console.Write("Choice: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1": return WeightUnit.KILOGRAM;
                    case "2": return WeightUnit.GRAM;
                    case "3": return WeightUnit.POUND;
                    default:
                        Console.WriteLine("Invalid unit selection. Try again.");
                        break;
                }
            }
        }

        private double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;

                Console.WriteLine("Invalid number. Please try again.");
            }
        }

        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}