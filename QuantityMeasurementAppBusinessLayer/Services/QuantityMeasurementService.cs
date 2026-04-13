using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.Entities;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        public string Compare(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            ValidateTwoValueRequest(value1, unit1, value2, unit2, quantityType);

            double baseValue1 = ConvertToBaseUnit(value1, unit1, quantityType);
            double baseValue2 = ConvertToBaseUnit(value2, unit2, quantityType);

            if (baseValue1 > baseValue2)
            {
                return "First value is greater";
            }
            else if (baseValue1 < baseValue2)
            {
                return "Second value is greater";
            }
            else
            {
                return "Both values are equal";
            }
        }

        public string Convert(double value, string fromUnit, string toUnit, string quantityType)
        {
            ValidateConvertRequest(value, fromUnit, toUnit, quantityType);

            double baseValue = ConvertToBaseUnit(value, fromUnit, quantityType);
            double convertedValue = ConvertFromBaseUnit(baseValue, toUnit, quantityType);

            return $"{value} {fromUnit} = {Math.Round(convertedValue, 4)} {toUnit}";
        }

        public string Add(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            ValidateTwoValueRequest(value1, unit1, value2, unit2, quantityType);

            if (quantityType.Trim().Equals("temperature", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Add operation is not supported for Temperature.");
            }

            double baseValue1 = ConvertToBaseUnit(value1, unit1, quantityType);
            double baseValue2 = ConvertToBaseUnit(value2, unit2, quantityType);

            double sumBase = baseValue1 + baseValue2;
            double finalValue = ConvertFromBaseUnit(sumBase, unit1, quantityType);

            return $"{value1} {unit1} + {value2} {unit2} = {Math.Round(finalValue, 4)} {unit1}";
        }

        public string Subtract(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            ValidateTwoValueRequest(value1, unit1, value2, unit2, quantityType);

            if (quantityType.Trim().Equals("temperature", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Subtract operation is not supported for Temperature.");
            }

            double baseValue1 = ConvertToBaseUnit(value1, unit1, quantityType);
            double baseValue2 = ConvertToBaseUnit(value2, unit2, quantityType);

            double differenceBase = baseValue1 - baseValue2;
            double finalValue = ConvertFromBaseUnit(differenceBase, unit1, quantityType);

            return $"{value1} {unit1} - {value2} {unit2} = {Math.Round(finalValue, 4)} {unit1}";
        }

        public string Divide(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            ValidateTwoValueRequest(value1, unit1, value2, unit2, quantityType);

            if (quantityType.Trim().Equals("temperature", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Divide operation is not supported for Temperature.");
            }

            double baseValue1 = ConvertToBaseUnit(value1, unit1, quantityType);
            double baseValue2 = ConvertToBaseUnit(value2, unit2, quantityType);

            if (baseValue2 == 0)
            {
                throw new Exception("Cannot divide by zero.");
            }

            double result = baseValue1 / baseValue2;

            return $"{value1} {unit1} / {value2} {unit2} = {Math.Round(result, 4)}";
        }

        public List<MeasurementRecord> GetHistory()
        {
            return new List<MeasurementRecord>();
        }

        public int GetCount()
        {
            return 0;
        }

        public List<string> GetOperationTypes()
        {
            return new List<string> { "Convert", "Add", "Subtract", "Divide", "Compare" };
        }

        public List<string> GetMeasurementTypes()
        {
            return new List<string> { "Length", "Weight", "Volume", "Temperature" };
        }

        private void ValidateConvertRequest(double value, string fromUnit, string toUnit, string quantityType)
        {
            if (string.IsNullOrWhiteSpace(fromUnit))
            {
                throw new Exception("FromUnit is required.");
            }

            if (string.IsNullOrWhiteSpace(toUnit))
            {
                throw new Exception("ToUnit is required.");
            }

            if (string.IsNullOrWhiteSpace(quantityType))
            {
                throw new Exception("QuantityType is required.");
            }
        }

        private void ValidateTwoValueRequest(double value1, string unit1, double value2, string unit2, string quantityType)
        {
            if (string.IsNullOrWhiteSpace(unit1))
            {
                throw new Exception("Unit1 is required.");
            }

            if (string.IsNullOrWhiteSpace(unit2))
            {
                throw new Exception("Unit2 is required.");
            }

            if (string.IsNullOrWhiteSpace(quantityType))
            {
                throw new Exception("QuantityType is required.");
            }
        }

        private double ConvertToBaseUnit(double value, string unit, string quantityType)
        {
            string normalizedQuantityType = quantityType.Trim().ToLower();
            string normalizedUnit = unit.Trim().ToLower();

            if (normalizedQuantityType == "temperature")
            {
                return ConvertTemperatureToCelsius(value, normalizedUnit);
            }

            Dictionary<string, double> factors = GetUnitFactors(normalizedQuantityType);

            if (!factors.ContainsKey(normalizedUnit))
            {
                throw new Exception($"Invalid unit '{unit}' for quantity type '{quantityType}'.");
            }

            return value * factors[normalizedUnit];
        }

        private double ConvertFromBaseUnit(double value, string unit, string quantityType)
        {
            string normalizedQuantityType = quantityType.Trim().ToLower();
            string normalizedUnit = unit.Trim().ToLower();

            if (normalizedQuantityType == "temperature")
            {
                return ConvertCelsiusToTarget(value, normalizedUnit);
            }

            Dictionary<string, double> factors = GetUnitFactors(normalizedQuantityType);

            if (!factors.ContainsKey(normalizedUnit))
            {
                throw new Exception($"Invalid unit '{unit}' for quantity type '{quantityType}'.");
            }

            return value / factors[normalizedUnit];
        }

        private Dictionary<string, double> GetUnitFactors(string quantityType)
        {
            switch (quantityType)
            {
                case "length":
                    return new Dictionary<string, double>
                    {
                        { "millimeter", 0.001 },
                        { "centimeter", 0.01 },
                        { "meter", 1 },
                        { "kilometer", 1000 }
                    };

                case "weight":
                    return new Dictionary<string, double>
                    {
                        { "milligram", 0.001 },
                        { "gram", 1 },
                        { "kilogram", 1000 }
                    };

                case "volume":
                    return new Dictionary<string, double>
                    {
                        { "milliliter", 0.001 },
                        { "liter", 1 }
                    };

                default:
                    throw new Exception("Invalid quantity type.");
            }
        }

        private double ConvertTemperatureToCelsius(double value, string unit)
        {
            switch (unit)
            {
                case "celsius":
                    return value;

                case "fahrenheit":
                    return (value - 32) * 5 / 9;

                case "kelvin":
                    return value - 273.15;

                default:
                    throw new Exception("Invalid temperature unit.");
            }
        }

        private double ConvertCelsiusToTarget(double value, string unit)
        {
            switch (unit)
            {
                case "celsius":
                    return value;

                case "fahrenheit":
                    return (value * 9 / 5) + 32;

                case "kelvin":
                    return value + 273.15;

                default:
                    throw new Exception("Invalid temperature unit.");
            }
        }
    }
}