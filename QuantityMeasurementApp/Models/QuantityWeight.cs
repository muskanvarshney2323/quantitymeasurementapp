using System;
using QuantityMeasurementApp.Extensions;

namespace QuantityMeasurementApp.Models
{
    public class Quantity<TUnit> where TUnit : Enum
    {
        private const double Epsilon = 0.0001;

        public double Value { get; }
        public TUnit Unit { get; }

        public Quantity(double value, TUnit unit)
        {
            ValidateUnit(unit);

            Value = value;
            Unit = unit;
        }

        public Quantity<TUnit> ConvertTo(TUnit targetUnit)
        {
            ValidateUnit(targetUnit);

            double baseValue = UnitConversionHelper.ToBaseUnit(Unit, Value);
            double convertedValue = UnitConversionHelper.FromBaseUnit(targetUnit, baseValue);

            return new Quantity<TUnit>(convertedValue, targetUnit);
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

            ValidateUnit(targetUnit);

            double firstBaseValue = UnitConversionHelper.ToBaseUnit(Unit, Value);
            double secondBaseValue = UnitConversionHelper.ToBaseUnit(other.Unit, other.Value);

            double sumBaseValue = firstBaseValue + secondBaseValue;
            double convertedSum = UnitConversionHelper.FromBaseUnit(targetUnit, sumBaseValue);

            return new Quantity<TUnit>(convertedSum, targetUnit);
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

            double firstBaseValue = UnitConversionHelper.ToBaseUnit(Unit, Value);
            double secondBaseValue = UnitConversionHelper.ToBaseUnit(other.Unit, other.Value);

            return Math.Abs(firstBaseValue - secondBaseValue) < Epsilon;
        }

        public override int GetHashCode()
        {
            double baseValue = UnitConversionHelper.ToBaseUnit(Unit, Value);
            return HashCode.Combine(Math.Round(baseValue, 4), typeof(TUnit));
        }

        public override string ToString()
        {
            return $"{Value} {UnitConversionHelper.GetUnitName(Unit)}";
        }

        private static void ValidateUnit(TUnit unit)
        {
            if (!Enum.IsDefined(typeof(TUnit), unit))
            {
                throw new ArgumentException($"Invalid unit: {unit}");
            }
        }
    }
}