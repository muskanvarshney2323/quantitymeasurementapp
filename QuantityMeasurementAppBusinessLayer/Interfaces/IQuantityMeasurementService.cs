using System.Collections.Generic;
using QuantityMeasurementAppModel;

namespace QuantityMeasurementAppBusinessLayer
{
    public interface IQuantityMeasurementService
    {
        void SaveMeasurement(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetAllMeasurements();
        int GetTotalMeasurements();
        void DeleteAllMeasurements();
    }
}