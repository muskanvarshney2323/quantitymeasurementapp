using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Provides helper methods for performing quantity-related operations.
    /// This service now relies on the unified Quantity model instead of
    /// individual unit-specific classes like Feet and Inch.
    /// </summary>
    public class QuantityMeasurementService
    {
        // Checks whether two Quantity objects represent the same measurement
        // Arguments:
        // quantity1 - first Quantity instance (may be null)
        // quantity2 - second Quantity instance (may be null)
        // Returns true only when both quantities are non-null and equal
        public bool CompareQuantityEquality(Quantity? quantity1, Quantity? quantity2)
        {
            // If either input is null, equality comparison is not possible
            if (quantity1 is null || quantity2 is null)
                return false;

            // Use Quantity's internal equality logic
            return quantity1.Equals(quantity2);
        }

        // Converts a string input into a Quantity instance for a given unit
        // Arguments:
        // input - raw string value entered by the user
        // unit  - measurement unit to associate with the value
        // Returns a Quantity object if conversion succeeds; otherwise null
        public Quantity? ParseQuantityInput(string? input, LengthUnit unit)
        {
            // Reject empty, null, or whitespace-only inputs
            if (string.IsNullOrWhiteSpace(input))
                return null;

            // Attempt to convert the input string into a numeric value
            if (double.TryParse(input, out double value))
            {
                // Parsing succeeded, create Quantity using parsed value
                return new Quantity(value, unit);
            }

            // Input could not be converted to a number
            return null;
        }

        // Compares two measurements by value and unit without requiring Quantity objects
        // Arguments:
        // value1, unit1 - first measurement details
        // value2, unit2 - second measurement details
        // Returns true if both measurements are equivalent
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

        // Maintains compatibility with legacy Feet-based logic
        // Internally converts Feet objects to Quantity for comparison
        public bool CompareFeetEquality(Feet? feet1, Feet? feet2)
        {
            if (feet1 is null || feet2 is null)
                return false;

            Quantity q1 = new Quantity(feet1.Value, LengthUnit.FEET);
            Quantity q2 = new Quantity(feet2.Value, LengthUnit.FEET);

            return q1.Equals(q2);
        }

        // Supports older Feet parsing logic using the new Quantity approach
        public Feet? ParseFeetInput(string? input)
        {
            Quantity? q = ParseQuantityInput(input, LengthUnit.FEET);
            return q != null ? new Feet(q.Value) : null;
        }

        // Retains backward compatibility for Inch equality checks
        // Internally converts Inch instances to Quantity
        public bool CompareInchEquality(Inch? inch1, Inch? inch2)
        {
            if (inch1 is null || inch2 is null)
                return false;

            Quantity q1 = new Quantity(inch1.Value, LengthUnit.INCH);
            Quantity q2 = new Quantity(inch2.Value, LengthUnit.INCH);

            return q1.Equals(q2);
        }

        // Parses inch-based input while leveraging the Quantity model
        public Inch? ParseInchInput(string? input)
        {
            Quantity? q = ParseQuantityInput(input, LengthUnit.INCH);
            return q != null ? new Inch(q.Value) : null;
        }
    }
}