using System.Collections.Generic;
using QuantityMeasurementAppModel.Entity;

namespace QuantityMeasurementAppRepositoryLayer
{
    public interface IQuantityMeasurementRepository
    {
        string AddQuantity(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetAllQuantities();
        QuantityMeasurementEntity GetQuantityById(int id);
        string UpdateQuantity(QuantityMeasurementEntity entity);
        string DeleteQuantity(int id);
    }
}