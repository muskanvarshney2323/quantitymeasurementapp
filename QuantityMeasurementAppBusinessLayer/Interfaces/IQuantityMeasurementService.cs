using System.Collections.Generic;
using QuantityMeasurementAppModel;
using QuantityMeasurementAppModel.DTOs;

namespace QuantityMeasurementAppBusinessLayer
{
    public interface IQuantityMeasurementService
    {
        bool Compare(double value1, string unit1, double value2, string unit2);
        QuantityDTO Convert(double value, string fromUnit, string toUnit);
        QuantityDTO Add(double value1, string unit1, double value2, string unit2);
        QuantityDTO Subtract(double value1, string unit1, double value2, string unit2);
        double Divide(double value1, string unit1, double value2, string unit2);

        void SaveMeasurement(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetAllMeasurements();
        int GetTotalMeasurements();
        void DeleteAllMeasurements();
    }
}