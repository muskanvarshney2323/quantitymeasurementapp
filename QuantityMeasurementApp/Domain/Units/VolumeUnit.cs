using System;

namespace QuantityMeasurementApp.Domain.Units
{
    /// <summary>
    /// Volume units with conversion helpers. Base unit: litre.
    /// </summary>
    public enum VolumeUnit
    {
        LITRE = 0,
        MILLILITRE = 1,
        GALLON = 2
    }

    public static class VolumeUnitExtensions
    {
        // conversion factors to litres (base)
        private static readonly double[] ToLitreFactors = new double[]
        {
            1.0,       // LITRE -> litre
            0.001,     // MILLILITRE -> litre
            3.78541    // GALLON -> litre (US gallon)
        };

        public static double GetConversionFactor(this VolumeUnit unit)
        {
            int index = (int)unit;
            if (index < 0 || index >= ToLitreFactors.Length)
                throw new QuantityMeasurementApp.Core.Exceptions.InvalidUnitException($"Unsupported unit: {unit}");

            return ToLitreFactors[index];
        }

        public static double ToBaseUnit(this VolumeUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double FromBaseUnit(this VolumeUnit unit, double valueInLitres)
        {
            return valueInLitres / unit.GetConversionFactor();
        }

        public static double ConvertTo(this VolumeUnit sourceUnit, VolumeUnit targetUnit, double value)
        {
            double inLitres = sourceUnit.ToBaseUnit(value);
            return targetUnit.FromBaseUnit(inLitres);
        }

        public static string GetSymbol(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.LITRE => "L",
                VolumeUnit.MILLILITRE => "mL",
                VolumeUnit.GALLON => "gal",
                _ => unit.ToString().ToLower(),
            };
        }

        public static string GetName(this VolumeUnit unit)
        {
            return unit switch
            {
                VolumeUnit.LITRE => "litres",
                VolumeUnit.MILLILITRE => "millilitres",
                VolumeUnit.GALLON => "gallons",
                _ => unit.ToString().ToLower(),
            };
        }
    }
}
