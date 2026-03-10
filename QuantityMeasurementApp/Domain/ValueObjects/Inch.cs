using System;
using Models = QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Domain.ValueObjects
{
    public class Inch
    {
        private readonly Models.Inch _inner;

        public Inch(double value)
        {
            _inner = new Models.Inch(value);
        }

        internal Inch(Models.Inch inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public double Value => _inner.Value;

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null) return false;
            if (obj.GetType() != typeof(Inch)) return false;
            Inch other = (Inch)obj;
            return _inner.Equals(other._inner);
        }

        public override int GetHashCode() => _inner.GetHashCode();

        public override string ToString() => _inner.ToString();
    }
}
