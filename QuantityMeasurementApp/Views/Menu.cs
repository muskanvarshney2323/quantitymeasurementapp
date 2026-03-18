using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Views
{
    public class Menu
    {
        private readonly QuantityMeasurementServices<LengthUnit> lengthService;
        private readonly QuantityMeasurementServices<WeightUnit> weightService;
        private readonly QuantityMeasurementServices<VolumeUnit> volumeService;

        public Menu()
        {
            lengthService = new QuantityMeasurementServices<LengthUnit>();
            weightService = new QuantityMeasurementServices<WeightUnit>();
            volumeService = new QuantityMeasurementServices<VolumeUnit>();
        }

        public void Show()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("   QUANTITY MEASUREMENT APPLICATION");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. UC1 - UC9  : Equality / Conversion Checks");
                Console.WriteLine("2. UC10       : Addition");
                Console.WriteLine("3. UC11       : Addition with Target Unit");
                Console.WriteLine("4. UC12/UC13  : Subtraction and Division");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunUc1ToUc9();
                        break;

                    case "2":
                        RunUc10();
                        break;

                    case "3":
                        RunUc11();
                        break;

                    case "4":
                        RunUc12AndUc13();
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void RunUc1ToUc9()
        {
            Console.WriteLine("\n------ UC1 to UC9 : Equality / Conversion ------");
            Console.WriteLine("Choose category:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter choice: ");

            string? categoryChoice = Console.ReadLine();

            switch (categoryChoice)
            {
                case "1":
                    CompareLengthQuantities();
                    break;

                case "2":
                    CompareWeightQuantities();
                    break;

                case "3":
                    CompareVolumeQuantities();
                    break;

                default:
                    Console.WriteLine("Invalid category choice.");
                    break;
            }
        }

        private void RunUc10()
        {
            Console.WriteLine("\n------ UC10 : Addition ------");
            Console.WriteLine("Choose category:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter choice: ");

            string? categoryChoice = Console.ReadLine();

            switch (categoryChoice)
            {
                case "1":
                    AddLengthQuantities();
                    break;

                case "2":
                    AddWeightQuantities();
                    break;

                case "3":
                    AddVolumeQuantities();
                    break;

                default:
                    Console.WriteLine("Invalid category choice.");
                    break;
            }
        }

        private void RunUc11()
        {
            Console.WriteLine("\n------ UC11 : Addition With Target Unit ------");
            Console.WriteLine("Choose category:");
            Console.WriteLine("1. Length");
            Console.WriteLine("2. Weight");
            Console.WriteLine("3. Volume");
            Console.Write("Enter choice: ");

            string? categoryChoice = Console.ReadLine();

            switch (categoryChoice)
            {
                case "1":
                    AddLengthWithTargetUnit();
                    break;

                case "2":
                    AddWeightWithTargetUnit();
                    break;

                case "3":
                    AddVolumeWithTargetUnit();
                    break;

                default:
                    Console.WriteLine("Invalid category choice.");
                    break;
            }
        }

        private void RunUc12AndUc13()
        {
            Console.WriteLine("\n------ UC12 / UC13 : Subtraction and Division ------");
            Console.WriteLine("1. Subtract Length");
            Console.WriteLine("2. Divide Length");
            Console.WriteLine("3. Subtract Weight");
            Console.WriteLine("4. Divide Weight");
            Console.WriteLine("5. Subtract Volume");
            Console.WriteLine("6. Divide Volume");
            Console.Write("Enter choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SubtractLengthQuantities();
                    break;
                case "2":
                    DivideLengthQuantities();
                    break;
                case "3":
                    SubtractWeightQuantities();
                    break;
                case "4":
                    DivideWeightQuantities();
                    break;
                case "5":
                    SubtractVolumeQuantities();
                    break;
                case "6":
                    DivideVolumeQuantities();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void CompareLengthQuantities()
        {
            var first = ReadLengthQuantity("first");
            var second = ReadLengthQuantity("second");

            bool areEqual = lengthService.AreEqual(first, second);
            Console.WriteLine($"Result: {(areEqual ? "Equal" : "Not Equal")}");
        }

        private void CompareWeightQuantities()
        {
            var first = ReadWeightQuantity("first");
            var second = ReadWeightQuantity("second");

            bool areEqual = weightService.AreEqual(first, second);
            Console.WriteLine($"Result: {(areEqual ? "Equal" : "Not Equal")}");
        }

        private void CompareVolumeQuantities()
        {
            var first = ReadVolumeQuantity("first");
            var second = ReadVolumeQuantity("second");

            bool areEqual = volumeService.AreEqual(first, second);
            Console.WriteLine($"Result: {(areEqual ? "Equal" : "Not Equal")}");
        }

        private void AddLengthQuantities()
        {
            var first = ReadLengthQuantity("first");
            var second = ReadLengthQuantity("second");

            var result = lengthService.Add(first, second);
            Console.WriteLine($"Addition Result: {result}");
        }

        private void AddWeightQuantities()
        {
            var first = ReadWeightQuantity("first");
            var second = ReadWeightQuantity("second");

            var result = weightService.Add(first, second);
            Console.WriteLine($"Addition Result: {result}");
        }

        private void AddVolumeQuantities()
        {
            var first = ReadVolumeQuantity("first");
            var second = ReadVolumeQuantity("second");

            var result = volumeService.Add(first, second);
            Console.WriteLine($"Addition Result: {result}");
        }

        private void AddLengthWithTargetUnit()
        {
            var first = ReadLengthQuantity("first");
            var second = ReadLengthQuantity("second");
            LengthUnit targetUnit = ReadLengthUnit("target");

            var result = lengthService.Add(first, second, targetUnit);
            Console.WriteLine($"Addition Result: {result}");
        }

        private void AddWeightWithTargetUnit()
        {
            var first = ReadWeightQuantity("first");
            var second = ReadWeightQuantity("second");
            WeightUnit targetUnit = ReadWeightUnit("target");

            var result = weightService.Add(first, second, targetUnit);
            Console.WriteLine($"Addition Result: {result}");
        }

        private void AddVolumeWithTargetUnit()
        {
            var first = ReadVolumeQuantity("first");
            var second = ReadVolumeQuantity("second");
            VolumeUnit targetUnit = ReadVolumeUnit("target");

            var result = volumeService.Add(first, second, targetUnit);
            Console.WriteLine($"Addition Result: {result}");
        }

        private void SubtractLengthQuantities()
        {
            var first = ReadLengthQuantity("first");
            var second = ReadLengthQuantity("second");

            var result = lengthService.Subtract(first, second);
            Console.WriteLine($"Subtraction Result: {result}");
        }

        private void DivideLengthQuantities()
        {
            var first = ReadLengthQuantity("first");
            var second = ReadLengthQuantity("second");

            double result = lengthService.Divide(first, second);
            Console.WriteLine($"Division Result: {result}");
        }

        private void SubtractWeightQuantities()
        {
            var first = ReadWeightQuantity("first");
            var second = ReadWeightQuantity("second");

            var result = weightService.Subtract(first, second);
            Console.WriteLine($"Subtraction Result: {result}");
        }

        private void DivideWeightQuantities()
        {
            var first = ReadWeightQuantity("first");
            var second = ReadWeightQuantity("second");

            double result = weightService.Divide(first, second);
            Console.WriteLine($"Division Result: {result}");
        }

        private void SubtractVolumeQuantities()
        {
            var first = ReadVolumeQuantity("first");
            var second = ReadVolumeQuantity("second");

            var result = volumeService.Subtract(first, second);
            Console.WriteLine($"Subtraction Result: {result}");
        }

        private void DivideVolumeQuantities()
        {
            var first = ReadVolumeQuantity("first");
            var second = ReadVolumeQuantity("second");

            double result = volumeService.Divide(first, second);
            Console.WriteLine($"Division Result: {result}");
        }

        private Quantity<LengthUnit> ReadLengthQuantity(string label)
        {
            Console.Write($"Enter {label} length value: ");
            double value = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Available Length Units: FEET, INCH, YARD, CENTIMETER");
            Console.Write($"Enter {label} length unit: ");
            LengthUnit unit = Enum.Parse<LengthUnit>(Console.ReadLine()!, true);

            return new Quantity<LengthUnit>(value, unit);
        }

        private Quantity<WeightUnit> ReadWeightQuantity(string label)
        {
            Console.Write($"Enter {label} weight value: ");
            double value = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Available Weight Units: GRAM, KILOGRAM, TONNE");
            Console.Write($"Enter {label} weight unit: ");
            WeightUnit unit = Enum.Parse<WeightUnit>(Console.ReadLine()!, true);

            return new Quantity<WeightUnit>(value, unit);
        }

        private Quantity<VolumeUnit> ReadVolumeQuantity(string label)
        {
            Console.Write($"Enter {label} volume value: ");
            double value = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Available Volume Units: MILLILITRE, LITRE, GALLON");
            Console.Write($"Enter {label} volume unit: ");
            VolumeUnit unit = Enum.Parse<VolumeUnit>(Console.ReadLine()!, true);

            return new Quantity<VolumeUnit>(value, unit);
        }

        private LengthUnit ReadLengthUnit(string label)
        {
            Console.WriteLine("Available Length Units: FEET, INCH, YARD, CENTIMETER");
            Console.Write($"Enter {label} length unit: ");
            return Enum.Parse<LengthUnit>(Console.ReadLine()!, true);
        }

        private WeightUnit ReadWeightUnit(string label)
        {
            Console.WriteLine("Available Weight Units: GRAM, KILOGRAM, TONNE");
            Console.Write($"Enter {label} weight unit: ");
            return Enum.Parse<WeightUnit>(Console.ReadLine()!, true);
        }

        private VolumeUnit ReadVolumeUnit(string label)
        {
            Console.WriteLine("Available Volume Units: MILLILITRE, LITRE, GALLON");
            Console.Write($"Enter {label} volume unit: ");
            return Enum.Parse<VolumeUnit>(Console.ReadLine()!, true);
        }
    }
}