using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    // Handles comparison and conversion logic for quantity measurements
    // Acts as a bridge between models and application logic
    public class QuantityMeasurementService
    {
        // Checks whether two Feet objects represent the same value
        // Returns false if either object is null
        public bool CompareFeetEquality(Feet? firstFeet, Feet? secondFeet)
        {
            // If any measurement is missing, equality cannot be established
            if (firstFeet == null || secondFeet == null)
                return false;

            // Use model-level equality comparison
            return firstFeet.Equals(secondFeet);
        }

        // Converts a string value into a Feet object
        // Returns null if input is invalid or empty
        public Feet? ParseFeetInput(string? inputValue)
        {
            // Reject null, empty, or whitespace-only inputs
            if (string.IsNullOrWhiteSpace(inputValue))
                return null;

            // Attempt to convert string to numeric value
            bool isParsed = double.TryParse(inputValue, out double parsedValue);

            // If conversion succeeds, create Feet instance
            return isParsed ? new Feet(parsedValue) : null;
        }

        // Checks whether two Inch objects represent the same value
        // Returns false if either object is null
        public bool CompareInchEquality(Inch? firstInch, Inch? secondInch)
        {
            // Null values cannot be compared
            if (firstInch == null || secondInch == null)
                return false;

            // Delegate comparison to Inch model
            return firstInch.Equals(secondInch);
        }

        // Converts a string value into an Inch object
        // Returns null if input cannot be parsed
        public Inch? ParseInchInput(string? inputValue)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(inputValue))
                return null;

            // Try converting input to double
            bool isParsed = double.TryParse(inputValue, out double parsedValue);

            // Create Inch object only if parsing succeeds
            return isParsed ? new Inch(parsedValue) : null;
        }

        // Utility method to compare two feet values directly
        // Avoids the need for service object creation
        public static bool AreFeetEqual(double firstValue, double secondValue)
        {
            Feet left = new Feet(firstValue);
            Feet right = new Feet(secondValue);

            return left.Equals(right);
        }

        // Utility method to compare two inch values directly
        // Performs value-based comparison
        public static bool AreInchEqual(double firstValue, double secondValue)
        {
            Inch left = new Inch(firstValue);
            Inch right = new Inch(secondValue);

            return left.Equals(right);
        }
    }
}