using System;
using System.Collections.Generic;
using QuantityMeasurementAppBusinessLayer;
using QuantityMeasurementAppModel;
using QuantityMeasurementAppModel.DTOs;
namespace QuantityMeasurementApp.Console.Controllers
{
    public class QuantityMeasurementController
    {
        private readonly IQuantityMeasurementService service;

        public QuantityMeasurementController(IQuantityMeasurementService service)
        {
            this.service = service;
        }

        public bool Compare(double value1, string unit1, double value2, string unit2)
        {
            bool result = service.Compare(value1, unit1, value2, unit2);

            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 0,
                FirstValue = value1,
                FirstUnit = unit1,
                SecondValue = value2,
                SecondUnit = unit2,
                ResultValue = result ? 1 : 0,
                ResultUnit = "Boolean",
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        public QuantityDTO Convert(double value, string fromUnit, string toUnit)
        {
            QuantityDTO result = service.Convert(value, fromUnit, toUnit);

            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 1,
                FirstValue = value,
                FirstUnit = fromUnit,
                SecondValue = null,
                SecondUnit = null,
                ResultValue = result.Value,
                ResultUnit = result.Unit,
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        public QuantityDTO Add(double value1, string unit1, double value2, string unit2)
        {
            QuantityDTO result = service.Add(value1, unit1, value2, unit2);

            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 2,
                FirstValue = value1,
                FirstUnit = unit1,
                SecondValue = value2,
                SecondUnit = unit2,
                ResultValue = result.Value,
                ResultUnit = result.Unit,
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        public QuantityDTO Subtract(double value1, string unit1, double value2, string unit2)
        {
            QuantityDTO result = service.Subtract(value1, unit1, value2, unit2);

            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 3,
                FirstValue = value1,
                FirstUnit = unit1,
                SecondValue = value2,
                SecondUnit = unit2,
                ResultValue = result.Value,
                ResultUnit = result.Unit,
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        public double Divide(double value1, string unit1, double value2, string unit2)
        {
            double result = service.Divide(value1, unit1, value2, unit2);

            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 4,
                FirstValue = value1,
                FirstUnit = unit1,
                SecondValue = value2,
                SecondUnit = unit2,
                ResultValue = result,
                ResultUnit = "Numeric",
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        public List<QuantityMeasurementEntity> GetHistory()
        {
            return service.GetAllMeasurements();
        }

        public void SaveMeasurement(QuantityMeasurementEntity entity)
        {
            service.SaveMeasurement(entity);
        }
    }
}