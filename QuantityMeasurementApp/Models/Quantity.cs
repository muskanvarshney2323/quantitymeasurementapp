
using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public class Quantity
    {
        private const double Epsilon = 0.0000001;

        public double Value { get; }
        public LengthUnit Unit { get; }

        public Quantity(double value, LengthUnit unit)
        {
            ValidateValue(value);
            ValidateUnit(unit);

            Value = value;
            Unit = unit;
        }

        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            ValidateValue(value);
            ValidateUnit(sourceUnit);
            ValidateUnit(targetUnit);

            Quantity sourceQuantity = new Quantity(value, sourceUnit);
            Quantity convertedQuantity = sourceQuantity.ConvertTo(targetUnit);

            return convertedQuantity.Value;
        }

        public Quantity ConvertTo(LengthUnit targetUnit)
        {
            ValidateUnit(targetUnit);

            double valueInFeet = Unit.ConvertToBaseUnit(Value);
            double convertedValue = targetUnit.ConvertFromBaseUnit(valueInFeet);

            return new Quantity(convertedValue, targetUnit);
        }

        public Quantity Add(Quantity other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            double firstInFeet = Unit.ConvertToBaseUnit(Value);
            double secondInFeet = other.Unit.ConvertToBaseUnit(other.Value);
            double totalInFeet = firstInFeet + secondInFeet;

            double resultValue = Unit.ConvertFromBaseUnit(totalInFeet);
            return new Quantity(resultValue, Unit);
        }

        public Quantity Add(Quantity other, LengthUnit resultUnit)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            ValidateUnit(resultUnit);

            double firstInFeet = Unit.ConvertToBaseUnit(Value);
            double secondInFeet = other.Unit.ConvertToBaseUnit(other.Value);
            double totalInFeet = firstInFeet + secondInFeet;

            double resultValue = resultUnit.ConvertFromBaseUnit(totalInFeet);
            return new Quantity(resultValue, resultUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Quantity other)
                return false;

            double thisInFeet = Unit.ConvertToBaseUnit(Value);
            double otherInFeet = other.Unit.ConvertToBaseUnit(other.Value);

            return Math.Abs(thisInFeet - otherInFeet) < Epsilon;
        }

        public override int GetHashCode()
        {
            double normalizedFeet = Unit.ConvertToBaseUnit(Value);
            return Math.Round(normalizedFeet, 7).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value} {Unit.GetSymbol()}";
        }

        private static void ValidateUnit(LengthUnit unit)
        {
            if (!Enum.IsDefined(typeof(LengthUnit), unit))
                throw new ArgumentException($"Unsupported unit: {unit}");
        }

        private static void ValidateValue(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException($"Value must be a valid finite number. Received: {value}");
        }
    }
}