using System;

namespace QuantityMeasurementApp.Models
{
    public class Inch
    {
        private readonly double _inchValue;

        public Inch(double value)
        {
            _inchValue = value;
        }

        public double Value
        {
            get { return _inchValue; }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Inch))
                return false;

            Inch comparedInch = (Inch)obj;

            return _inchValue == comparedInch._inchValue;
        }

        public override int GetHashCode()
        {
            return _inchValue.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_inchValue} in";
        }
    }
}