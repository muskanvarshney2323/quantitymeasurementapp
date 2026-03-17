
using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Extensions
{
    public static class LengthUnitExtensions
    {
        public static double GetConversionFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => 1.0,
                LengthUnit.INCH => 1.0 / 12.0,
                LengthUnit.YARD => 3.0,
                LengthUnit.CENTIMETER => 1.0 / 30.48,
                _ => throw new ArgumentException("Invalid length unit.")
            };
        }

        public static double ToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double FromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        public static string GetUnitName(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => "FEET",
                LengthUnit.INCH => "INCH",
                LengthUnit.YARD => "YARD",
                LengthUnit.CENTIMETER => "CENTIMETER",
                _ => throw new ArgumentException("Invalid length unit.")
            };
        }
    }
}
