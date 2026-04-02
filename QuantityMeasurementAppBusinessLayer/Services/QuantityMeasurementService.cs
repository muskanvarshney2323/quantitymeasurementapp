using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.Entities;
using QuantityMeasurementAppModel.Enums;
using QuantityMeasurementAppRepositoryLayer.Interfaces;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _quantityRepository;

        public QuantityMeasurementService(IQuantityMeasurementRepository quantityRepository)
        {
            _quantityRepository = quantityRepository;
        }

        public string Add(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            try
            {
                double convertedValue2 = ConvertToBaseUnit(value2, unit2, quantityType);
                double convertedValue1 = ConvertToBaseUnit(value1, unit1, quantityType);

                double sumBase = convertedValue1 + convertedValue2;
                double result = ConvertFromBaseUnit(sumBase, unit1, quantityType);

                string resultText = $"{result} {unit1}";

                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Add,

                    Input1Value = value1,
                    Input1Unit = unit1,
                    Input1Type = quantityType,

                    Input2Value = value2,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    OutputValue = result,
                    OutputUnit = unit1,
                    OutputText = resultText,

                    SuccessFlag = true
                };

                _quantityRepository.SaveMeasurementRecord(record);

                return resultText;
            }
            catch (Exception ex)
            {
                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Add,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    SuccessFlag = false,
                    ErrorMessage = ex.Message
                };

                _quantityRepository.SaveMeasurementRecord(record);
                throw;
            }
        }

        public string Subtract(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            try
            {
                double convertedValue2 = ConvertToBaseUnit(value2, unit2, quantityType);
                double convertedValue1 = ConvertToBaseUnit(value1, unit1, quantityType);

                double differenceBase = convertedValue1 - convertedValue2;
                double result = ConvertFromBaseUnit(differenceBase, unit1, quantityType);

                string resultText = $"{result} {unit1}";

                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Subtract,

                    Input1Value = value1,
                    Input1Unit = unit1,
                    Input1Type = quantityType,

                    Input2Value = value2,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    OutputValue = result,
                    OutputUnit = unit1,
                    OutputText = resultText,

                    SuccessFlag = true
                };

                _quantityRepository.SaveMeasurementRecord(record);

                return resultText;
            }
            catch (Exception ex)
            {
                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Subtract,

                    Input1Value = value1,
                    Input1Unit = unit1,
                    Input1Type = quantityType,

                    Input2Value = value2,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    SuccessFlag = false,
                    ErrorMessage = ex.Message
                };

                _quantityRepository.SaveMeasurementRecord(record);
                throw;
            }
        }

        public string Compare(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            try
            {
                double convertedValue1 = ConvertToBaseUnit(value1, unit1, quantityType);
                double convertedValue2 = ConvertToBaseUnit(value2, unit2, quantityType);

                string resultText;

                if (convertedValue1 > convertedValue2)
                {
                    resultText = $"{value1} {unit1} is greater than {value2} {unit2}";
                }
                else if (convertedValue1 < convertedValue2)
                {
                    resultText = $"{value1} {unit1} is less than {value2} {unit2}";
                }
                else
                {
                    resultText = $"{value1} {unit1} is equal to {value2} {unit2}";
                }

                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Compare,

                    Input1Value = value1,
                    Input1Unit = unit1,
                    Input1Type = quantityType,

                    Input2Value = value2,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    OutputText = resultText,
                    SuccessFlag = true
                };

                _quantityRepository.SaveMeasurementRecord(record);

                return resultText;
            }
            catch (Exception ex)
            {
                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Compare,

                    Input1Value = value1,
                    Input1Unit = unit1,
                    Input1Type = quantityType,

                    Input2Value = value2,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    SuccessFlag = false,
                    ErrorMessage = ex.Message
                };

                _quantityRepository.SaveMeasurementRecord(record);
                throw;
            }
        }

        public string Divide(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            try
            {
                double convertedValue1 = ConvertToBaseUnit(value1, unit1, quantityType);
                double convertedValue2 = ConvertToBaseUnit(value2, unit2, quantityType);

                if (convertedValue2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }

                double result = convertedValue1 / convertedValue2;
                string resultText = result.ToString();

                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Divide,

                    Input1Value = value1,
                    Input1Unit = unit1,
                    Input1Type = quantityType,

                    Input2Value = value2,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    OutputValue = result,
                    OutputText = resultText,

                    SuccessFlag = true
                };

                _quantityRepository.SaveMeasurementRecord(record);

                return resultText;
            }
            catch (Exception ex)
            {
                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Divide,

                    Input1Value = value1,
                    Input1Unit = unit1,
                    Input1Type = quantityType,

                    Input2Value = value2,
                    Input2Unit = unit2,
                    Input2Type = quantityType,

                    SuccessFlag = false,
                    ErrorMessage = ex.Message
                };

                _quantityRepository.SaveMeasurementRecord(record);
                throw;
            }
        }

        public string Convert(double value, string fromUnit, string toUnit, string quantityType)
        {
            try
            {
                double baseValue = ConvertToBaseUnit(value, fromUnit, quantityType);
                double convertedValue = ConvertFromBaseUnit(baseValue, toUnit, quantityType);

                string resultText = $"{convertedValue} {toUnit}";

                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Convert,

                    OriginalValue = value,
                    OriginalUnit = fromUnit,
                    OriginalType = quantityType,

                    DesiredUnit = toUnit,

                    OutputValue = convertedValue,
                    OutputUnit = toUnit,
                    OutputText = resultText,

                    SuccessFlag = true
                };

                _quantityRepository.SaveMeasurementRecord(record);

                return resultText;
            }
            catch (Exception ex)
            {
                var record = new MeasurementRecord
                {
                    Id = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.Now,
                    Operation = OperationType.Convert,

                    OriginalValue = value,
                    OriginalUnit = fromUnit,
                    OriginalType = quantityType,

                    DesiredUnit = toUnit,

                    SuccessFlag = false,
                    ErrorMessage = ex.Message
                };

                _quantityRepository.SaveMeasurementRecord(record);
                throw;
            }
        }

        private double ConvertToBaseUnit(double value, string unit, string quantityType)
        {
            switch (quantityType.ToLower())
            {
                case "length":
                    switch (unit.ToLower())
                    {
                        case "inch":
                            return value;
                        case "feet":
                            return value * 12;
                        case "yard":
                            return value * 36;
                        case "centimeter":
                            return value / 2.54;
                        case "meter":
                            return value * 39.3701;
                        default:
                            throw new ArgumentException("Invalid length unit");
                    }

                case "weight":
                    switch (unit.ToLower())
                    {
                        case "gram":
                            return value;
                        case "kilogram":
                            return value * 1000;
                        case "tonne":
                            return value * 1000000;
                        default:
                            throw new ArgumentException("Invalid weight unit");
                    }

                case "temperature":
                    switch (unit.ToLower())
                    {
                        case "celsius":
                            return value;
                        case "fahrenheit":
                            return (value - 32) * 5 / 9;
                        case "kelvin":
                            return value - 273.15;
                        default:
                            throw new ArgumentException("Invalid temperature unit");
                    }

                case "volume":
                    switch (unit.ToLower())
                    {
                        case "milliliter":
                            return value;
                        case "liter":
                            return value * 1000;
                        case "gallon":
                            return value * 3785.41;
                        default:
                            throw new ArgumentException("Invalid volume unit");
                    }

                default:
                    throw new ArgumentException("Invalid quantity type");
            }
        }
        private double ConvertFromBaseUnit(double value, string unit, string quantityType)
        {
            switch (quantityType.ToLower())
            {
                case "length":
                    switch (unit.ToLower())
                    {
                        case "inch":
                            return value;
                        case "feet":
                            return value / 12;
                        case "yard":
                            return value / 36;
                        case "centimeter":
                            return value * 2.54;
                        case "meter":
                            return value / 39.3701;
                        default:
                            throw new ArgumentException("Invalid length unit");
                    }

                case "weight":
                    switch (unit.ToLower())
                    {
                        case "gram":
                            return value;
                        case "kilogram":
                            return value / 1000;
                        case "tonne":
                            return value / 1000000;
                        default:
                            throw new ArgumentException("Invalid weight unit");
                    }

                case "temperature":
                    switch (unit.ToLower())
                    {
                        case "celsius":
                            return value;
                        case "fahrenheit":
                            return (value * 9 / 5) + 32;
                        case "kelvin":
                            return value + 273.15;
                        default:
                            throw new ArgumentException("Invalid temperature unit");
                    }

                case "volume":
                    switch (unit.ToLower())
                    {
                        case "milliliter":
                            return value;
                        case "liter":
                            return value / 1000;
                        case "gallon":
                            return value / 3785.41;
                        default:
                            throw new ArgumentException("Invalid volume unit");
                    }

                default:
                    throw new ArgumentException("Invalid quantity type");
            }
        }
        private string GetBaseUnit(string quantityType)
        {
            switch (quantityType.ToLower())
            {
                case "length":
                    return "Inch";
                case "weight":
                    return "Gram";
                case "temperature":
                    return "Celsius";
                case "volume":
                    return "Milliliter";
                default:
                    throw new ArgumentException("Invalid quantity type");
            }
        }

        public List<MeasurementRecord> GetHistory()
        {
            return _quantityRepository.GetAllRecords();
        }

        public int GetCount()
        {
            return _quantityRepository.GetRecordCount();
        }

        public List<string> GetOperationTypes()
        {
            return Enum.GetNames(typeof(OperationType)).ToList();
        }

        public List<string> GetMeasurementTypes()
        {
            return new List<string> { "Length", "Weight", "Temperature" };
        }
    }
}