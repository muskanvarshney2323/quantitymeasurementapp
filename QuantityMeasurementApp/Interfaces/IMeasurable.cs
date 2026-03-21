namespace QuantityMeasurementApp.Common
{
    public interface IMeasurable
    {
        double ToBaseUnit(double value);
        double FromBaseUnit(double baseValue);
        string GetUnitName();

        bool SupportsArithmetic()
        {
            return true;
        }

        void ValidateOperationSupport(string operation)
        {
            // By default all existing units support arithmetic
        }
    }
}