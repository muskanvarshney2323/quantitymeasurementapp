using System;
using Models = QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Domain.Units
{
    public enum TemperatureUnit
    {
        CELSIUS = 0,
        FAHRENHEIT = 1,
        KELVIN = 2
    }

    public static class TemperatureUnitExtensions
    {
        // Choose Celsius as the internal base unit for temperature conversions
        public static double GetConversionFactor(this TemperatureUnit unit)
        {
            // Not applicable as temperature uses affine transforms; return 1.0 for compatibility
            return 1.0;
        }

        public static double ToBaseUnit(this TemperatureUnit unit, double value)
        {
            return unit switch
            {
                TemperatureUnit.CELSIUS => value,
                TemperatureUnit.FAHRENHEIT => (value - 32.0) * 5.0 / 9.0,
                TemperatureUnit.KELVIN => value - 273.15,
                _ => throw new ArgumentException("Unsupported temperature unit")
            };
        }

        public static double FromBaseUnit(this TemperatureUnit unit, double baseValue)
        {
            return unit switch
            {
                TemperatureUnit.CELSIUS => baseValue,
                TemperatureUnit.FAHRENHEIT => baseValue * 9.0 / 5.0 + 32.0,
                TemperatureUnit.KELVIN => baseValue + 273.15,
                _ => throw new ArgumentException("Unsupported temperature unit")
            };
        }

        public static double ConvertTo(this TemperatureUnit source, TemperatureUnit target, double value)
        {
            double inBase = source.ToBaseUnit(value);
            return target.FromBaseUnit(inBase);
        }

        public static string GetSymbol(this TemperatureUnit unit)
        {
            return unit switch
            {
                TemperatureUnit.CELSIUS => "°C",
                TemperatureUnit.FAHRENHEIT => "°F",
                TemperatureUnit.KELVIN => "K",
                _ => ""
            };
        }

        public static string GetName(this TemperatureUnit unit)
        {
            return unit switch
            {
                TemperatureUnit.CELSIUS => "Celsius",
                TemperatureUnit.FAHRENHEIT => "Fahrenheit",
                TemperatureUnit.KELVIN => "Kelvin",
                _ => "Unknown"
            };
        }
    }
}
