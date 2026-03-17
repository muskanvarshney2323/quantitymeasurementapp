using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Views
{
    public class Menu
    {
        private readonly QuantityMeasurementServices _service = new QuantityMeasurementServices();

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n==== Quantity Measurement Menu ====");
                Console.WriteLine("1. Length Subtraction");
                Console.WriteLine("2. Weight Subtraction");
                Console.WriteLine("3. Volume Subtraction");
                Console.WriteLine("4. Length Division");
                Console.WriteLine("5. Weight Division");
                Console.WriteLine("6. Volume Division");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowLengthSubtraction();
                        break;
                    case "2":
                        ShowWeightSubtraction();
                        break;
                    case "3":
                        ShowVolumeSubtraction();
                        break;
                    case "4":
                        ShowLengthDivision();
                        break;
                    case "5":
                        ShowWeightDivision();
                        break;
                    case "6":
                        ShowVolumeDivision();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ShowLengthSubtraction()
        {
            var result = _service.Subtract(10.0, LengthUnit.FEET, 6.0, LengthUnit.INCH, LengthUnit.FEET);
            Console.WriteLine($"10 FEET - 6 INCH = {result}");
        }

        private void ShowWeightSubtraction()
        {
            var result = _service.Subtract(10.0, WeightUnit.KILOGRAM, 5000.0, WeightUnit.GRAM, WeightUnit.KILOGRAM);
            Console.WriteLine($"10 KILOGRAM - 5000 GRAM = {result}");
        }

        private void ShowVolumeSubtraction()
        {
            var result = _service.Subtract(5.0, VolumeUnit.LITRE, 500.0, VolumeUnit.MILLILITRE, VolumeUnit.LITRE);
            Console.WriteLine($"5 LITRE - 500 MILLILITRE = {result}");
        }

        private void ShowLengthDivision()
        {
            double result = _service.Divide(24.0, LengthUnit.INCH, 2.0, LengthUnit.FEET);
            Console.WriteLine($"24 INCH / 2 FEET = {result}");
        }

        private void ShowWeightDivision()
        {
            double result = _service.Divide(2000.0, WeightUnit.GRAM, 1.0, WeightUnit.KILOGRAM);
            Console.WriteLine($"2000 GRAM / 1 KILOGRAM = {result}");
        }

        private void ShowVolumeDivision()
        {
            double result = _service.Divide(1000.0, VolumeUnit.MILLILITRE, 1.0, VolumeUnit.LITRE);
            Console.WriteLine($"1000 MILLILITRE / 1 LITRE = {result}");
        }
    }
}