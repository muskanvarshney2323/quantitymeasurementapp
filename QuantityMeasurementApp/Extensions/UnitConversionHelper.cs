using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Extensions
{
    public static class UnitConversionHelper
    {
        public static double ToBaseUnit<TUnit>(this TUnit unit, double value) where TUnit : struct, Enum
        {
            if (typeof(TUnit) == typeof(LengthUnit))
            {
                LengthUnit lengthUnit = (LengthUnit)(object)unit;
                return lengthUnit.ToBaseUnit(value);
            }

            if (typeof(TUnit) == typeof(WeightUnit))
            {
                WeightUnit weightUnit = (WeightUnit)(object)unit;
                return weightUnit.ToBaseUnit(value);
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static double FromBaseUnit<TUnit>(this TUnit unit, double baseValue) where TUnit : struct, Enum
        {
            if (typeof(TUnit) == typeof(LengthUnit))
            {
                LengthUnit lengthUnit = (LengthUnit)(object)unit;
                return lengthUnit.FromBaseUnit(baseValue);
            }

            if (typeof(TUnit) == typeof(WeightUnit))
            {
                WeightUnit weightUnit = (WeightUnit)(object)unit;
                return weightUnit.FromBaseUnit(baseValue);
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static string GetUnitName<TUnit>(this TUnit unit) where TUnit : struct, Enum
        {
            if (typeof(TUnit) == typeof(LengthUnit))
            {
                LengthUnit lengthUnit = (LengthUnit)(object)unit;
                return lengthUnit.GetUnitName();
            }

            if (typeof(TUnit) == typeof(WeightUnit))
            {
                WeightUnit weightUnit = (WeightUnit)(object)unit;
                return weightUnit.GetUnitName();
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static double GetConversionFactor<TUnit>(this TUnit unit) where TUnit : struct, Enum
        {
            if (typeof(TUnit) == typeof(LengthUnit))
            {
                LengthUnit lengthUnit = (LengthUnit)(object)unit;
                return lengthUnit.GetConversionFactor();
            }

            if (typeof(TUnit) == typeof(WeightUnit))
            {
                WeightUnit weightUnit = (WeightUnit)(object)unit;
                return weightUnit.GetConversionFactor();
            }

            throw new InvalidOperationException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static void ValidateUnit<TUnit>(this TUnit unit) where TUnit : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TUnit), unit))
            {
                throw new ArgumentException($"Invalid unit value for {typeof(TUnit).Name}");
            }
        }
    }
}