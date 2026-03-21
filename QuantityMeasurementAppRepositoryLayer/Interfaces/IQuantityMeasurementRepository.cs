using System.Collections.Generic;
using QuantityMeasurementAppModel;

namespace QuantityMeasurementAppRepositoryLayer
{
    public interface IQuantityMeasurementRepository
    {
        void Save(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetAll();
        int GetCount();
        void DeleteAll();
    }
}