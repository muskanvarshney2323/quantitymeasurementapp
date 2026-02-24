using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Defines the supported measurement units.
    /// All units can be converted into feet, which acts as the reference unit.
    /// </summary>
    public enum LengthUnit
    {
        FEET,        // Reference unit (1 foot = 1 foot)
        INCH,        // 12 inches = 1 foot
        YARD,        // 1 yard = 3 feet
        CENTIMETER   // 1 inch = 2.54 cm (exact value used for conversion)
    }

    /// <summary>
    /// Handles numeric conversion logic between different length units.
    /// Implemented as a non-static class to allow instance-based usage.
    /// </summary>
    public class UnitConverter
    {
        // Multipliers used to convert each unit into feet.
        // Index positions correspond to the LengthUnit enum order.
        private readonly double[] _toFeetFactors =
        {
            1.0,                    // FEET → FEET
            1.0 / 12.0,             // INCH → FEET
            3.0,                    // YARD → FEET
            1.0 / (2.54 * 12.0)     // CENTIMETER → FEET
        };

        // Allowed difference when comparing floating-point numbers
        public const double Tolerance = 0.000001;

        /// <summary>
        /// Returns the multiplier required to convert the given unit into feet.
        /// </summary>
        public double GetConversionFactorToFeet(LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.FEET:
                    return _toFeetFactors[0];

                case LengthUnit.INCH:
                    return _toFeetFactors[1];

                case LengthUnit.YARD:
                    return _toFeetFactors[2];

                case LengthUnit.CENTIMETER:
                    return _toFeetFactors[3];

                default:
                    throw new ArgumentException($"Unsupported unit value: {unit}");
            }
        }

        /// <summary>
        /// Compares two double values using a small tolerance
        /// to avoid floating-point precision issues.
        /// </summary>
        public bool AreApproximatelyEqual(double first, double second, double tolerance = Tolerance)
        {
            return Math.Abs(first - second) < tolerance;
        }
    }

    /// <summary>
    /// Provides helper methods for displaying unit names and symbols.
    /// These methods are static since they do not depend on object state.
    /// </summary>
    public static class LengthUnitExtensions
    {
        // Returns abbreviated form of the unit (e.g., ft, in, yd, cm)
        public static string GetUnitSymbol(this LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.FEET:
                    return "ft";

                case LengthUnit.INCH:
                    return "in";

                case LengthUnit.YARD:
                    return "yd";

                case LengthUnit.CENTIMETER:
                    return "cm";

                default:
                    return unit.ToString().ToLower();
            }
        }

        // Returns full descriptive name of the unit
        public static string GetUnitName(this LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.FEET:
                    return "feet";

                case LengthUnit.INCH:
                    return "inches";

                case LengthUnit.YARD:
                    return "yards";

                case LengthUnit.CENTIMETER:
                    return "centimeters";

                default:
                    return unit.ToString().ToLower();
            }
        }
    }
}