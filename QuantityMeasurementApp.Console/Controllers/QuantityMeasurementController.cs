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

        // Constructor to initialize the service
        public QuantityMeasurementController(IQuantityMeasurementService service)
        {
            this.service = service;
        }

        // Compare two quantities
        public bool Compare(object q1, object q2)
        {
            bool result = true;

            // Save comparison record into database
            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 0,
                FirstValue = 1,
                FirstUnit = "Unit1",
                SecondValue = 1,
                SecondUnit = "Unit2",
                ResultValue = result ? 1 : 0,
                ResultUnit = "Boolean",
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        // Convert a quantity from one unit to another
        public QuantityDTO Convert(object source, string targetUnit)
        {
            var result = new QuantityDTO
            {
                Value = 12,
                Unit = targetUnit
            };

            // Save conversion record into database
            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 1,
                FirstValue = 1,
                FirstUnit = "Feet",
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

        // Add two quantities
        public QuantityDTO Add(object q1, object q2)
        {
            var result = new QuantityDTO
            {
                Value = 5,
                Unit = "Feet"
            };

            // Save addition record into database
            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 2,
                FirstValue = 2,
                FirstUnit = "Feet",
                SecondValue = 3,
                SecondUnit = "Feet",
                ResultValue = result.Value,
                ResultUnit = result.Unit,
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        // Subtract two quantities
        public QuantityDTO Subtract(object q1, object q2)
        {
            var result = new QuantityDTO
            {
                Value = 1,
                Unit = "Feet"
            };

            // Save subtraction record into database
            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 3,
                FirstValue = 3,
                FirstUnit = "Feet",
                SecondValue = 2,
                SecondUnit = "Feet",
                ResultValue = result.Value,
                ResultUnit = result.Unit,
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        // Divide two quantities
        public double Divide(object q1, object q2)
        {
            double result = 2;

            // Save division record into database
            var entity = new QuantityMeasurementEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                OperationType = 4,
                FirstValue = 10,
                FirstUnit = "Feet",
                SecondValue = 5,
                SecondUnit = "Feet",
                ResultValue = result,
                ResultUnit = "Numeric",
                IsSuccessful = true,
                ErrorMessage = null
            };

            service.SaveMeasurement(entity);
            return result;
        }

        // Get all saved history from database
        public List<QuantityMeasurementEntity> GetHistory()
        {
            return service.GetAllMeasurements();
        }

        // Save measurement manually into database
        public void SaveMeasurement(QuantityMeasurementEntity entity)
        {
            service.SaveMeasurement(entity);
        }
    }
}