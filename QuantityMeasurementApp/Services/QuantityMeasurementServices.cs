using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Handles all quantity-related comparison and parsing operations
    /// Uses instance methods instead of static ones
    /// </summary>
    public class QuantityMeasurementService
    {
        // Checks whether two Quantity objects represent the same measurement
        // Returns false if any of the objects is null
        public bool CheckQuantityMatch(Quantity? first, Quantity? second)
        {
            // If either quantity is missing, they cannot be equal
            if (first == null || second == null)
                return false;

            // Use Quantity class's equality logic
            return first.Equals(second);
        }

        // Converts user input string into a Quantity object
        // Returns null if input is invalid or empty
        public Quantity? ConvertToQuantity(string? userInput, LengthUnit unitType)
        {
            // Validate input
            if (string.IsNullOrEmpty(userInput))
                return null;

            // Attempt to convert string to numeric value
            if (double.TryParse(userInput, out double parsedValue))
            {
                return new Quantity(parsedValue, unitType);
            }

            // Input is not a valid number
            return null;
        }

        // Compares two values with their respective units
        // Internally converts them into Quantity objects
        public bool IsQuantityEqual(
            double firstValue,
            LengthUnit firstUnit,
            double secondValue,
            LengthUnit secondUnit
        )
        {
            Quantity firstQuantity = new Quantity(firstValue, firstUnit);
            Quantity secondQuantity = new Quantity(secondValue, secondUnit);

            return firstQuantity.Equals(secondQuantity);
        }

        // Legacy support for Feet comparison using Quantity
        public bool MatchFeetValues(Feet? firstFeet, Feet? secondFeet)
        {
            if (firstFeet == null || secondFeet == null)
                return false;

            Quantity q1 = new Quantity(firstFeet.Value, LengthUnit.FEET);
            Quantity q2 = new Quantity(secondFeet.Value, LengthUnit.FEET);

            return q1.Equals(q2);
        }

        // Legacy support for parsing Feet input
        public Feet? ConvertFeetInput(string? input)
        {
            Quantity? quantity = ConvertToQuantity(input, LengthUnit.FEET);
            return quantity == null ? null : new Feet(quantity.Value);
        }

        // Legacy support for Inch comparison using Quantity
        public bool MatchInchValues(Inch? firstInch, Inch? secondInch)
        {
            if (firstInch == null || secondInch == null)
                return false;

            Quantity q1 = new Quantity(firstInch.Value, LengthUnit.INCH);
            Quantity q2 = new Quantity(secondInch.Value, LengthUnit.INCH);

            return q1.Equals(q2);
        }

        // Legacy support for parsing Inch input
        public Inch? ConvertInchInput(string? input)
        {
            Quantity? quantity = ConvertToQuantity(input, LengthUnit.INCH);
            return quantity == null ? null : new Inch(quantity.Value);
        }
    }
}