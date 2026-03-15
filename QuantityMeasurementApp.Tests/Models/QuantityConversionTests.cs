using System;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Enum for supported length units.
    /// </summary>
    public enum LengthUnit
    {
        FEET,
        INCH,
        YARD,
        CENTIMETER
    }

    /// <summary>
    /// Represents a quantity with value and unit, supports conversions.
    /// </summary>
    public class Quantity
    {
        public double Value { get; set; }
        public LengthUnit Unit { get; set; }

        public Quantity(double value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Static method to convert between any supported units.
        /// </summary>
        public static double Convert(double value, LengthUnit from, LengthUnit to)
        {
            // Validate value
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a finite number");

            // Convert from source unit to base unit (inches)
            double valueInInches = from switch
            {
                LengthUnit.INCH => value,
                LengthUnit.FEET => value * 12.0,
                LengthUnit.YARD => value * 36.0,
                LengthUnit.CENTIMETER => value * 0.393700787, // 1 cm = 0.3937 inch
                _ => throw new ArgumentException("Invalid source unit")
            };

            // Convert from base unit (inches) to target unit
            double convertedValue = to switch
            {
                LengthUnit.INCH => valueInInches,
                LengthUnit.FEET => valueInInches / 12.0,
                LengthUnit.YARD => valueInInches / 36.0,
                LengthUnit.CENTIMETER => valueInInches / 0.393700787,
                _ => throw new ArgumentException("Invalid target unit")
            };

            return convertedValue;
        }

        /// <summary>
        /// Instance method to convert this Quantity to another unit.
        /// </summary>
        public Quantity ConvertTo(LengthUnit targetUnit)
        {
            double convertedValue = Convert(this.Value, this.Unit, targetUnit);
            return new Quantity(convertedValue, targetUnit);
        }
    }
}