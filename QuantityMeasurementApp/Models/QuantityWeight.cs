using System;
using QuantityMeasurementApp.Extensions;

namespace QuantityMeasurementApp.Models
{
    public class Quantity<TUnit> where TUnit : struct, Enum
    {
        private const double Precision = 0.0001;

        public double Value { get; }
        public TUnit Unit { get; }

        public Quantity(double value, TUnit unit)
        {
            unit.ValidateUnit();

            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Value must be a finite number.");
            }

            Value = value;
            Unit = unit;
        }

        public Quantity<TUnit> ConvertTo(TUnit targetUnit)
        {
            targetUnit.ValidateUnit();

            double baseValue = Unit.ToBaseUnit(Value);
            double convertedValue = targetUnit.FromBaseUnit(baseValue);

            return new Quantity<TUnit>(Math.Round(convertedValue, 2), targetUnit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other)
        {
            return Add(other, Unit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other, TUnit targetUnit)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            targetUnit.ValidateUnit();

            double thisBaseValue = Unit.ToBaseUnit(Value);
            double otherBaseValue = other.Unit.ToBaseUnit(other.Value);
            double totalBaseValue = thisBaseValue + otherBaseValue;
            double resultValue = targetUnit.FromBaseUnit(totalBaseValue);

            return new Quantity<TUnit>(Math.Round(resultValue, 2), targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Quantity<TUnit> other)
            {
                return false;
            }

            if (Unit.GetType() != other.Unit.GetType())
            {
                return false;
            }

            double thisBaseValue = Unit.ToBaseUnit(Value);
            double otherBaseValue = other.Unit.ToBaseUnit(other.Value);

            return Math.Abs(thisBaseValue - otherBaseValue) < Precision;
        }

        public override int GetHashCode()
        {
            double normalizedBaseValue = Math.Round(Unit.ToBaseUnit(Value), 4);
            return HashCode.Combine(normalizedBaseValue, typeof(TUnit));
        }

        public override string ToString()
        {
            return $"Quantity(Value={Value}, Unit={Unit.GetUnitName()})";
        }
    }
}