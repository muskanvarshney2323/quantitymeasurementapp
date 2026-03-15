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
        INCH
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
            int pos = (int)unit;
            if (pos < 0 || pos >= FeetConversionMap.Length)
                throw new ArgumentException($"Unsupported length unit: {unit}");
            return FeetConversionMap[pos];
        }

        public static string Symbol(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "ft",
                LengthUnit.INCH => "in",
                _ => unit.ToString().ToLower()
            };
        }
    }
}