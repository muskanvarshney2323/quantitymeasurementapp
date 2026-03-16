using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementService
    {
        public bool CompareQuantityEquality(Quantity? firstQuantity, Quantity? secondQuantity)
        {
            if (firstQuantity == null || secondQuantity == null)
                return false;

            return firstQuantity.Equals(secondQuantity);
        }

        public Quantity? ParseQuantityInput(string? input, LengthUnit unit)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (!Enum.IsDefined(typeof(LengthUnit), unit))
                return null;

            if (double.TryParse(input, out double value))
                return new Quantity(value, unit);

            return null;
        }

        public bool AreQuantitiesEqual(double firstValue, LengthUnit firstUnit, double secondValue, LengthUnit secondUnit)
        {
            var firstQuantity = new Quantity(firstValue, firstUnit);
            var secondQuantity = new Quantity(secondValue, secondUnit);

            return CompareQuantityEquality(firstQuantity, secondQuantity);
        }

        public Feet? ParseFeetInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (double.TryParse(input, out double value))
                return new Feet(value);

            return null;
        }

        public bool CompareFeetEquality(Feet? firstFeet, Feet? secondFeet)
        {
            if (firstFeet == null || secondFeet == null)
                return false;

            return firstFeet.Equals(secondFeet);
        }

        public Inch? ParseInchInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (double.TryParse(input, out double value))
                return new Inch(value);

            return null;
        }

        public bool CompareInchEquality(Inch? firstInch, Inch? secondInch)
        {
            if (firstInch == null || secondInch == null)
                return false;

            return firstInch.Equals(secondInch);
        }

        public static bool AreFeetEqual(double firstValue, double secondValue)
        {
            return new Feet(firstValue).Equals(new Feet(secondValue));
        }

        public static bool AreInchEqual(double firstValue, double secondValue)
        {
            return new Inch(firstValue).Equals(new Inch(secondValue));
        }

        public Quantity AddQuantities(Quantity firstQuantity, Quantity secondQuantity)
        {
            if (firstQuantity == null || secondQuantity == null)
                throw new ArgumentNullException();

            return firstQuantity.Add(secondQuantity);
        }

        public Quantity AddQuantities(Quantity firstQuantity, Quantity secondQuantity, LengthUnit targetUnit)
        {
            if (firstQuantity == null || secondQuantity == null)
                throw new ArgumentNullException();

            return firstQuantity.Add(secondQuantity, targetUnit);
        }

        public double ConvertQuantity(double value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            return Quantity.Convert(value, fromUnit, toUnit);
        }
    }
}