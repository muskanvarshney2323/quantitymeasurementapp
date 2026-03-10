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
            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.ADD);
            double resultInThisUnit = _unit.FromBaseUnit(baseResult);
            double rounded = RoundToTwoDecimals(resultInThisUnit);
            return new QuantityGeneric<U>(rounded, _unit);
        }

        public QuantityGeneric<U> Add(QuantityGeneric<U> other, U targetUnit)
        {
            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.ADD);
            double resultInTarget = targetUnit.FromBaseUnit(baseResult);
            double rounded = RoundToTwoDecimals(resultInTarget);
            return new QuantityGeneric<U>(rounded, targetUnit);
        }

        public QuantityGeneric<U> Subtract(QuantityGeneric<U> other)
        {
            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);
            double resultInThisUnit = _unit.FromBaseUnit(baseResult);
            double rounded = RoundToTwoDecimals(resultInThisUnit);
            return new QuantityGeneric<U>(rounded, _unit);
        }

        public QuantityGeneric<U> Subtract(QuantityGeneric<U> other, U targetUnit)
        {
            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);
            double resultInTarget = targetUnit.FromBaseUnit(baseResult);
            double rounded = RoundToTwoDecimals(resultInTarget);
            return new QuantityGeneric<U>(rounded, targetUnit);
        }

        public double Divide(QuantityGeneric<U> other)
        {
            return PerformBaseArithmetic(other, ArithmeticOperation.DIVIDE);
        }

        private static double RoundToTwoDecimals(double value) => Math.Round(value, 2);

        private enum ArithmeticOperation
        {
            ADD,
            SUBTRACT,
            DIVIDE
        }

        private double PerformBaseArithmetic(QuantityGeneric<U> other, ArithmeticOperation operation)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));

            if (double.IsNaN(_value) || double.IsInfinity(_value) || double.IsNaN(other._value) || double.IsInfinity(other._value))
                throw new ArgumentException("Values must be finite numbers.");

            double baseThis = _unit.ToBaseUnit(_value);
            double baseOther = other._unit.ToBaseUnit(other._value);

            switch (operation)
            {
                case ArithmeticOperation.ADD:
                    return baseThis + baseOther;
                case ArithmeticOperation.SUBTRACT:
                    return baseThis - baseOther;
                case ArithmeticOperation.DIVIDE:
                    if (Math.Abs(baseOther) < Tolerance) throw new ArithmeticException("Division by zero quantity is not allowed.");
                    return baseThis / baseOther;
                default:
                    throw new InvalidOperationException("Unsupported arithmetic operation.");
            }
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
