using System;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppModel.Requests;

namespace QuantityMeasurementApp.Console.Controllers
{
    public class QuantityMeasurementController
    {
        private readonly IQuantityMeasurementService _service;

        public QuantityMeasurementController(IQuantityMeasurementService service)
        {
            _service = service;
        }

        public void AddQuantity(QuantityRequest request)
        {
            try
            {
                _service.AddQuantity(request);
                System.Console.WriteLine("Quantity added successfully.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error while adding quantity: {ex.Message}");
            }
        }

        public void GetAllQuantities()
        {
            try
            {
                var quantities = _service.GetAllQuantities();

                if (quantities == null)
                {
                    System.Console.WriteLine("No quantities found.");
                    return;
                }

                foreach (var quantity in quantities)
                {
                    System.Console.WriteLine($"Id: {quantity.Id}, Unit: {quantity.Unit}, Value: {quantity.Value}");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error while fetching quantities: {ex.Message}");
            }
        }

        public void GetQuantityById(int id)
        {
            try
            {
                var quantity = _service.GetQuantityById(id);

                if (quantity == null)
                {
                    System.Console.WriteLine("Quantity not found.");
                    return;
                }

                System.Console.WriteLine($"Id: {quantity.Id}, Unit: {quantity.Unit}, Value: {quantity.Value}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error while fetching quantity: {ex.Message}");
            }
        }

        public void UpdateQuantity(QuantityDTO quantityDto)
        {
            try
            {
                _service.UpdateQuantity(quantityDto);
                System.Console.WriteLine("Quantity updated successfully.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error while updating quantity: {ex.Message}");
            }
        }

        public void DeleteQuantity(int id)
        {
            try
            {
                _service.DeleteQuantity(id);
                System.Console.WriteLine("Quantity deleted successfully.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error while deleting quantity: {ex.Message}");
            }
        }
    }
}