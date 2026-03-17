using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Views;

namespace QuantityMeasurementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Quantity Measurement Application ===");
            Console.WriteLine("UC12: Subtraction and Division Operations\n");

            RunDirectDemonstrations();

            Console.WriteLine("\n--- Menu Demo ---");
            var menu = new Menu();
            menu.Show();
        }

        private static void RunDirectDemonstrations()
        {
            Console.WriteLine("Subtraction Demonstrations:");
            var lengthSubtraction = new Quantity<LengthUnit>(10.0, LengthUnit.FEET)
                .Subtract(new Quantity<LengthUnit>(6.0, LengthUnit.INCH));
            Console.WriteLine($"10 FEET - 6 INCH = {lengthSubtraction}");

            var weightSubtraction = new Quantity<WeightUnit>(10.0, WeightUnit.KILOGRAM)
                .Subtract(new Quantity<WeightUnit>(5000.0, WeightUnit.GRAM));
            Console.WriteLine($"10 KILOGRAM - 5000 GRAM = {weightSubtraction}");

            var volumeSubtraction = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE)
                .Subtract(new Quantity<VolumeUnit>(500.0, VolumeUnit.MILLILITRE));
            Console.WriteLine($"5 LITRE - 500 MILLILITRE = {volumeSubtraction}");

            Console.WriteLine("\nDivision Demonstrations:");
            double lengthDivision = new Quantity<LengthUnit>(24.0, LengthUnit.INCH)
                .Divide(new Quantity<LengthUnit>(2.0, LengthUnit.FEET));
            Console.WriteLine($"24 INCH / 2 FEET = {lengthDivision}");

            double weightDivision = new Quantity<WeightUnit>(2000.0, WeightUnit.GRAM)
                .Divide(new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM));
            Console.WriteLine($"2000 GRAM / 1 KILOGRAM = {weightDivision}");

            double volumeDivision = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE)
                .Divide(new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE));
            Console.WriteLine($"1000 MILLILITRE / 1 LITRE = {volumeDivision}");
        }
    }
}