using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    // Handles operations related to quantity measurements
    public class QuantityMeasurementService
    {
        // Compare two measurements
        public bool CompareFeetEquality(Feet? firstMeasurement, Feet? secondMeasurement)
        {
            if (firstMeasurement == null)
                return false;

            if (secondMeasurement == null)
                return false;

            return firstMeasurement.Equals(secondMeasurement);
        }

        // Convert user input string to Feet object
        public Feet? ParseFeetInput(string? userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return null;

            bool isValid = double.TryParse(userInput, out double parsedValue);

            if (!isValid)
                return null;

            Feet result = new Feet(parsedValue);

            return result;
        }
    }
}