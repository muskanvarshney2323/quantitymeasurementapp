using System;

namespace QuantityMeasurementApp.Domain.Units
{
    /// <summary>
    /// Adapter struct that implements <see cref="IMeasurable"/> for LengthUnit enum.
    /// Allows using LengthUnit through a common interface suitable for generics.
    /// </summary>
    public readonly struct LengthUnitAdapter : IMeasurable
    {
        private readonly LengthUnit _unit;

        public LengthUnitAdapter(LengthUnit unit)
        {
            _unit = unit;
        }

        public double GetConversionFactor() => _unit.GetConversionFactor();
        public double ToBaseUnit(double value) => _unit.ToBaseUnit(value);
        public double FromBaseUnit(double baseValue) => _unit.FromBaseUnit(baseValue);
        public string GetUnitName() => _unit.GetName();
        public string GetSymbol() => _unit.GetSymbol();

        public override string ToString() => _unit.ToString();
    }
}
