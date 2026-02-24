using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// A reusable Quantity class used to represent measurements 
    /// with a numeric value and a length unit.
    /// This approach avoids creating separate classes for each unit type.
    /// </summary>
    public class Quantity
    {
        // Stores the numeric measurement
        private readonly double _value;

        // Stores the unit associated with the measurement
        private readonly LengthUnit _unit;

        // Helper for unit conversion operations
        private readonly LengthUnitExtensions _unitHelper;

        /// <summary>
        /// Initializes a new Quantity instance with the given value and unit.
        /// </summary>
        /// <param name="value">Numeric measurement</param>
        /// <param name="unit">Unit type from LengthUnit enum</param>
        public Quantity(double value, LengthUnit unit)
        {
            _value = value;
            _unit = unit;
            _unitHelper = new LengthUnitExtensions();
        }

        // Exposes the stored value
        public double Value => _value;

        // Exposes the stored unit
        public LengthUnit Unit => _unit;

        /// <summary>
        /// Converts the current measurement into feet (standard comparison unit).
        /// </summary>
        private double ToFeet()
        {
            return _value * _unitHelper.GetConversionFactorToFeet(_unit);
        }

        /// <summary>
        /// Checks equality between this instance and another object.
        /// Two quantities are considered equal if their values match 
        /// after conversion to the same base unit (feet).
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is null || obj.GetType() != typeof(Quantity))
                return false;

            Quantity other = (Quantity)obj;

            double currentInFeet = this.ToFeet();
            double otherInFeet = other.ToFeet();

            return _unitHelper.AreApproximatelyEqual(currentInFeet, otherInFeet);
        }

        /// <summary>
        /// Generates a hash code using the converted value (rounded 
        /// to reduce floating-point precision inconsistencies).
        /// </summary>
        public override int GetHashCode()
        {
            double baseValue = ToFeet();
            return Math.Round(baseValue, 6).GetHashCode();
        }

        /// <summary>
        /// Returns a readable string like "2.5 ft" or "10 in".
        /// </summary>
        public override string ToString()
        {
            return $"{_value} {LengthUnitExtensions.GetUnitSymbol(_unit)}";
        }
    }
}