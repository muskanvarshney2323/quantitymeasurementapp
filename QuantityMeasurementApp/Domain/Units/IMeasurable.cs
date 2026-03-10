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
        
        // Default method to validate whether an arithmetic operation is supported by the unit.
        // Implementations can override to throw if an operation is not supported (e.g. temperature).
        void ValidateOperationSupport(string operation) { }

        // Query whether a named operation is supported. Default: true for backward compatibility.
        bool SupportsOperation(string operation) => true;
    }
}
