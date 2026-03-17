using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Extensions
{
    public static class WeightUnitExtensions
    {
        public static double ToKilogramFactor(this WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.KILOGRAM => 1.0,
                WeightUnit.GRAM => 0.001,
                WeightUnit.POUND => 0.453592,
                _ => throw new ArgumentException("Invalid weight unit")
            };
        }

        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.ToKilogramFactor();
        }

        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return baseValue / unit.ToKilogramFactor();
        }

        public static double ToBaseUnit(this WeightUnit unit, double value)
        {
            return unit.ConvertToBaseUnit(value);
        }

        public static double FromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return unit.ConvertFromBaseUnit(baseValue);
        }
    }
}