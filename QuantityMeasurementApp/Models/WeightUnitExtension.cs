
using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Extensions
{
    public static class WeightUnitExtensions
    {
        public static double GetConversionFactor(this WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.GRAM => 1.0,
                WeightUnit.KILOGRAM => 1000.0,
                WeightUnit.TONNE => 1000000.0,
                _ => throw new ArgumentException("Invalid weight unit.")
            };
        }

        public static double ToBaseUnit(this WeightUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double FromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        public static string GetUnitName(this WeightUnit unit)
        {
            return unit switch
            {
                WeightUnit.GRAM => "GRAM",
                WeightUnit.KILOGRAM => "KILOGRAM",
                WeightUnit.TONNE => "TONNE",
                _ => throw new ArgumentException("Invalid weight unit.")
            };
        }
    }
}
