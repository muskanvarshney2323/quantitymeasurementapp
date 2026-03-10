using System;
using Models = QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Domain.Units
{
    // Enum mirrors the underlying Models.LengthUnit so tests can reference this namespace.
    public enum LengthUnit
    {
        FEET = 0,
        INCH = 1,
        YARD = 2,
        CENTIMETER = 3
    }

    public static class LengthUnitExtensions
    {
        private static Models.UnitConverter Converter => new Models.UnitConverter();

        public static double GetConversionFactor(this LengthUnit unit)
        {
            try
            {
                return Converter.GetConversionFactorToFeet((Models.LengthUnit)unit);
            }
            catch (ArgumentException ex)
            {
                throw new QuantityMeasurementApp.Core.Exceptions.InvalidUnitException(ex.Message, ex);
            }
        }

        public static double ToBaseUnit(this LengthUnit unit, double value)
        {
            return value * unit.GetConversionFactor();
        }

        public static double FromBaseUnit(this LengthUnit unit, double valueInBase)
        {
            return valueInBase / unit.GetConversionFactor();
        }

        public static double ConvertTo(this LengthUnit sourceUnit, LengthUnit targetUnit, double value)
        {
            double inBase = sourceUnit.ToBaseUnit(value);
            return targetUnit.FromBaseUnit(inBase);
        }

        public static string GetSymbol(this LengthUnit unit)
        {
            return Models.LengthUnitExtensions.GetUnitSymbol((Models.LengthUnit)unit);
        }

        public static string GetName(this LengthUnit unit)
        {
            return Models.LengthUnitExtensions.GetUnitName((Models.LengthUnit)unit);
        }
    }
}
