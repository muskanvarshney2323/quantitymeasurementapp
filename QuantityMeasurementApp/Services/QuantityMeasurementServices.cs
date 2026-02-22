using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    // Service layer responsible for measurement-related operations
    // Contains business logic for comparing and parsing quantities
    public class QuantityMeasurementService
    {
        // Checks whether two Feet objects represent the same value
        // feet1: first measurement (may be null)
        // feet2: second measurement (may be null)
        // Returns true only when both are non-null and equal
        public bool CompareFeetEquality(Feet? feet1, Feet? feet2)
        {
            // If any of the inputs is null, comparison is not valid
            if (feet1 is null || feet2 is null)
                return false;

            // Use the Equals method defined inside the Feet class
            // This keeps equality logic centralized and consistent
            return feet1.Equals(feet2);
        }

        // Converts a string input into a Feet object
        // input: textual value provided by user (can be null or empty)
        // Returns a Feet instance if conversion succeeds, otherwise null
        public Feet? ParseFeetInput(string? input)
        {
            // Reject null, empty, or space-only strings
            if (string.IsNullOrWhiteSpace(input))
                return null;

            // Attempt to convert the string into a numeric value
            // TryParse avoids exceptions for invalid inputs
            if (double.TryParse(input, out double value))
            {
                // On successful conversion, return a new Feet object
                return new Feet(value);
            }

            // If conversion fails, indicate invalid input
            return null;
        }
    }
}