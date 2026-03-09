using System;

namespace QuantityMeasurementApp.Domain.Units
{
    /// <summary>
    /// Abstraction for unit types that can convert to/from a category base unit.
    /// Implemented by adapter structs that wrap underlying enum values.
    /// </summary>
    public interface IMeasurable
    {
        double GetConversionFactor();
        double ToBaseUnit(double value);
        double FromBaseUnit(double baseValue);
        string GetUnitName();
        string GetSymbol();
    }
}
