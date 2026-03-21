using System.Collections.Generic;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppModel.Entity;
using QuantityMeasurementAppModel.Requests;
using QuantityMeasurementAppRepositoryLayer;

namespace QuantityMeasurementAppBusinessLayer.Services
{
    public class QuantityMeasurementServiceImpl : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _repository;

        public QuantityMeasurementServiceImpl(IQuantityMeasurementRepository repository)
        {
            _repository = repository;
        }

        public string AddQuantity(QuantityRequest request)
        {
            QuantityMeasurementEntity entity = new QuantityMeasurementEntity
            {
                Value = request.Value,
                Unit = request.UnitType
            };

            return _repository.AddQuantity(entity);
        }

        public List<QuantityDTO> GetAllQuantities()
        {
            List<QuantityMeasurementEntity> entities = _repository.GetAllQuantities();
            List<QuantityDTO> dtoList = new List<QuantityDTO>();

            foreach (QuantityMeasurementEntity entity in entities)
            {
                dtoList.Add(new QuantityDTO
                {
                    Id = entity.Id,
                    Value = entity.Value,
                    Unit = entity.Unit
                });
            }

            return dtoList;
        }

        public QuantityDTO GetQuantityById(int id)
        {
            QuantityMeasurementEntity entity = _repository.GetQuantityById(id);

            if (entity == null)
            {
                return null;
            }

            return new QuantityDTO
            {
                Id = entity.Id,
                Value = entity.Value,
                Unit = entity.Unit
            };
        }

        public string UpdateQuantity(QuantityDTO quantityDto)
        {
            QuantityMeasurementEntity entity = new QuantityMeasurementEntity
            {
                Id = quantityDto.Id,
                Value = quantityDto.Value,
                Unit = quantityDto.Unit
            };

            return _repository.UpdateQuantity(entity);
        }

        public string DeleteQuantity(int id)
        {
            return _repository.DeleteQuantity(id);
        }
    }
}