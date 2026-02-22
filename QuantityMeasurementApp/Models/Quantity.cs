using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Represents a measurable quantity consisting of a numeric value and a length unit
    /// This generic model replaces multiple unit-specific classes
    /// </summary>
    public class Quantity
    {
        // Stores the measurement amount
        private readonly double _amount;

        // Stores the measurement unit
        private readonly LengthUnit _lengthUnit;

        // Initializes a Quantity instance with value and unit
        // amount: numeric measurement
        // lengthUnit: unit of measurement
        public Quantity(double amount, LengthUnit lengthUnit)
        {
            _amount = amount;
            _lengthUnit = lengthUnit;
        }

        // Returns the stored numeric value
        public double Value => _amount;

        // Returns the unit associated with the value
        public LengthUnit Unit => _lengthUnit;

        // Converts the quantity into feet (base unit)
        private double ToFeet()
        {
            return _amount * _lengthUnit.GetConversionFactorToFeet();
        }

        // Checks equality between two Quantity objects
        // Comparison is done after converting both values to feet
        public override bool Equals(object? obj)
        {
            // Same reference implies equality
            if (ReferenceEquals(this, obj))
                return true;

            // Null objects are never equal
            if (obj == null)
                return false;

            // Ensure both objects are of the same type
            if (obj.GetType() != typeof(Quantity))
                return false;

            // Cast after validation
            Quantity otherQuantity = (Quantity)obj;

            // Normalize both values to feet before comparison
            double thisValueInFeet = ToFeet();
            double otherValueInFeet = otherQuantity.ToFeet();

            // Perform strict equality check
            return thisValueInFeet == otherValueInFeet;
        }

        // Generates hash code based on normalized (feet) value
        // Ensures consistency with Equals()
        public override int GetHashCode()
        {
            return ToFeet().GetHashCode();
        }

        // Returns readable string format of quantity
        // Example: "2.5 ft" or "30 in"
        public override string ToString()
        {
            return $"{_amount} {_lengthUnit.GetUnitSymbol()}";
        }
    }
}