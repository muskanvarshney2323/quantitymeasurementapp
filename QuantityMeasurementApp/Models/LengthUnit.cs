using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Defines supported length measurement units
    /// Feet is treated as the base reference unit
    /// </summary>
    public enum LengthUnit
    {
        FEET,   // Base unit (1 foot = 1 foot)
        INCH    // Derived unit (12 inches = 1 foot)
    }

    /// <summary>
    /// Provides helper methods for LengthUnit enum
    /// Includes unit conversion and display utilities
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Internal mapping of units to their equivalent value in feet
        private static readonly double[] FeetConversionMap =
        {
            1.0,        // FEET → FEET
            1.0 / 12.0  // INCH → FEET
        };

        /// <summary>
        /// Returns multiplier needed to convert a unit into feet
        /// </summary>
        public static double ToFeetFactor(this LengthUnit unit)
        {
            int position = (int)unit;

            if (position < 0 || position >= FeetConversionMap.Length)
                throw new ArgumentException($"Unsupported length unit: {unit}");

            return FeetConversionMap[position];
        }

        /// <summary>
        /// Returns short textual symbol for the given unit
        /// </summary>
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