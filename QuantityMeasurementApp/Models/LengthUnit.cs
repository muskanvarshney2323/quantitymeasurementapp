using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Defines the supported length measurement types.
    /// Each value represents a unit that can be converted into feet,
    /// which is treated as the standard reference unit.
    /// </summary>
    public enum LengthUnit
    {
        FEET,        // Standard reference unit (1 foot = 1 foot)
        INCH,        // 12 inches make 1 foot
        YARD,        // 1 yard equals 3 feet
        CENTIMETER   // 1 inch = 2.54 cm (exact value used for calculation)
    }

    /// <summary>
    /// Provides helper methods for LengthUnit such as 
    /// unit conversion and formatted display values.
    /// </summary>
    public class LengthUnitExtensions
    {
        // Conversion multipliers used to transform each unit into feet.
        // The index position matches the LengthUnit enum order.
        private readonly double[] _conversionToFeet =
        {
            1.0,                    // FEET → FEET
            1.0 / 12.0,             // INCH → FEET
            3.0,                    // YARD → FEET
            1.0 / (2.54 * 12.0)     // CENTIMETER → FEET
        };

        // Small margin used when comparing decimal values
        public const double Tolerance = 0.000001;

        /// <summary>
        /// Returns the multiplier required to convert a given unit into feet.
        /// </summary>
        public double GetConversionFactorToFeet(LengthUnit unit)
        {
            int position = (int)unit;

            if (position >= 0 && position < _conversionToFeet.Length)
            {
                return _conversionToFeet[position];
            }

            throw new ArgumentException($"Unsupported unit: {unit}");
        }

        /// <summary>
        /// Determines whether two double values are nearly equal,
        /// accounting for floating-point precision limits.
        /// </summary>
        public bool AreApproximatelyEqual(double first, double second, double tolerance = Tolerance)
        {
            return Math.Abs(first - second) < tolerance;
        }

        /// <summary>
        /// Provides the short symbol for display purposes (e.g., ft, in).
        /// </summary>
        public static string GetUnitSymbol(LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "ft",
                LengthUnit.INCH => "in",
                LengthUnit.YARD => "yd",
                LengthUnit.CENTIMETER => "cm",
                _ => unit.ToString().ToLower()
            };
        }

        /// <summary>
        /// Provides the full descriptive name of the unit.
        /// </summary>
        public static string GetUnitName(LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "feet",
                LengthUnit.INCH => "inches",
                LengthUnit.YARD => "yards",
                LengthUnit.CENTIMETER => "centimeters",
                _ => unit.ToString().ToLower()
            };
        }
    }
}