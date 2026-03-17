using System;
using QuantityMeasurementApp.Extensions;

namespace QuantityMeasurementApp
{
    public class Quantity<TUnit> where TUnit : struct, Enum
    {
        private const double Tolerance = 0.0001;

        public double Value { get; }
        public TUnit Unit { get; }

        public Quantity(double value, TUnit unit)
        {
            UnitConvertHelper.ValidateValue(value);
            UnitConvertHelper.ValidateUnit(unit);

            Value = value;
            Unit = unit;
        }

        public Quantity<TUnit> ConvertTo(TUnit targetUnit)
        {
            UnitConvertHelper.ValidateUnit(targetUnit);

            double baseValue = UnitConvertHelper.ToBaseUnit(Value, Unit);
            double convertedValue = UnitConvertHelper.FromBaseUnit(baseValue, targetUnit);

            return new Quantity<TUnit>(convertedValue, targetUnit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other)
        {
            return Add(other, Unit);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> other, TUnit targetUnit)
        {
            ValidateOtherQuantity(other);
            UnitConvertHelper.ValidateUnit(targetUnit);

            double thisBase = UnitConvertHelper.ToBaseUnit(Value, Unit);
            double otherBase = UnitConvertHelper.ToBaseUnit(other.Value, other.Unit);

            double resultBase = thisBase + otherBase;
            double resultValue = UnitConvertHelper.FromBaseUnit(resultBase, targetUnit);
            resultValue = UnitConvertHelper.RoundToTwoDecimals(resultValue);

            return new Quantity<TUnit>(resultValue, targetUnit);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> other)
        {
            return Subtract(other, Unit);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> other, TUnit targetUnit)
        {
            ValidateOtherQuantity(other);
            UnitConvertHelper.ValidateUnit(targetUnit);

            double thisBase = UnitConvertHelper.ToBaseUnit(Value, Unit);
            double otherBase = UnitConvertHelper.ToBaseUnit(other.Value, other.Unit);

            double resultBase = thisBase - otherBase;
            double resultValue = UnitConvertHelper.FromBaseUnit(resultBase, targetUnit);
            resultValue = UnitConvertHelper.RoundToTwoDecimals(resultValue);

            return new Quantity<TUnit>(resultValue, targetUnit);
        }

        public double Divide(Quantity<TUnit> other)
        {
            ValidateOtherQuantity(other);

            double divisorBase = UnitConvertHelper.ToBaseUnit(other.Value, other.Unit);
            if (Math.Abs(divisorBase) < Tolerance)
            {
                throw new ArithmeticException("Cannot divide by zero quantity.");
            }

            double thisBase = UnitConvertHelper.ToBaseUnit(Value, Unit);
            return thisBase / divisorBase;
        }

        private static void ValidateOtherQuantity(Quantity<TUnit> other)
        {
            if (other == null)
            {
                throw new ArgumentException("Quantity cannot be null.");
            }

            UnitConvertHelper.ValidateValue(other.Value);
            UnitConvertHelper.ValidateUnit(other.Unit);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Quantity<TUnit> other)
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
            return HashCode.Combine(Unit.GetType(), Math.Round(baseValue, 4));
        }

        public override string ToString()
        {
            return $"Quantity({Value}, {Unit})";
        }
    }
}