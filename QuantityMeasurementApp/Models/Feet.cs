using System;

namespace QuantityMeasurementApp.Models
{
    // This class models a measurement expressed in feet
    // It follows immutability, meaning its value cannot be modified after creation
    public class Feet
    {
        // Stores the measurement internally
        // Declared as readonly to prevent reassignment
        private readonly double _value;

        // Initializes the Feet object with a specific measurement
        // value: measurement in feet
        public Feet(double value)
        {
            _value = value;
        }

        // Exposes the measurement value in a read-only manner
        public double Value => _value;

        // Compares the current instance with another object for equality
        // Equality is based on the stored measurement value
        // obj: object to be compared
        public override bool Equals(object? obj)
        {
            // If both references point to the same object, they are equal
            if (ReferenceEquals(this, obj))
                return true;

            // If the compared object is null, equality fails
            if (obj is null)
                return false;

            // Ensure both objects belong to the same class
            if (GetType() != obj.GetType())
                return false;

            // Cast is safe after type validation
            Feet other = (Feet)obj;

            // Direct comparison of measurement values
            // Exact comparison is required for precise validation
            return _value == other._value;
        }

        // Generates a hash code for the object
        // Objects with identical values must return identical hash codes
        public override int GetHashCode()
        {
            // Utilize the hash code implementation of double
            return _value.GetHashCode();
        }

        // Converts the object into a readable string format
        // Example output: "2 ft"
        public override string ToString()
        {
            return $"{_value} ft";
        }
    }
}