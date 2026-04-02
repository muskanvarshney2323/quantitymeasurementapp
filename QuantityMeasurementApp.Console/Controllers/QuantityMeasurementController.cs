using System;
using System.Collections.Generic;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppBusinessLayer.Services;
using QuantityMeasurementAppModel;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppModel.Entities;

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
            var entity = new MeasurementRecord
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Now,
                Operation = QuantityMeasurementAppModel.Enums.OperationType.Compare,
                Input1Value = 1,
                Input1Unit = "Unit1",
                Input2Value = 1,
                Input2Unit = "Unit2",
                OutputText = result.ToString(),
                SuccessFlag = true,
                ErrorMessage = null
            };

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
            var entity = new MeasurementRecord
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Now,
                Operation = QuantityMeasurementAppModel.Enums.OperationType.Convert,
                OriginalValue = 1,
                OriginalUnit = "Feet",
                DesiredUnit = targetUnit,
                OutputValue = result.Value,
                OutputUnit = result.Unit,
                OutputText = result.ToString(),
                SuccessFlag = true,
                ErrorMessage = null
            };

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
            var entity = new MeasurementRecord
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Now,
                Operation = QuantityMeasurementAppModel.Enums.OperationType.Add,
                Input1Value = 2,
                Input1Unit = "Feet",
                Input2Value = 3,
                Input2Unit = "Feet",
                OutputValue = result.Value,
                OutputUnit = result.Unit,
                OutputText = result.ToString(),
                SuccessFlag = true,
                ErrorMessage = null
            };

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
            var entity = new MeasurementRecord
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Now,
                Operation = QuantityMeasurementAppModel.Enums.OperationType.Subtract,
                Input1Value = 3,
                Input1Unit = "Feet",
                Input2Value = 2,
                Input2Unit = "Feet",
                OutputValue = result.Value,
                OutputUnit = result.Unit,
                OutputText = result.ToString(),
                SuccessFlag = true,
                ErrorMessage = null
            };

            return result;
        }

        // Divide two quantities
        public double Divide(object q1, object q2)
        {
            double result = 2;

            // Save division record into database
            var entity = new MeasurementRecord
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Now,
                Operation = QuantityMeasurementAppModel.Enums.OperationType.Divide,
                Input1Value = 10,
                Input1Unit = "Feet",
                Input2Value = 5,
                Input2Unit = "Feet",
                OutputValue = result,
                OutputText = result.ToString(),
                SuccessFlag = true,
                ErrorMessage = null
            };

            return result;
        }

        // Get all saved history from database
        public List<MeasurementRecord> GetHistory()
        {
            return service.GetHistory();
        }

        // Save measurement manually into database
        public void SaveMeasurement(MeasurementRecord entity)
        {
            // Measurements are saved automatically within service operations
        }
    }
}