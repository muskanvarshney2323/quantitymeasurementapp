using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.Entities;
using QuantityMeasurementAppRepositoryLayer.Interfaces;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _repository;

        public QuantityMeasurementService(IQuantityMeasurementRepository repository)
        {
            _repository = repository;
        }

        public string Add(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            double result = value1 + value2;

            var record = CreateRecord("Addition", value1, unit1, value2, unit2, quantityType, result, unit1, $"{result} {unit1}");
            _repository.SaveMeasurementRecord(record);

            return $"{result} {unit1}";
        }

        public string Subtract(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            double result = value1 - value2;

            var record = CreateRecord("Subtraction", value1, unit1, value2, unit2, quantityType, result, unit1, $"{result} {unit1}");
            _repository.SaveMeasurementRecord(record);

            return $"{result} {unit1}";
        }

        public string Compare(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            string result;

            if (value1 > value2)
                result = "First value is greater";
            else if (value1 < value2)
                result = "Second value is greater";
            else
                result = "Both values are equal";

            var record = CreateRecord("Comparison", value1, unit1, value2, unit2, quantityType, null, null, result);
            _repository.SaveMeasurementRecord(record);

            return result;
        }

        public string Divide(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            if (value2 == 0)
            {
                throw new Exception("Cannot divide by zero");
            }

            double result = value1 / value2;

            var record = CreateRecord("Division", value1, unit1, value2, unit2, quantityType, result, null, result.ToString());
            _repository.SaveMeasurementRecord(record);

            return result.ToString();
        }

        public string Convert(double value, string fromUnit, string toUnit, string quantityType)
        {
            double convertedValue = value;

            if (quantityType.ToLower() == "length")
            {
                if (fromUnit.ToLower() == "feet" && toUnit.ToLower() == "inch")
                    convertedValue = value * 12;
                else if (fromUnit.ToLower() == "inch" && toUnit.ToLower() == "feet")
                    convertedValue = value / 12;
                else if (fromUnit.ToLower() == "yard" && toUnit.ToLower() == "feet")
                    convertedValue = value * 3;
                else if (fromUnit.ToLower() == "feet" && toUnit.ToLower() == "yard")
                    convertedValue = value / 3;
                else if (fromUnit.ToLower() == "inch" && toUnit.ToLower() == "cm")
                    convertedValue = value * 2.54;
                else if (fromUnit.ToLower() == "cm" && toUnit.ToLower() == "inch")
                    convertedValue = value / 2.54;
            }
            else if (quantityType.ToLower() == "weight")
            {
                if (fromUnit.ToLower() == "kg" && toUnit.ToLower() == "gram")
                    convertedValue = value * 1000;
                else if (fromUnit.ToLower() == "gram" && toUnit.ToLower() == "kg")
                    convertedValue = value / 1000;
                else if (fromUnit.ToLower() == "tonne" && toUnit.ToLower() == "kg")
                    convertedValue = value * 1000;
                else if (fromUnit.ToLower() == "kg" && toUnit.ToLower() == "tonne")
                    convertedValue = value / 1000;
            }
            else if (quantityType.ToLower() == "temperature")
            {
                if (fromUnit.ToLower() == "celsius" && toUnit.ToLower() == "fahrenheit")
                    convertedValue = (value * 9 / 5) + 32;
                else if (fromUnit.ToLower() == "fahrenheit" && toUnit.ToLower() == "celsius")
                    convertedValue = (value - 32) * 5 / 9;
            }

            var output = $"{convertedValue} {toUnit}";

            var record = new MeasurementRecord
            {
                Timestamp = DateTime.UtcNow,
                Operation = "Conversion",
                OriginalValue = value,
                OriginalUnit = fromUnit,
                OriginalType = quantityType,
                DesiredUnit = toUnit,
                OutputValue = convertedValue,
                OutputUnit = toUnit,
                OutputText = output,
                SuccessFlag = true
            };

            _repository.SaveMeasurementRecord(record);

            return output;
        }

        public List<MeasurementRecord> GetHistory()
        {
            return _repository.GetAllRecords();
        }

        public int GetCount()
        {
            return _repository.GetRecordCount();
        }

        public List<string> GetOperationTypes()
        {
            return new List<string>
            {
                "Addition",
                "Subtraction",
                "Comparison",
                "Division",
                "Conversion"
            };
        }

        public List<string> GetMeasurementTypes()
        {
            return new List<string>
            {
                "Length",
                "Weight",
                "Temperature"
            };
        }

        private MeasurementRecord CreateRecord(
            string operation,
            double value1,
            string unit1,
            double value2,
            string unit2,
            string quantityType,
            double? outputValue,
            string? outputUnit,
            string outputText)
        {
            return new MeasurementRecord
            {
                Timestamp = DateTime.UtcNow,
                Operation = operation,
                Input1Value = value1,
                Input1Unit = unit1,
                Input1Type = quantityType,
                Input2Value = value2,
                Input2Unit = unit2,
                Input2Type = quantityType,
                OutputValue = outputValue,
                OutputUnit = outputUnit,
                OutputText = outputText,
                SuccessFlag = true
            };
        }
    }
}