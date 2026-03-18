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
            UnitConvertHelper.ValidateValue(value);
            UnitConvertHelper.ValidateUnit(unit);

            Value = value;
            Unit = unit;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not QuantityWeight other)
            {
                return false;
            }

            double thisBase = UnitConvertHelper.ToBaseUnit(Value, Unit);
            double otherBase = UnitConvertHelper.ToBaseUnit(other.Value, other.Unit);

            return Math.Abs(thisBase - otherBase) < Tolerance;
        }

        public override int GetHashCode()
        {
            double baseValue = UnitConvertHelper.ToBaseUnit(Value, Unit);
            return Math.Round(baseValue, 4).GetHashCode();
        }

        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            UnitConvertHelper.ValidateUnit(targetUnit);

            double baseValue = UnitConvertHelper.ToBaseUnit(Value, Unit);
            double convertedValue = UnitConvertHelper.FromBaseUnit(baseValue, targetUnit);

            return new QuantityWeight(convertedValue, targetUnit);
        }

        public QuantityWeight Add(QuantityWeight other)
        {
            if (other == null)
            {
                throw new ArgumentException("Quantity cannot be null.");
            }

            double thisBase = UnitConvertHelper.ToBaseUnit(Value, Unit);
            double otherBase = UnitConvertHelper.ToBaseUnit(other.Value, other.Unit);

            double resultBase = thisBase + otherBase;
            double resultValue = UnitConvertHelper.FromBaseUnit(resultBase, Unit);

            return new QuantityWeight(resultValue, Unit);
        }

        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
        {
            if (other == null)
            {
                throw new ArgumentException("Quantity cannot be null.");
            }

            UnitConvertHelper.ValidateUnit(targetUnit);

            double thisBase = UnitConvertHelper.ToBaseUnit(Value, Unit);
            double otherBase = UnitConvertHelper.ToBaseUnit(other.Value, other.Unit);

            double resultBase = thisBase + otherBase;
            double resultValue = UnitConvertHelper.FromBaseUnit(resultBase, targetUnit);

            return new QuantityWeight(resultValue, targetUnit);
        }

        public override string ToString()
        {
            return $"QuantityWeight({Value}, {Unit})";
        }
    }
}