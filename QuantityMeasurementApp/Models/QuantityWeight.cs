using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Extensions;

namespace QuantityMeasurementApp.Models
{
    public class QuantityWeight
    {
        private const double Tolerance = 0.0001;

        public double Value { get; }
        public WeightUnit Unit { get; }

        public QuantityWeight(double value, WeightUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Weight value cannot be NaN or Infinity.");
            }

            Value = value;
            Unit = unit;
        }

        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            double baseValue = Unit.ToBaseUnit(Value);
            double convertedValue = targetUnit.FromBaseUnit(baseValue);

            return new QuantityWeight(convertedValue, targetUnit);
        }

        public QuantityWeight Add(QuantityWeight other)
        {
            double thisBaseValue = Unit.ToBaseUnit(Value);
            double otherBaseValue = other.Unit.ToBaseUnit(other.Value);

            double totalBaseValue = thisBaseValue + otherBaseValue;
            double resultValue = Unit.FromBaseUnit(totalBaseValue);

            return new QuantityWeight(resultValue, Unit);
        }

        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
        {
            double thisBaseValue = Unit.ToBaseUnit(Value);
            double otherBaseValue = other.Unit.ToBaseUnit(other.Value);

            double totalBaseValue = thisBaseValue + otherBaseValue;
            double resultValue = targetUnit.FromBaseUnit(totalBaseValue);

            return new QuantityWeight(resultValue, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not QuantityWeight other)
                return false;

            double thisBaseValue = Unit.ToBaseUnit(Value);
            double otherBaseValue = other.Unit.ToBaseUnit(other.Value);

            return Math.Abs(thisBaseValue - otherBaseValue) < Tolerance;
        }

        public override int GetHashCode()
        {
            return Unit.ToBaseUnit(Value).GetHashCode();
        }
    }
}