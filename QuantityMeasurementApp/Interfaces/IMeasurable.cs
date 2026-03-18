namespace QuantityMeasurementApp.Interfaces
{
    public interface IMeasurable
    {
        double ConvertToBaseUnit(double value);
        double ConvertFromBaseUnit(double value);
    }
}