using System;

namespace QuantityMeasurementApp.Models
{
    public class Quantity
    {
        public double Value { get; }
        public LengthUnit Unit { get; }

        public Quantity(double value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            Quantity sourceQuantity = new Quantity(value, sourceUnit);
            Quantity convertedQuantity = sourceQuantity.ConvertTo(targetUnit);
            return convertedQuantity.Value;
        }

        public Quantity ConvertTo(LengthUnit targetUnit)
        {
            double valueInFeet = Unit switch
            {
                LengthUnit.FEET => Value,
                LengthUnit.INCH => Value / 12.0,
                LengthUnit.YARD => Value * 3.0,
                LengthUnit.CENTIMETER => Value / 30.48,
                _ => throw new ArgumentException("Invalid source unit")
            };

            double convertedValue = targetUnit switch
            {
                LengthUnit.FEET => valueInFeet,
                LengthUnit.INCH => valueInFeet * 12.0,
                LengthUnit.YARD => valueInFeet / 3.0,
                LengthUnit.CENTIMETER => valueInFeet * 30.48,
                _ => throw new ArgumentException("Invalid target unit")
            };

            return new Quantity(convertedValue, targetUnit);
        }

        public Quantity Add(Quantity other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Quantity convertedOther = other.ConvertTo(Unit);
            return new Quantity(Value + convertedOther.Value, Unit);
        }

        public Quantity Add(Quantity other, LengthUnit resultUnit)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            Quantity first = ConvertTo(resultUnit);
            Quantity second = other.ConvertTo(resultUnit);

            return new Quantity(first.Value + second.Value, resultUnit);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Quantity other)
                return false;

            Quantity convertedOther = other.ConvertTo(Unit);

            // stricter precision so tiny differences are treated as different
            return Math.Abs(Value - convertedOther.Value) < 0.0000001;
        }

        public override int GetHashCode()
        {
            // normalize everything to feet so equivalent quantities get same hash
            double normalizedFeet = ConvertTo(LengthUnit.FEET).Value;
            return Math.Round(normalizedFeet, 7).GetHashCode();
        }

        public override string ToString()
        {
            string symbol = Unit switch
            {
                LengthUnit.FEET => "ft",
                LengthUnit.INCH => "in",
                LengthUnit.YARD => "yd",
                LengthUnit.CENTIMETER => "cm",
                _ => Unit.ToString()
            };

            return $"{Value} {symbol}";
        }
    }
}