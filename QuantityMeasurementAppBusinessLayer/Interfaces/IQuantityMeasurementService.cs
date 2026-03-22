using QuantityMeasurementAppModel.DTOs;

namespace QuantityMeasurementAppBusinessLayer.Interfaces
{
    public interface IQuantityService
    {
        object Compare(CompareRequestDto request);
        object Add(AddRequestDto request);
        object Subtract(AddRequestDto request);
        object Divide(CompareRequestDto request);
        object Convert(ConvertRequestDto request);
    }
}