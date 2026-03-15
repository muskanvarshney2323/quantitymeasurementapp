using System;

namespace QuantityMeasurementApp.Models
{
    public class Quantity
    {
        private readonly double _value;
        private readonly LengthUnit _unit;

        public Quantity(double value, LengthUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        public double Value => _value;
        public LengthUnit Unit => _unit;

        private double ConvertToFeet()
        {
            return _value * _unit.ToFeetFactor();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            Quantity other = (Quantity)obj;
            return ConvertToFeet() == other.ConvertToFeet();
        }

        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }

        public override string ToString()
        {
            return $"{_value} {_unit.Symbol()}";
        }
    }
}