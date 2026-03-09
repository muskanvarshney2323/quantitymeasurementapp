using System;
using Models = QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Domain.ValueObjects
{
    public class Feet
    {
        private readonly Models.Feet _inner;

        public Feet(double value)
        {
            _inner = new Models.Feet(value);
        }

        internal Feet(Models.Feet inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public double Value => _inner.Value;

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null) return false;
            if (GetType() != obj.GetType()) return false;
            Feet other = (Feet)obj;
            return _inner.Equals(other._inner);
        }

        public override int GetHashCode() => _inner.GetHashCode();

        public override string ToString() => _inner.ToString();
    }
}
