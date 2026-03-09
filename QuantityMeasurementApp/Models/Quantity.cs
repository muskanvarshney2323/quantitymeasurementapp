using System;
using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Models a measurable length consisting of a numeric value
    /// and its associated unit. Supports conversion and comparison.
    /// </summary>
    public class Quantity
    {
        // Stores the numeric measurement
        private readonly double _value;

        // Stores the unit of measurement
        private readonly LengthUnit _unit;

        // Handles unit conversion logic
        private readonly UnitConverter _converter;

        /// <summary>
        /// Creates a new Quantity instance with the specified value and unit.
        /// </summary>
        /// <param name="value">Numeric measurement amount.</param>
        /// <param name="unit">Measurement unit type.</param>
        public Quantity(double value, LengthUnit unit)
        {
            _value = value;
            _unit = unit;
            _converter = new UnitConverter();
        }

        /// <summary>
        /// Returns the stored numeric value.
        /// </summary>
        public double Value => _value;

        /// <summary>
        /// Returns the associated unit.
        /// </summary>
        public LengthUnit Unit => _unit;

        /// <summary>
        /// Converts this instance into another unit and
        /// returns a new Quantity with the converted value.
        /// </summary>
        /// <param name="targetUnit">Desired unit for conversion.</param>
        public Quantity ConvertTo(LengthUnit targetUnit)
        {
            ValidateUnit(targetUnit);

            double valueInFeet = _value * _converter.GetConversionFactorToFeet(_unit);
            double convertedValue =
                valueInFeet / _converter.GetConversionFactorToFeet(targetUnit);

            return new Quantity(convertedValue, targetUnit);
        }

        /// <summary>
        /// Converts a numeric value from one unit to another
        /// without manually creating a Quantity object.
        /// </summary>
        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            ValidateValue(value);
            ValidateUnit(sourceUnit);
            ValidateUnit(targetUnit);

            var original = new Quantity(value, sourceUnit);
            var result = original.ConvertTo(targetUnit);

            return result.Value;
        }

        /// <summary>
        /// Adds another Quantity to this instance and returns the result
        /// in this instance's unit.
        /// </summary>
        /// <param name="other">The Quantity to add.</param>
        /// <returns>A new Quantity representing the sum in this instance's unit.</returns>
        public Quantity Add(Quantity other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            // Convert both to feet, add, then convert back to this unit
            double thisInFeet = ConvertTo(LengthUnit.FEET).Value;
            double otherInFeet = other.ConvertTo(LengthUnit.FEET).Value;
            double sumInFeet = thisInFeet + otherInFeet;

            return new Quantity(sumInFeet, LengthUnit.FEET).ConvertTo(_unit);
        }

        /// <summary>
        /// Adds another Quantity to this instance and returns the result in the specified unit.
        /// </summary>
        /// <param name="other">The Quantity to add.</param>
        /// <param name="resultUnit">The unit for the result.</param>
        /// <returns>A new Quantity representing the sum in the specified unit.</returns>
        public Quantity Add(Quantity other, LengthUnit resultUnit)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            ValidateUnit(resultUnit);

            // Convert both to feet, add, then convert to result unit
            double thisInFeet = ConvertTo(LengthUnit.FEET).Value;
            double otherInFeet = other.ConvertTo(LengthUnit.FEET).Value;
            double sumInFeet = thisInFeet + otherInFeet;

            return new Quantity(sumInFeet, LengthUnit.FEET).ConvertTo(resultUnit);
        }

        /// <summary>
        /// Adds two quantities and returns the result in the specified unit.
        /// </summary>
        /// <param name="first">The first Quantity.</param>
        /// <param name="second">The second Quantity.</param>
        /// <param name="resultUnit">The unit for the result.</param>
        /// <returns>A new Quantity representing the sum in the specified unit.</returns>
        public static Quantity Add(Quantity first, Quantity second, LengthUnit resultUnit)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return first.Add(second, resultUnit);
        }

        /// <summary>
        /// Determines whether another object represents
        /// the same physical length as this instance.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Quantity other)
                return false;

            double thisFeet = ConvertTo(LengthUnit.FEET).Value;
            double otherFeet = other.ConvertTo(LengthUnit.FEET).Value;

            return _converter.AreApproximatelyEqual(thisFeet, otherFeet);
        }

        /// <summary>
        /// Generates a hash code based on the value converted to feet.
        /// Rounded to reduce floating-point inconsistencies.
        /// </summary>
        public override int GetHashCode()
        {
            double baseValue = ConvertTo(LengthUnit.FEET).Value;
            return Math.Round(baseValue, 6).GetHashCode();
        }

        /// <summary>
        /// Returns a readable representation such as "5 ft" or "10 cm".
        /// </summary>
        public override string ToString()
        {
            return $"{_value} {LengthUnitExtensions.GetUnitSymbol(_unit)}";
        }

        /// <summary>
        /// Ensures that the provided unit exists in the LengthUnit enum.
        /// </summary>
        private static void ValidateUnit(LengthUnit unit)
        {
            if (!Enum.IsDefined(typeof(LengthUnit), unit))
            {
                throw new ArgumentException($"Unsupported unit: {unit}");
            }
        }

        /// <summary>
        /// Ensures the numeric value is finite (not NaN or Infinity).
        /// </summary>
        private static void ValidateValue(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException(
                    $"Value must be a valid finite number. Received: {value}"
                );
            }
        }
    }
}