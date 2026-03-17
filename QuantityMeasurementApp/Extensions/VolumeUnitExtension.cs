using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Extensions
{
    public static class VolumeUnitExtension
    {
        public static double GetConversionFactor(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.LITRE => 1.0,
                VolumeUnit.MILLILITRE => 0.001,
                VolumeUnit.GALLON => 3.78541,
                _ => throw new ArgumentException("Invalid volume unit.")
            };
        }

        public static double ToBaseUnit(this VolumeUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double FromBaseUnit(this VolumeUnit unit, double baseValue)
        {
            return baseValue / unit.GetConversionFactor();
        }

        public static string GetSymbol(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.LITRE => "L",
                VolumeUnit.MILLILITRE => "mL",
                VolumeUnit.GALLON => "gal",
                _ => throw new ArgumentException("Invalid volume unit.")
            };
        }
    }
}