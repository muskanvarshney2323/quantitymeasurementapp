using System;

namespace QuantityMeasurementApp.Domain.Units
{
    /// <summary>
    /// Adapter struct that implements <see cref="IMeasurable"/> for TemperatureUnit enum.
    /// Temperature disallows certain arithmetic operations; adapter validates accordingly.
    /// </summary>
    public readonly struct TemperatureUnitAdapter : IMeasurable
    {
        private readonly TemperatureUnit _unit;

        public TemperatureUnitAdapter(TemperatureUnit unit)
        {
            _unit = unit;
        }

        public double GetConversionFactor() => _unit.GetConversionFactor();
        public double ToBaseUnit(double value) => _unit.ToBaseUnit(value);
        public double FromBaseUnit(double baseValue) => _unit.FromBaseUnit(baseValue);
        public string GetUnitName() => _unit.GetName();
        public string GetSymbol() => _unit.GetSymbol();

        // Temperature units do not support some arithmetic operations on absolute values.
        public void ValidateOperationSupport(string operation)
        {
            // Disallow addition of two absolute temperatures and division
            if (string.Equals(operation, "ADD", StringComparison.OrdinalIgnoreCase)
                || string.Equals(operation, "DIVIDE", StringComparison.OrdinalIgnoreCase))
            {
                throw new NotSupportedException("Arithmetic operation not supported for temperature absolute values.");
            }
        }

        public override string ToString() => _unit.ToString();
    }
}
