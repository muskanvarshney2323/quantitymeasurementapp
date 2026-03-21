using QuantityMeasurementAppBusinessLayer.Services;
using QuantityMeasurementAppModel;
using QuantityMeasurementAppModel.DTOs;

namespace QuantityMeasurementApp.Console.Controllers
{
    public class QuantityMeasurementController
    {
        private readonly IQuantityMeasurementService _service;

        public QuantityMeasurementController(IQuantityMeasurementService service)
        {
            _service = service;
        }

        public bool Compare(QuantityDTO q1, QuantityDTO q2)
        {
            return _service.Compare(q1, q2);
        }

        public QuantityDTO Convert(QuantityDTO source, string targetUnit)
        {
            return _service.Convert(source, targetUnit);
        }

        public QuantityDTO Add(QuantityDTO q1, QuantityDTO q2)
        {
            return _service.Add(q1, q2);
        }

        public QuantityDTO Subtract(QuantityDTO q1, QuantityDTO q2)
        {
            return _service.Subtract(q1, q2);
        }

        public double Divide(QuantityDTO q1, QuantityDTO q2)
        {
            return _service.Divide(q1, q2);
        }
    }
}