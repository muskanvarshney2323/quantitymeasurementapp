using System;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Extensions
{
    public static class UnitConvertHelper
    {
        public static void ValidateUnit<TUnit>(TUnit unit) where TUnit : struct, Enum
        {
            if (!Enum.IsDefined(typeof(TUnit), unit))
            {
                throw new ArgumentException($"Invalid unit: {unit}");
            }
        }

        public static double ToBaseUnit<TUnit>(double value, TUnit unit) where TUnit : struct, Enum
        {
            ValidateValue(value);
            ValidateUnit(unit);

            if (typeof(TUnit) == typeof(LengthUnit))
            {
                return ((LengthUnit)(object)unit).ToBaseUnit(value);
            }

            if (typeof(TUnit) == typeof(WeightUnit))
            {
                return ((WeightUnit)(object)unit).ToBaseUnit(value);
            }

            if (typeof(TUnit) == typeof(VolumeUnit))
            {
                return ((VolumeUnit)(object)unit).ToBaseUnit(value);
            }

            throw new ArgumentException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static double FromBaseUnit<TUnit>(double baseValue, TUnit unit) where TUnit : struct, Enum
        {
            ValidateValue(baseValue);
            ValidateUnit(unit);

            if (typeof(TUnit) == typeof(LengthUnit))
            {
                return ((LengthUnit)(object)unit).FromBaseUnit(baseValue);
            }

            if (typeof(TUnit) == typeof(WeightUnit))
            {
                return ((WeightUnit)(object)unit).FromBaseUnit(baseValue);
            }

            if (typeof(TUnit) == typeof(VolumeUnit))
            {
                return ((VolumeUnit)(object)unit).FromBaseUnit(baseValue);
            }

            throw new ArgumentException($"Unsupported unit type: {typeof(TUnit).Name}");
        }

        public static void ValidateValue(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Value must be a finite number.");
            }
        }

        public static double RoundToTwoDecimals(double value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}