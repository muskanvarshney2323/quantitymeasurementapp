
using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public static class LengthUnitExtensions
    {
        public static double ToFeetFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => 1.0,
                LengthUnit.INCH => 1.0 / 12.0,
                LengthUnit.YARD => 3.0,
                LengthUnit.CENTIMETER => 1.0 / 30.48,
                _ => throw new ArgumentException($"Unsupported unit: {unit}")
            };
        }

        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.ToFeetFactor();
        }

        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return baseValue / unit.ToFeetFactor();
        }

        public static string GetSymbol(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "ft",
                LengthUnit.INCH => "in",
                LengthUnit.YARD => "yd",
                LengthUnit.CENTIMETER => "cm",
                _ => throw new ArgumentException($"Unsupported unit: {unit}")
            };
        }

        public static string GetUnitName(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "feet",
                LengthUnit.INCH => "inches",
                LengthUnit.YARD => "yards",
                LengthUnit.CENTIMETER => "centimeters",
                _ => throw new ArgumentException($"Unsupported unit: {unit}")
            };
        }
    }
}
