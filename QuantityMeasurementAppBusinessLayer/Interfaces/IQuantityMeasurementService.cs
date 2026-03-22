using QuantityMeasurementAppModel.DTOs;

namespace QuantityMeasurementAppBusinessLayer.Interfaces
{
    public interface IQuantityMeasurementService
    {
        bool Compare(CompareRequestDto request);
        double Add(AddRequestDto request);
        double Convert(ConvertRequestDto request);
        double Subtract(AddRequestDto request);
        double Divide(CompareRequestDto request);
        List<string> GetHistory();
        int GetCount();

    }
}