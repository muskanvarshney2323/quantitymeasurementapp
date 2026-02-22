using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Provides measurement-related operations using the generic Quantity model
    /// Supports comparison, parsing, and backward compatibility with older units
    /// </summary>
    public class QuantityMeasurementService
    {
        // Compares two Quantity objects after validation
        // Returns false if any input is null
        public bool CompareQuantityEquality(Quantity? first, Quantity? second)
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        // Converts string input into a Quantity object for a given unit
        // Returns null for invalid or empty input
        public Quantity? ParseQuantityInput(string? rawInput, LengthUnit unit)
        {
            if (string.IsNullOrWhiteSpace(rawInput))
                return null;

            bool parsed = double.TryParse(rawInput, out double numericValue);
            return parsed ? new Quantity(numericValue, unit) : null;
        }

        // Static helper to compare two values with their respective units
        // Uses Quantity internally for normalization
        public static bool AreQuantitiesEqual(
            double firstValue,
            LengthUnit firstUnit,
            double secondValue,
            LengthUnit secondUnit
        )
        {
            Quantity left = new Quantity(firstValue, firstUnit);
            Quantity right = new Quantity(secondValue, secondUnit);

            return left.Equals(right);
        }

        // -------- Backward Compatibility (Feet) --------

        public bool CompareFeetEquality(Feet? leftFeet, Feet? rightFeet)
        {
            if (leftFeet == null || rightFeet == null)
                return false;

            Quantity left = new Quantity(leftFeet.Value, LengthUnit.FEET);
            Quantity right = new Quantity(rightFeet.Value, LengthUnit.FEET);

            return left.Equals(right);
        }

        public Feet? ParseFeetInput(string? input)
        {
            Quantity? parsed = ParseQuantityInput(input, LengthUnit.FEET);
            return parsed == null ? null : new Feet(parsed.Value);
        }

        // -------- Backward Compatibility (Inch) --------

        public bool CompareInchEquality(Inch? leftInch, Inch? rightInch)
        {
            if (leftInch == null || rightInch == null)
                return false;

            Quantity left = new Quantity(leftInch.Value, LengthUnit.INCH);
            Quantity right = new Quantity(rightInch.Value, LengthUnit.INCH);

            return left.Equals(right);
        }

        public Inch? ParseInchInput(string? input)
        {
            Quantity? parsed = ParseQuantityInput(input, LengthUnit.INCH);
            return parsed == null ? null : new Inch(parsed.Value);
        }
    }
}