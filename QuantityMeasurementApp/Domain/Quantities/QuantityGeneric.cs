using System;
using QuantityMeasurementApp.Domain.Units;

namespace QuantityMeasurementApp.Domain.Quantities
{
    /// <summary>
    /// Generic, immutable quantity type for any unit adapter implementing IMeasurable.
    /// </summary>
    /// <typeparam name="U">Unit adapter type implementing <see cref="IMeasurable"/>.
    /// Use adapter structs such as <see cref="LengthUnitAdapter"/> or <see cref="WeightUnitAdapter"/>.</typeparam>
    public sealed class QuantityGeneric<U> where U : struct, IMeasurable
    {
        private readonly double _value;
        private readonly U _unit;
        private const double Tolerance = 0.000001;

        public QuantityGeneric(double value, U unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException($"Value must be a valid finite number. Received: {value}");

            _value = value;
            _unit = unit;
        }

        public double Value => _value;
        public U Unit => _unit;

        public QuantityGeneric<U> ConvertTo(U targetUnit)
        {
            double inBase = _unit.ToBaseUnit(_value);
            double converted = targetUnit.FromBaseUnit(inBase);
            return new QuantityGeneric<U>(converted, targetUnit);
        }

        public double ConvertToDouble(U targetUnit) => ConvertTo(targetUnit).Value;

        public QuantityGeneric<U> Add(QuantityGeneric<U> other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            double sumInBase = _unit.ToBaseUnit(_value) + other._unit.ToBaseUnit(other._value);
            double resultInThisUnit = _unit.FromBaseUnit(sumInBase);
            return new QuantityGeneric<U>(resultInThisUnit, _unit);
        }

        public QuantityGeneric<U> Add(QuantityGeneric<U> other, U targetUnit)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            double sumInBase = _unit.ToBaseUnit(_value) + other._unit.ToBaseUnit(other._value);
            double resultInTarget = targetUnit.FromBaseUnit(sumInBase);
            return new QuantityGeneric<U>(resultInTarget, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null) return false;
            if (obj is not QuantityGeneric<U> other) return false;

            double thisBase = _unit.ToBaseUnit(_value);
            double otherBase = other._unit.ToBaseUnit(other._value);
            return Math.Abs(thisBase - otherBase) < Tolerance;
        }

        public override int GetHashCode()
        {
            double baseValue = _unit.ToBaseUnit(_value);
            return Math.Round(baseValue, 6).GetHashCode();
        }

        public override string ToString()
        {
            return $"{_value} {_unit.GetSymbol()}";
        }
    }
}
