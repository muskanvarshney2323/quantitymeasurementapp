using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Extensions
{
    public static class UnitConversionHelper
    {
        public static double ToBaseUnit<TUnit>(TUnit unit, double value) where TUnit : Enum
        {
            object unitObject = unit!;

            if (unitObject is LengthUnit lengthUnit)
            {
                return lengthUnit.ToBaseUnit(value);
            }

            if (unitObject is WeightUnit weightUnit)
            {
                return weightUnit.ToBaseUnit(value);
            }

            if (unitObject is VolumeUnit volumeUnit)
            {
                return volumeUnit.ToBaseUnit(value);
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static double FromBaseUnit<TUnit>(TUnit unit, double baseValue) where TUnit : Enum
        {
            object unitObject = unit!;

            if (unitObject is LengthUnit lengthUnit)
            {
                return lengthUnit.FromBaseUnit(baseValue);
            }

            if (unitObject is WeightUnit weightUnit)
            {
                return weightUnit.FromBaseUnit(baseValue);
            }

            if (unitObject is VolumeUnit volumeUnit)
            {
                return volumeUnit.FromBaseUnit(baseValue);
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static string GetUnitName<TUnit>(TUnit unit) where TUnit : Enum
        {
            object unitObject = unit!;

            if (unitObject is LengthUnit lengthUnit)
            {
                return lengthUnit.GetUnitName();
            }

            if (unitObject is WeightUnit weightUnit)
            {
                return weightUnit.GetUnitName();
            }

            if (unitObject is VolumeUnit volumeUnit)
            {
                return volumeUnit.GetUnitName();
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(TUnit).Name}");
        }
    }
}