using QuantityMeasurementApp.Models;
using DomainQuantities = QuantityMeasurementApp.Domain.Quantities;
using DomainUnits = QuantityMeasurementApp.Domain.Units;
using DomainValueObjects = QuantityMeasurementApp.Domain.ValueObjects;

namespace QuantityMeasurementApp.Services
{
    /// <summary>
    /// Service class for quantity measurement operations
    /// Updated to use the generic Quantity class instead of separate Feet and Inch classes
    /// </summary>
    public class QuantityMeasurementService
    {
        // Compares two quantity measurements for equality
        // Parameter: quantity1 - First quantity measurement (can be null)
        // Parameter: quantity2 - Second quantity measurement (can be null)
        // Returns: True if both measurements are equal and non-null; otherwise, false
        public bool CompareQuantityEquality(Quantity? quantity1, Quantity? quantity2)
        {
            // Handle null cases - if either measurement is null, they cannot be equal
            if (quantity1 is null || quantity2 is null)
                return false;

            // Delegate the equality check to the Quantity class's Equals method
            return quantity1.Equals(quantity2);
        }

        // Creates a Quantity object from a string input and unit
        // Parameter: input - String input to parse (can be null or whitespace)
        // Parameter: unit - The unit of measurement
        // Returns: Quantity object if parsing successful; otherwise, null
        public Quantity? ParseQuantityInput(string? input, LengthUnit unit)
        {
            // Check for null or whitespace input
            if (string.IsNullOrWhiteSpace(input))
                return null;

            // Try to parse the string as a double
            if (double.TryParse(input, out double value))
            {
                // Successfully parsed, create and return a new Quantity object
                return new Quantity(value, unit);
            }

            // Parsing failed (non-numeric input), return null
            return null;
        }

        // Static method for quantity equality check - reduces dependency on main method
        // Parameter: value1 - First value
        // Parameter: unit1 - Unit of first value
        // Parameter: value2 - Second value
        // Parameter: unit2 - Unit of second value
        // Returns: True if both quantities are equal
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

        // For backward compatibility - uses the new Quantity class
        public bool CompareFeetEquality(Feet? feet1, Feet? feet2)
        {
            if (feet1 is null || feet2 is null)
                return false;

            Quantity q1 = new Quantity(feet1.Value, LengthUnit.FEET);
            Quantity q2 = new Quantity(feet2.Value, LengthUnit.FEET);
            return q1.Equals(q2);
        }

        // For backward compatibility - uses the new Quantity class
        public Feet? ParseFeetInput(string? input)
        {
            Quantity? q = ParseQuantityInput(input, LengthUnit.FEET);
            return q != null ? new Feet(q.Value) : null;
        }

        // For backward compatibility - uses the new Quantity class
        public bool CompareInchEquality(Inch? inch1, Inch? inch2)
        {
            if (inch1 is null || inch2 is null)
                return false;

            Quantity q1 = new Quantity(inch1.Value, LengthUnit.INCH);
            Quantity q2 = new Quantity(inch2.Value, LengthUnit.INCH);
            return q1.Equals(q2);
        }

        // For backward compatibility - uses the new Quantity class
        public Inch? ParseInchInput(string? input)
        {
            Quantity? q = ParseQuantityInput(input, LengthUnit.INCH);
            return q != null ? new Inch(q.Value) : null;
        }

        // Compatibility methods expected by older tests / external callers
        public bool AreQuantitiesEqual(DomainQuantities.Quantity first, DomainQuantities.Quantity second)
        {
            if (first is null || second is null) return false;
            var m1 = new Quantity(first.Value, (Models.LengthUnit)first.Unit);
            var m2 = new Quantity(second.Value, (Models.LengthUnit)second.Unit);
            return m1.Equals(m2);
        }

        public double ConvertValue(double value, DomainUnits.LengthUnit source, DomainUnits.LengthUnit target)
        {
            return Quantity.Convert(value, (Models.LengthUnit)source, (Models.LengthUnit)target);
        }

        public DomainQuantities.Quantity AddQuantities(DomainQuantities.Quantity first, DomainQuantities.Quantity second)
        {
            var m1 = new Quantity(first.Value, (Models.LengthUnit)first.Unit);
            var m2 = new Quantity(second.Value, (Models.LengthUnit)second.Unit);
            var sum = m1.Add(m2);
            return new DomainQuantities.Quantity(sum);
        }

        public DomainQuantities.Quantity AddQuantitiesWithTarget(DomainQuantities.Quantity first, DomainQuantities.Quantity second, DomainUnits.LengthUnit target)
        {
            var m1 = new Quantity(first.Value, (Models.LengthUnit)first.Unit);
            var m2 = new Quantity(second.Value, (Models.LengthUnit)second.Unit);
            var sum = m1.Add(m2, (Models.LengthUnit)target);
            return new DomainQuantities.Quantity(sum);
        }

        public DomainQuantities.Quantity? CreateQuantityFromString(string? input, DomainUnits.LengthUnit unit)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            if (double.TryParse(input, out double v))
            {
                var m = new Quantity(v, (Models.LengthUnit)unit);
                return new DomainQuantities.Quantity(m);
            }
            return null;
        }

        public DomainValueObjects.Feet? CreateFeetFromString(string? input)
        {
            var q = ParseQuantityInput(input, LengthUnit.FEET);
            return q != null ? new DomainValueObjects.Feet(q.Value) : null;
        }

        public DomainValueObjects.Inch? CreateInchFromString(string? input)
        {
            var q = ParseQuantityInput(input, LengthUnit.INCH);
            return q != null ? new DomainValueObjects.Inch(q.Value) : null;
        }

        public bool AreFeetEqual(DomainValueObjects.Feet? f1, DomainValueObjects.Feet? f2)
        {
            if (f1 is null || f2 is null) return false;
            return f1.Value == f2.Value;
        }

        public bool AreInchesEqual(DomainValueObjects.Inch? i1, DomainValueObjects.Inch? i2)
        {
            if (i1 is null || i2 is null) return false;
            return i1.Value == i2.Value;
        }
    }
}