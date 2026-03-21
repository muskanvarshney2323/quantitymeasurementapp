using System.Collections.Generic;
using System.Linq;
using QuantityMeasurementAppModel.Entity;

namespace QuantityMeasurementAppRepositoryLayer.Repositories
{
    public class QuantityMeasurementCacheRepository : IQuantityMeasurementRepository
    {
        private readonly List<QuantityMeasurementEntity> _quantities = new List<QuantityMeasurementEntity>();
        private int _nextId = 1;

        public string AddQuantity(QuantityMeasurementEntity entity)
        {
            entity.Id = _nextId++;
            _quantities.Add(entity);
            return "Quantity added successfully.";
        }

        public List<QuantityMeasurementEntity> GetAllQuantities()
        {
            return _quantities;
        }

        public QuantityMeasurementEntity GetQuantityById(int id)
        {
            return _quantities.FirstOrDefault(q => q.Id == id);
        }

        public string UpdateQuantity(QuantityMeasurementEntity entity)
        {
            QuantityMeasurementEntity existingEntity = _quantities.FirstOrDefault(q => q.Id == entity.Id);

            if (existingEntity == null)
            {
                return "Quantity not found.";
            }

            existingEntity.Value = entity.Value;
            existingEntity.Unit = entity.Unit;

            return "Quantity updated successfully.";
        }

        public string DeleteQuantity(int id)
        {
            QuantityMeasurementEntity existingEntity = _quantities.FirstOrDefault(q => q.Id == id);

            if (existingEntity == null)
            {
                return "Quantity not found.";
            }

            _quantities.Remove(existingEntity);
            return "Quantity deleted successfully.";
        }
    }
}