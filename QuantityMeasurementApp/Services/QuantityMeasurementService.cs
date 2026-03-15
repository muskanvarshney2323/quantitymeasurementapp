using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementService
    {
        public static bool AreFeetEqual(double first, double second)
        {
            return first == second;
        }

        public static bool AreInchEqual(double first, double second)
        {
            return first == second;
        }

        public Feet? ParseFeetInput(string? input)
        {
            if (double.TryParse(input, out double value))
                return new Feet(value);

            return null;
        }

        public Inch? ParseInchInput(string? input)
        {
            if (double.TryParse(input, out double value))
                return new Inch(value);

            return null;
        }

        public bool CompareFeetEquality(Feet first, Feet second)
        {
            return first.Equals(second);
        }

        public bool CompareInchEquality(Inch first, Inch second)
        {
            return first.Equals(second);
        }
    }
}