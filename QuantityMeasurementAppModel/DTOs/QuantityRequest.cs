namespace QuantityMeasurementAppModel.Requests
{
    // This class is used to take input data from UI (Console)
    public class QuantityRequest
    {
        public string? Name { get; set; }       // Name of quantity
        public string? UnitType { get; set; }   // Type (Length, Weight, etc.)
        public double Value { get; set; }       // Numeric value
    }
}