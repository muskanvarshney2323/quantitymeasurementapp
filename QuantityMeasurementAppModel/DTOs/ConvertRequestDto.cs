namespace QuantityMeasurementAppModel.DTOs
{
    public class ConvertRequestDto
    {
        public double Value { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public string QuantityType { get; set; }
    }
}