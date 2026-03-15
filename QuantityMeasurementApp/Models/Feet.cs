using System;

namespace QuantityMeasurementApp.Models
{
    // Represents a length measured in feet
    public class Feet
    {
        // Internal storage of the measurement
        private readonly double _feetValue;

        // Constructor
        public Feet(double value)
        {
            _feetValue = value;
        }

        // Public read-only property
        public double Value
        {
            get { return _feetValue; }
        }

        // Equality comparison
        public override bool Equals(object? obj)
        {
            if (obj is not Feet otherFeet)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            double difference = Math.Abs(_feetValue - otherFeet._feetValue);

            return difference < 0.0001;
        }

        // Hash generation
        public override int GetHashCode()
        {
            return HashCode.Combine(_feetValue);
        }

        // Readable output
        public override string ToString()
        {
            return $"{_feetValue} ft";
        }
    }
}