using System.Collections.Generic;
using QuantityMeasurementAppModel;

namespace QuantityMeasurementAppRepositoryLayer
{
    public class QuantityMeasurementCacheRepository : IQuantityMeasurementRepository
    {
        private readonly List<QuantityMeasurementEntity> measurements = new List<QuantityMeasurementEntity>();

        public void Save(QuantityMeasurementEntity entity)
        {
            measurements.Add(entity);
        }

        public List<QuantityMeasurementEntity> GetAll()
        {
            return new List<QuantityMeasurementEntity>(measurements);
        }

        public int GetCount()
        {
            return measurements.Count;
        }

        public void DeleteAll()
        {
            measurements.Clear();
        }
    }
}