using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Supported length units
    /// Base unit is FEET
    /// </summary>
    public enum LengthUnit
    {
        FEET,
        INCH,
        YARD,
        CENTIMETER
    }

    public static class LengthUnitExtensions
    {
        private static readonly double[] FeetConversionMap =
        {
            1.0,        // FEET → FEET
            1.0 / 12.0  // INCH → FEET
        };

         public static double ToFeetFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => 1.0,
                LengthUnit.INCH => 1.0 / 12.0,          // 1 inch = 1/12 feet
                LengthUnit.YARD => 3.0,                 // 1 yard = 3 feet
                LengthUnit.CENTIMETER => 0.0328084,     // 1 cm = 0.0328084 feet
                _ => throw new ArgumentException($"Unsupported length unit: {unit}")
            };
        }

        // Symbol for displaying
        public static string GetSymbol(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "ft",
                LengthUnit.INCH => "in",
                LengthUnit.YARD => "yd",
                LengthUnit.CENTIMETER => "cm",
                _ => throw new ArgumentException($"Unsupported length unit: {unit}")
            };
        }
    }
}