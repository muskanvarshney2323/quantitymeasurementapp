using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementService
    {
        public bool CompareFeetEquality(Feet? first, Feet? second)
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        public Feet? ParseFeetInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return double.TryParse(input, out double value) ? new Feet(value) : null;
        }

        public bool CompareInchEquality(Inch? first, Inch? second)
        {
            if (first == null || second == null)
                return false;

            return first.Equals(second);
        }

        public Inch? ParseInchInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return double.TryParse(input, out double value) ? new Inch(value) : null;
        }

        public static bool AreFeetEqual(double first, double second)
        {
            return new Feet(first).Equals(new Feet(second));
        }

        public static bool AreInchEqual(double first, double second)
        {
            return new Inch(first).Equals(new Inch(second));
        }
    }
}