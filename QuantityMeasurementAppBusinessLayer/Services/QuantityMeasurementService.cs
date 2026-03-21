using System.Collections.Generic;
using QuantityMeasurementAppModel;
using QuantityMeasurementAppRepositoryLayer;

namespace QuantityMeasurementAppBusinessLayer
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository repository;

        public QuantityMeasurementService(IQuantityMeasurementRepository repository)
        {
            this.repository = repository;
        }

        public void SaveMeasurement(QuantityMeasurementEntity entity)
        {
            repository.Save(entity);
        }

        public List<QuantityMeasurementEntity> GetAllMeasurements()
        {
            return repository.GetAll();
        }

        public int GetTotalMeasurements()
        {
            return repository.GetCount();
        }

        public void DeleteAllMeasurements()
        {
            repository.DeleteAll();
        }
    }
}