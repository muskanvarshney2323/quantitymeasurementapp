using System;

namespace QuantityMeasurementAppModel
{
    public class QuantityMeasurementEntity
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OperationType { get; set; }

        public double? FirstValue { get; set; }
        public string? FirstUnit { get; set; }

        public double? SecondValue { get; set; }
        public string? SecondUnit { get; set; }

        public double? ResultValue { get; set; }
        public string? ResultUnit { get; set; }

        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
    }
}