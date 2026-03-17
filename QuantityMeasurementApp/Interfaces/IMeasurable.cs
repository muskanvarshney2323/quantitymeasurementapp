namespace QuantityMeasurementApp.Interfaces
{
    public interface IMeasurable
    {
        double GetConversionFactor();
        double ToBaseUnit(double value);
        double FromBaseUnit(double baseValue);
        string GetUnitName();
    }
}