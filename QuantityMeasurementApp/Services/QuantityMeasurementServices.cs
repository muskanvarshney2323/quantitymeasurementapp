using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Provides business logic related to quantity comparison and parsing.
    /// Uses the generic Quantity class instead of individual measurement types.
    /// </summary>
    public class QuantityMeasurementService
    {
        /// <summary>
        /// Determines whether two Quantity objects represent the same measurement.
        /// Returns false if either object is null.
        /// </summary>
        /// <param name="quantity1">First quantity to compare.</param>
        /// <param name="quantity2">Second quantity to compare.</param>
        /// <returns>True if both quantities are non-null and equal; otherwise, false.</returns>
        public bool CompareQuantityEquality(Quantity? quantity1, Quantity? quantity2)
        {
            // If either measurement is null, equality cannot be established
            if (quantity1 is null || quantity2 is null)
                return false;

            // Use the Quantity class equality logic
            return quantity1.Equals(quantity2);
        }

        /// <summary>
        /// Attempts to create a Quantity object from user input.
        /// </summary>
        /// <param name="input">String representation of the numeric value.</param>
        /// <param name="unit">Unit associated with the value.</param>
        /// <returns>
        /// A new Quantity instance if parsing succeeds; otherwise, null.
        /// </returns>
        public Quantity? ParseQuantityInput(string? input, LengthUnit unit)
        {
            // Reject null, empty, or whitespace-only input
            if (string.IsNullOrWhiteSpace(input))
                return null;

            // Try converting the input string to a double
            if (double.TryParse(input, out double value))
            {
                return new Quantity(value, unit);
            }

            // Return null if parsing fails
            return null;
        }

        /// <summary>
        /// Compares two raw numeric values with their respective units
        /// by internally creating Quantity objects.
        /// </summary>
        /// <returns>True if both measurements are equal.</returns>
        public bool AreQuantitiesEqual(
            double value1,
            LengthUnit unit1,
            double value2,
            LengthUnit unit2
        )
        {
            Quantity quantity1 = new Quantity(value1, unit1);
            Quantity quantity2 = new Quantity(value2, unit2);

            return quantity1.Equals(quantity2);
        }

        /// <summary>
        /// Compares two Feet objects for equality using the new Quantity model.
        /// Maintained for backward compatibility.
        /// </summary>
        public bool CompareFeetEquality(Feet? feet1, Feet? feet2)
        {
            if (feet1 is null || feet2 is null)
                return false;

            Quantity q1 = new Quantity(feet1.Value, LengthUnit.FEET);
            Quantity q2 = new Quantity(feet2.Value, LengthUnit.FEET);

            return q1.Equals(q2);
        }

        /// <summary>
        /// Parses user input into a Feet object using the generic parsing logic.
        /// Maintained for backward compatibility.
        /// </summary>
        public Feet? ParseFeetInput(string? input)
        {
            Quantity? quantity = ParseQuantityInput(input, LengthUnit.FEET);
            return quantity != null ? new Feet(quantity.Value) : null;
        }

        /// <summary>
        /// Compares two Inch objects for equality using the generic Quantity logic.
        /// Maintained for backward compatibility.
        /// </summary>
        public bool CompareInchEquality(Inch? inch1, Inch? inch2)
        {
            if (inch1 is null || inch2 is null)
                return false;

            Quantity q1 = new Quantity(inch1.Value, LengthUnit.INCH);
            Quantity q2 = new Quantity(inch2.Value, LengthUnit.INCH);

            return q1.Equals(q2);
        }

        /// <summary>
        /// Parses user input into an Inch object using the shared parsing logic.
        /// Maintained for backward compatibility.
        /// </summary>
        public Inch? ParseInchInput(string? input)
        {
            Quantity? quantity = ParseQuantityInput(input, LengthUnit.INCH);
            return quantity != null ? new Inch(quantity.Value) : null;
        }
    }
}