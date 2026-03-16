using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Provides helper methods for parsing quantities
    /// and comparing measurements across supported units.
    /// </summary>
    public class QuantityMeasurementService
    {
        /// <summary>
        /// Compares two Feet objects for equality.
        /// </summary>
        public bool CompareFeetEquality(Feet? first, Feet? second)
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        /// <summary>
        /// Parses user input into a Feet object.
        /// Returns null if input is invalid.
        /// </summary>
        public Feet? ParseFeetInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return double.TryParse(input, out double value)
                ? new Feet(value)
                : null;
        }

        /// <summary>
        /// Compares two Inch objects for equality.
        /// </summary>
        public bool CompareInchEquality(Inch? first, Inch? second)
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        /// <summary>
        /// Parses user input into an Inch object.
        /// Returns null if input is invalid.
        /// </summary>
        public Inch? ParseInchInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return double.TryParse(input, out double value)
                ? new Inch(value)
                : null;
        }

        /// <summary>
        /// Compares two Quantity objects for equality.
        /// Supports same-unit and cross-unit comparison.
        /// </summary>
        public bool CompareQuantityEquality(Quantity? first, Quantity? second)
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        /// <summary>
        /// Parses user input into a Quantity object
        /// for the specified length unit.
        /// Returns null if input is invalid.
        /// </summary>
        public Quantity? ParseQuantityInput(string? input, LengthUnit unit)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return double.TryParse(input, out double value)
                ? new Quantity(value, unit)
                : null;
        }

        /// <summary>
        /// Compares two raw quantity values by creating Quantity objects.
        /// </summary>
        public bool AreQuantitiesEqual(
            double firstValue,
            LengthUnit firstUnit,
            double secondValue,
            LengthUnit secondUnit)
        {
            var firstQuantity = new Quantity(firstValue, firstUnit);
            var secondQuantity = new Quantity(secondValue, secondUnit);

            return firstQuantity.Equals(secondQuantity);
        }

        /// <summary>
        /// Compares two raw feet values for equality.
        /// </summary>
        public static bool AreFeetEqual(double first, double second)
        {
            return new Feet(first).Equals(new Feet(second));
        }

        /// <summary>
        /// Compares two raw inch values for equality.
        /// </summary>
        public static bool AreInchEqual(double first, double second)
        {
            return new Inch(first).Equals(new Inch(second));
        }
    }
}