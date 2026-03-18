using System;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Extensions;

namespace QuantityMeasurementApp.Models
{
    public class Quantity<U> where U : Enum
    {
        public double Value { get; }
        public U Unit { get; }

        public Quantity(double value, U unit)
        {
            if (!Enum.IsDefined(typeof(U), unit))
                throw new ArgumentException("Invalid unit.", nameof(unit));

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a valid finite number.", nameof(value));

            Value = value;
            Unit = unit;
        }

        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ConvertToBase(Unit, Value);
            double convertedValue = ConvertFromBase(targetUnit, baseValue);
            return new Quantity<U>(convertedValue, targetUnit);
        }

        public Quantity<U> Add(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null");

            double baseValue1 = ConvertToBase(Unit, Value);
            double baseValue2 = ConvertToBase(other.Unit, other.Value);

            double resultBase = baseValue1 + baseValue2;
            double resultValue = ConvertFromBase(Unit, resultBase);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null");

            double baseValue1 = ConvertToBase(Unit, Value);
            double baseValue2 = ConvertToBase(other.Unit, other.Value);

            double resultBase = baseValue1 + baseValue2;
            double resultValue = ConvertFromBase(targetUnit, resultBase);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, targetUnit);
        }

        public Quantity<U> Subtract(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null");

            double baseValue1 = ConvertToBase(Unit, Value);
            double baseValue2 = ConvertToBase(other.Unit, other.Value);

            double resultBase = baseValue1 - baseValue2;
            double resultValue = ConvertFromBase(Unit, resultBase);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, Unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null");

            double baseValue1 = ConvertToBase(Unit, Value);
            double baseValue2 = ConvertToBase(other.Unit, other.Value);

            double resultBase = baseValue1 - baseValue2;
            double resultValue = ConvertFromBase(targetUnit, resultBase);
            resultValue = Math.Round(resultValue, 2);

            return new Quantity<U>(resultValue, targetUnit);
        }

        public double Divide(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null");

            double dividend = ConvertToBase(Unit, Value);
            double divisor = ConvertToBase(other.Unit, other.Value);

            if (divisor == 0)
                throw new ArithmeticException("Cannot divide by zero");

            return dividend / divisor;
        }

        private double ConvertToBase(U currentUnit, double currentValue)
        {
            if (typeof(U) == typeof(LengthUnit))
            {
                var unit = (LengthUnit)(object)currentUnit;
                return unit.ToBaseUnit(currentValue);
            }

            if (typeof(U) == typeof(WeightUnit))
            {
                var unit = (WeightUnit)(object)currentUnit;
                return unit.ToBaseUnit(currentValue);
            }

            if (typeof(U) == typeof(VolumeUnit))
            {
                var unit = (VolumeUnit)(object)currentUnit;
                return unit.ToBaseUnit(currentValue);
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(U).Name}");
        }

        private double ConvertFromBase(U targetUnit, double baseValue)
        {
            if (typeof(U) == typeof(LengthUnit))
            {
                var unit = (LengthUnit)(object)targetUnit;
                return unit.FromBaseUnit(baseValue);
            }

            if (typeof(U) == typeof(WeightUnit))
            {
                var unit = (WeightUnit)(object)targetUnit;
                return unit.FromBaseUnit(baseValue);
            }

            if (typeof(U) == typeof(VolumeUnit))
            {
                var unit = (VolumeUnit)(object)targetUnit;
                return unit.FromBaseUnit(baseValue);
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(U).Name}");
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Quantity<U> other)
                return false;

            double thisBase = ConvertToBase(Unit, Value);
            double otherBase = ConvertToBase(other.Unit, other.Value);

            return Math.Abs(thisBase - otherBase) < 0.0001;
        }

        public override int GetHashCode()
        {
            double baseValue = ConvertToBase(Unit, Value);
            return baseValue.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}