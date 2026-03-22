using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppRepositoryLayer.Interfaces;
using QuantityMeasurementAppModel.DTOs;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _quantityMeasurementRepository;

        public QuantityMeasurementService(IQuantityMeasurementRepository quantityMeasurementRepository)
        {
            _quantityMeasurementRepository = quantityMeasurementRepository;
        }

        public bool Compare(CompareRequestDto request)
        {
            return _quantityMeasurementRepository.Compare(request);
        }

        public double Add(AddRequestDto request)
        {
            return _quantityMeasurementRepository.Add(request);
        }

        public double Convert(ConvertRequestDto request)
        {
            return _quantityMeasurementRepository.Convert(request);
        }

        public List<string> GetHistory()
        {
            return _quantityMeasurementRepository.GetHistory();
        }

        public int GetCount()
        {
            return _quantityMeasurementRepository.GetCount();
        }
        public double Subtract(AddRequestDto request)
        {
            double value1 = request.Value1;
            double value2 = request.Value2;

            return value1 - value2;
        }

        public double Divide(CompareRequestDto request)
        {
            double value1 = request.Value1;
            double value2 = request.Value2;

            if (value2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return value1 / value2;
        }
    }
}