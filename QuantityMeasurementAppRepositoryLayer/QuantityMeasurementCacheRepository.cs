using QuantityMeasurementAppModel;
using System.Collections.Generic;
namespace QuantityMeasurementAppRepositoryLayer
{
    public class QuantityMeasurementCacheRepository : IQuantityMeasurementRepository
    {
        private List<QuantityMeasurementEntity> measurements = new List<QuantityMeasurementEntity>();
        public void Save(QuantityMeasurementEntity entity)
        {
        measurements.Add(entity);
        }
        public List<QuantityMeasurementEntity> GetAll()
        {
            return measurements;
        }
    }

    
}