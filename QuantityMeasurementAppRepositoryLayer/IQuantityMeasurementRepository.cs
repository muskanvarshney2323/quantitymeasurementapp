using QuantityMeasurementAppModel;
using System.Collections.Generic;
namespace QuantityMeasurementAppRepositoryLayer
{
    public interface IQuantityMeasurementRepository
    {
        void Save(QuantityMeasurementEntity entity);
        List<QuantityMeasurementEntity> GetAll();
    }
}