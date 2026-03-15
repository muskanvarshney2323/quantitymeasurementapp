using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementService
    {
        public bool CompareQuantityEquality(Quantity? first, Quantity? second)
        {
            if (first == null || second == null) return false;
            return first.Equals(second);
        }

        public Quantity? ParseQuantityInput(string? rawInput, LengthUnit unit)
        {
            if (string.IsNullOrWhiteSpace(rawInput)) return null;

            bool parsed = double.TryParse(rawInput, out double value);
            return parsed ? new Quantity(value, unit) : null;
        }

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

        // Backward compatibility for Feet
        public bool CompareFeetEquality(Quantity? leftFeet, Quantity? rightFeet)
        {
            if (leftFeet == null || rightFeet == null) return false;
            return leftFeet.Equals(rightFeet);
        }

        public Quantity? ParseFeetInput(string? input)
        {
            return ParseQuantityInput(input, LengthUnit.FEET);
        }

        // Backward compatibility for Inch
        public bool CompareInchEquality(Quantity? leftInch, Quantity? rightInch)
        {
            if (leftInch == null || rightInch == null) return false;
            return leftInch.Equals(rightInch);
        }

        public Quantity? ParseInchInput(string? input)
        {
            return ParseQuantityInput(input, LengthUnit.INCH);
        }
    }
}