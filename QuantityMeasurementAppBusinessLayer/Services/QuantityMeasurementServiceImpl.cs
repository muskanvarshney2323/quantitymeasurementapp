using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppRepositoryLayer;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class QuantityMeasurementServiceImpl : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _repository;

        public QuantityMeasurementServiceImpl(IQuantityMeasurementRepository repository)
        {
            _repository = repository;
        }

        public bool Compare(QuantityDTO q1, QuantityDTO q2)
        {
            return q1.Value == q2.Value && q1.Unit == q2.Unit;
        }

        public QuantityDTO Convert(QuantityDTO source, string targetUnit)
        {
            return new QuantityDTO
            {
                Value = source.Value,
                Unit = targetUnit
            };
        }

        public QuantityDTO Add(QuantityDTO q1, QuantityDTO q2)
        {
            return new QuantityDTO
            {
                Value = q1.Value + q2.Value,
                Unit = q1.Unit
            };
        }

        public QuantityDTO Subtract(QuantityDTO q1, QuantityDTO q2)
        {
            return new QuantityDTO
            {
                Value = q1.Value - q2.Value,
                Unit = q1.Unit
            };
        }

        public double Divide(QuantityDTO q1, QuantityDTO q2)
        {
            if (q2.Value == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return q1.Value / q2.Value;
        }
    }
}