using System;

namespace QuantityMeasurementApp.Models
{
    public class Quantity
    {
        public double Value { get; }
        public LengthUnit Unit { get; }

        public Quantity(double value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        // Convert current quantity to feet
        public double ConvertToFeet()
        {
            return Value * Unit.ToFeetFactor();
        }

        // Equality based on feet conversion
        public override bool Equals(object obj)
        {
            if (obj is not Quantity other) return false;
            return Math.Abs(ConvertToFeet() - other.ConvertToFeet()) < 0.0001;
        }

        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value} {Unit.GetSymbol()}";
        }
    }
}