namespace QuantityMeasurementAppModel.DTOs
{
    public class AddRequestDto
    {
        public double Value1 { get; set; }
        public string Unit1 { get; set; }
        public double Value2 { get; set; }
        public string Unit2 { get; set; }
        public string QuantityType { get; set; }
    }
}