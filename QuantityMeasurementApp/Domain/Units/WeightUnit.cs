using System;
using Models = QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Domain.Units
{
    /// <summary>
    /// Weight units with conversion helpers. Base unit: kilogram.
    /// </summary>
    public enum WeightUnit
    {
        KILOGRAM = 0,
        GRAM = 1,
        POUND = 2
    }

    public static class WeightUnitExtensions
    {
        // conversion factors to kilograms (base)
        // index order must match WeightUnit enum
        private static readonly double[] ToKilogramFactors = new double[]
        {
            1.0,        // KILOGRAM -> kilogram
            0.001,      // GRAM -> kilogram
            0.453592    // POUND -> kilogram
        };

        public static double GetConversionFactor(this WeightUnit unit)
        {
            int index = (int)unit;
            if (index < 0 || index >= ToKilogramFactors.Length)
                throw new QuantityMeasurementApp.Core.Exceptions.InvalidUnitException($"Unsupported unit: {unit}");

            return ToKilogramFactors[index];
        }

        public static double ToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double FromBaseUnit(this WeightUnit unit, double valueInKilograms)
        {
            return valueInKilograms / unit.GetConversionFactor();
        }

        public static double ConvertTo(this WeightUnit sourceUnit, WeightUnit targetUnit, double value)
        {
            double inKg = sourceUnit.ToBaseUnit(value);
            return targetUnit.FromBaseUnit(inKg);
        }

        public static string GetSymbol(this WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.KILOGRAM => "kg",
                WeightUnit.GRAM => "g",
                WeightUnit.POUND => "lb",
                _ => unit.ToString().ToLower(),
            };
        }

        public static string GetName(this WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.KILOGRAM => "kilograms",
                WeightUnit.GRAM => "grams",
                WeightUnit.POUND => "pounds",
                _ => unit.ToString().ToLower(),
            };
        }
    }
}
