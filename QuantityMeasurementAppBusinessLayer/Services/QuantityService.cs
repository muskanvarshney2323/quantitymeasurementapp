using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppRepositoryLayer.Interfaces;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class QuantityService : IQuantityService
    {
        private readonly IQuantityMeasurementRepository _quantityRepository;

        public QuantityService(IQuantityMeasurementRepository quantityRepository)
        {
            _quantityRepository = quantityRepository;
        }

        public object Compare(CompareRequestDto request)
        {
            return _quantityRepository.Compare(request);
        }

        public object Add(AddRequestDto request)
        {
            return _quantityRepository.Add(request);
        }

        public object Subtract(AddRequestDto request)
        {
            return _quantityRepository.Subtract(request);
        }

        public object Divide(CompareRequestDto request)
        {
            return _quantityRepository.Divide(request);
        }

        public object Convert(ConvertRequestDto request)
        {
            return _quantityRepository.Convert(request);
        }
    }
}