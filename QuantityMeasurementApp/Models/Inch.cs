using System;

namespace QuantityMeasurementApp.Models
{
    // Model class used to store length in inches
    // Designed to be immutable so the value cannot be altered after creation
    public class Inch
    {
        // Holds the numeric inch value
        // Readonly ensures the value remains constant
        private readonly double _inchValue;

        // Creates a new Inch instance with the provided measurement
        // value: length expressed in inches
        public Inch(double value)
        {
            _inchValue = value;
        }

        // Exposes the stored inch value
        // Read-only property since the object is immutable
        public double Value
        {
            get { return _inchValue; }
        }

        // Checks whether the current object is equal to another object
        // Equality is based on the stored inch value
        public override bool Equals(object? obj)
        {
            // If both references point to the same object, they are equal
            if (ReferenceEquals(this, obj))
                return true;

            // If the compared object is null, return false
            if (obj == null)
                return false;

            // Ensure the object is of type Inch
            if (obj.GetType() != typeof(Inch))
                return false;

            // Cast the object safely after type validation
            Inch comparedInch = (Inch)obj;

            // Compare the underlying double values
            return _inchValue == comparedInch._inchValue;
        }

        // Generates a hash code based on the inch value
        // Required to maintain consistency with Equals()
        public override int GetHashCode()
        {
            return _inchValue.GetHashCode();
        }

        // Returns a user-friendly string representation
        // Example output: "2.5 in"
        public override string ToString()
        {
            return $"{_inchValue} in";
        }
    }
}