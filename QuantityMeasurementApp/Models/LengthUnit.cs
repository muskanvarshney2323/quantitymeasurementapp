using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Supported length units.
    /// Base unit is FEET.
    /// </summary>
    public enum LengthUnit
    {
        FEET,
        INCH,
        YARD,
        CENTIMETER
    }

    /// <summary>
    /// Provides conversion and display helper methods for LengthUnit.
    /// </summary>
    public static class LengthUnitExtensions
    {
        /// <summary>
        /// Returns the conversion factor required to convert the given unit into feet.
        /// </summary>
        public static double ToFeetFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => 1.0,
                LengthUnit.INCH => 1.0 / 12.0,
                LengthUnit.YARD => 3.0,
                LengthUnit.CENTIMETER => 1.0 / 30.48,
                _ => throw new ArgumentException($"Unsupported length unit: {unit}")
            };
        }

        /// <summary>
        /// Converts a value from the given unit to the base unit (feet).
        /// </summary>
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.ToFeetFactor();
        }

        /// <summary>
        /// Converts a value from the base unit (feet) to the given target unit.
        /// </summary>
        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return baseValue / unit.ToFeetFactor();
        }

        /// <summary>
        /// Returns the short symbol for the given unit.
        /// </summary>
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

        /// <summary>
        /// Returns the full display name for the given unit.
        /// </summary>
        public static string GetUnitName(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "feet",
                LengthUnit.INCH => "inches",
                LengthUnit.YARD => "yards",
                LengthUnit.CENTIMETER => "centimeters",
                _ => throw new ArgumentException($"Unsupported length unit: {unit}")
            };
        }
    }
}