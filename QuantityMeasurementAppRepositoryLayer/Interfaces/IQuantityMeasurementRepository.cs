using QuantityMeasurementAppModel.DTOs;
using System.Collections.Generic;

namespace QuantityMeasurementAppRepositoryLayer.Interfaces
{
    public interface IQuantityMeasurementRepository
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