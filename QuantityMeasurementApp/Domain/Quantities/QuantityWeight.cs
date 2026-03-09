using System;
using QuantityMeasurementApp.Domain.Units;
using QuantityMeasurementApp.Core.Exceptions;

namespace QuantityMeasurementApp.Domain.Quantities
{
    /// <summary>
    /// Immutable weight quantity measured in WeightUnit (base unit: kilogram).
    /// </summary>
    public class QuantityWeight
    {
        private readonly double _value;
        private readonly WeightUnit _unit;

        private const double Tolerance = 0.000001;

        public QuantityWeight(double value, WeightUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new InvalidValueException($"Value must be a valid finite number. Received: {value}");

            if (!Enum.IsDefined(typeof(WeightUnit), unit))
                throw new InvalidUnitException($"Unsupported unit: {unit}");

            _value = value;
            _unit = unit;
        }

        public double Value => _value;

        public WeightUnit Unit => _unit;

        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            if (!Enum.IsDefined(typeof(WeightUnit), targetUnit))
                throw new InvalidUnitException($"Unsupported unit: {targetUnit}");

            double inKg = _unit.ToBaseUnit(_value);
            double converted = targetUnit.FromBaseUnit(inKg);
            return new QuantityWeight(converted, targetUnit);
        }

        public double ConvertToDouble(WeightUnit targetUnit)
        {
            return ConvertTo(targetUnit).Value;
        }

        public QuantityWeight Add(QuantityWeight other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            double sumInKg = _unit.ToBaseUnit(_value) + other._unit.ToBaseUnit(other._value);
            double resultInThisUnit = _unit.FromBaseUnit(sumInKg);
            return new QuantityWeight(resultInThisUnit, _unit);
        }

        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!Enum.IsDefined(typeof(WeightUnit), targetUnit))
                throw new InvalidUnitException($"Unsupported unit: {targetUnit}");

            double sumInKg = _unit.ToBaseUnit(_value) + other._unit.ToBaseUnit(other._value);
            double resultInTarget = targetUnit.FromBaseUnit(sumInKg);
            return new QuantityWeight(resultInTarget, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null) return false;
            if (GetType() != obj.GetType()) return false;

            var other = (QuantityWeight)obj;
            double thisKg = _unit.ToBaseUnit(_value);
            double otherKg = other._unit.ToBaseUnit(other._value);
            return Math.Abs(thisKg - otherKg) < Tolerance;
        }

        public override int GetHashCode()
        {
            double valueInKg = _unit.ToBaseUnit(_value);
            return Math.Round(valueInKg, 6).GetHashCode();
        }

        public override string ToString()
        {
            return $"{_value} {_unit.GetSymbol()}";
        }
    }
}
