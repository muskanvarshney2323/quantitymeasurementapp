using System.Collections.Generic;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppModel.Requests;

namespace QuantityMeasurementAppBusinessLayer.Interfaces
{
    public interface IQuantityMeasurementService
    {
        string AddQuantity(QuantityRequest request);
        List<QuantityDTO> GetAllQuantities();
        QuantityDTO GetQuantityById(int id);
        string UpdateQuantity(QuantityDTO quantityDto);
        string DeleteQuantity(int id);
    }
}