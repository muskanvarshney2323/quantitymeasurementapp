using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Common
{
    public static class TemperatureScaleExtensions
    {
        public static double ToBaseUnit(this TemperatureScale unit, double value)
        {
            return unit switch
            {
                TemperatureScale.CELSIUS => value,
                TemperatureScale.FAHRENHEIT => (value - 32) * 5.0 / 9.0,
                TemperatureScale.KELVIN => value - 273.15,
                _ => throw new ArgumentException("Invalid unit provided.")
            };
        }

        public static double FromBaseUnit(this TemperatureScale unit, double baseValue)
        {
            return unit switch
            {
                TemperatureScale.CELSIUS => baseValue,
                TemperatureScale.FAHRENHEIT => (baseValue * 9.0 / 5.0) + 32,
                TemperatureScale.KELVIN => baseValue + 273.15,
                _ => throw new ArgumentException("Invalid unit provided.")
            };
        }

        public static string GetUnitName(this TemperatureScale unit)
        {
            return unit switch
            {
                TemperatureScale.CELSIUS => "Celsius",
                TemperatureScale.FAHRENHEIT => "Fahrenheit",
                TemperatureScale.KELVIN => "Kelvin",
                _ => throw new ArgumentException("Invalid unit provided.")
            };
        }

        public static bool SupportsArithmetic(this TemperatureScale unit)
        {
            return false;
        }

        public static void ValidateOperationSupport(this TemperatureScale unit, string operation)
        {
            throw new InvalidOperationException(
                $"Temperature does not support {operation.ToLower()} operation.");
        }
    }
}