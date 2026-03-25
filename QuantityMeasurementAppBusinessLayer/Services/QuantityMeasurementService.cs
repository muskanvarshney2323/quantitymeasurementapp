using System;
using System.Collections.Generic;
using QuantityMeasurementAppModel;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppRepositoryLayer;

namespace QuantityMeasurementAppBusinessLayer
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository repository;

        public QuantityMeasurementService(IQuantityMeasurementRepository repository)
        {
            this.repository = repository;
        }

        public bool Compare(double value1, string unit1, double value2, string unit2)
        {
            ValidateSameMeasurementType(unit1, unit2);

            double convertedValue2 = ConvertToTargetUnit(value2, unit2, unit1);
            return value1 == convertedValue2;
        }

        public QuantityDTO Convert(double value, string fromUnit, string toUnit)
        {
            ValidateSameMeasurementType(fromUnit, toUnit);

            double convertedValue = ConvertToTargetUnit(value, fromUnit, toUnit);

            return new QuantityDTO
            {
                Value = convertedValue,
                Unit = toUnit
            };
        }

        public QuantityDTO Add(double value1, string unit1, double value2, string unit2)
        {
            ValidateSameMeasurementType(unit1, unit2);

            double convertedValue2 = ConvertToTargetUnit(value2, unit2, unit1);

            return new QuantityDTO
            {
                Value = value1 + convertedValue2,
                Unit = unit1
            };
        }

        public QuantityDTO Subtract(double value1, string unit1, double value2, string unit2)
        {
            ValidateSameMeasurementType(unit1, unit2);

            double convertedValue2 = ConvertToTargetUnit(value2, unit2, unit1);

            return new QuantityDTO
            {
                Value = value1 - convertedValue2,
                Unit = unit1
            };
        }

        public double Divide(double value1, string unit1, double value2, string unit2)
        {
            ValidateSameMeasurementType(unit1, unit2);

            double convertedValue2 = ConvertToTargetUnit(value2, unit2, unit1);

            if (convertedValue2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return value1 / convertedValue2;
        }

        public void SaveMeasurement(QuantityMeasurementEntity entity)
        {
            repository.Save(entity);
        }

        public List<QuantityMeasurementEntity> GetAllMeasurements()
        {
            return repository.GetAll();
        }

        public int GetTotalMeasurements()
        {
            return repository.GetCount();
        }

        public void DeleteAllMeasurements()
        {
            repository.DeleteAll();
        }

        private void ValidateSameMeasurementType(string unit1, string unit2)
        {
            string type1 = GetMeasurementType(unit1);
            string type2 = GetMeasurementType(unit2);

            if (type1 != type2)
            {
                throw new Exception("Operation supports only units of the same measurement type.");
            }
        }

        private string GetMeasurementType(string unit)
        {
            switch (unit)
            {
                case "FEET":
                case "INCH":
                case "YARD":
                case "CENTIMETER":
                    return "LENGTH";

                case "KILOGRAM":
                case "GRAM":
                case "TONNE":
                    return "WEIGHT";

                case "LITRE":
                case "MILLILITRE":
                case "GALLON":
                    return "VOLUME";

                case "CELSIUS":
                case "FAHRENHEIT":
                case "KELVIN":
                    return "TEMPERATURE";

                default:
                    throw new Exception("Unsupported unit.");
            }
        }

        private double ConvertToTargetUnit(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
            {
                return value;
            }

            string measurementType = GetMeasurementType(fromUnit);

            switch (measurementType)
            {
                case "LENGTH":
                    return ConvertLength(value, fromUnit, toUnit);

                case "WEIGHT":
                    return ConvertWeight(value, fromUnit, toUnit);

                case "VOLUME":
                    return ConvertVolume(value, fromUnit, toUnit);

                case "TEMPERATURE":
                    return ConvertTemperature(value, fromUnit, toUnit);

                default:
                    throw new Exception("Conversion not supported.");
            }
        }

        private double ConvertLength(double value, string fromUnit, string toUnit)
        {
            double valueInCentimeter = fromUnit switch
            {
                "FEET" => value * 30.48,
                "INCH" => value * 2.54,
                "YARD" => value * 91.44,
                "CENTIMETER" => value,
                _ => throw new Exception("Unsupported length unit.")
            };

            return toUnit switch
            {
                "FEET" => valueInCentimeter / 30.48,
                "INCH" => valueInCentimeter / 2.54,
                "YARD" => valueInCentimeter / 91.44,
                "CENTIMETER" => valueInCentimeter,
                _ => throw new Exception("Unsupported length unit.")
            };
        }

        private double ConvertWeight(double value, string fromUnit, string toUnit)
        {
            double valueInGram = fromUnit switch
            {
                "KILOGRAM" => value * 1000,
                "GRAM" => value,
                "TONNE" => value * 1000000,
                _ => throw new Exception("Unsupported weight unit.")
            };

            return toUnit switch
            {
                "KILOGRAM" => valueInGram / 1000,
                "GRAM" => valueInGram,
                "TONNE" => valueInGram / 1000000,
                _ => throw new Exception("Unsupported weight unit.")
            };
        }

        private double ConvertVolume(double value, string fromUnit, string toUnit)
        {
            double valueInMillilitre = fromUnit switch
            {
                "LITRE" => value * 1000,
                "MILLILITRE" => value,
                "GALLON" => value * 3785.41,
                _ => throw new Exception("Unsupported volume unit.")
            };

            return toUnit switch
            {
                "LITRE" => valueInMillilitre / 1000,
                "MILLILITRE" => valueInMillilitre,
                "GALLON" => valueInMillilitre / 3785.41,
                _ => throw new Exception("Unsupported volume unit.")
            };
        }

        private double ConvertTemperature(double value, string fromUnit, string toUnit)
        {
            double valueInCelsius = fromUnit switch
            {
                "CELSIUS" => value,
                "FAHRENHEIT" => (value - 32) * 5 / 9,
                "KELVIN" => value - 273.15,
                _ => throw new Exception("Unsupported temperature unit.")
            };

            return toUnit switch
            {
                "CELSIUS" => valueInCelsius,
                "FAHRENHEIT" => (valueInCelsius * 9 / 5) + 32,
                "KELVIN" => valueInCelsius + 273.15,
                _ => throw new Exception("Unsupported temperature unit.")
            };
        }
    }
}