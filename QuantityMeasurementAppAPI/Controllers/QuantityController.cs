using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using QuantityMeasurementAppModel.Enums;

namespace QuantityMeasurementAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuantityController : ControllerBase
    {
        private readonly IQuantityService _quantityService;

        public QuantityController(IQuantityService quantityService)
        {
            _quantityService = quantityService;
        }

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] CompareRequestDto request)
        {
            var result = _quantityService.Compare(request);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddRequestDto request)
        {
            var result = _quantityService.Add(request);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] AddRequestDto request)
        {
            var result = _quantityService.Subtract(request);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] CompareRequestDto request)
        {
            var result = _quantityService.Divide(request);
            return Ok(result);
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConvertRequestDto request)
        {
            var result = _quantityService.Convert(request);
            return Ok(result);
        }
        [HttpGet("operationtype")]
        public IActionResult GetOperationTypes()
        {
            var result = Enum.GetValues(typeof(OperationType))
                             .Cast<OperationType>()
                             .Select(x => new
                             {
                                 Id = (int)x,
                                 Name = x.ToString()
                             })
                             .ToList();

            return Ok(new
            {
                Success = true,
                Message = "Operation types fetched successfully",
                Data = result
            });
        }

        [HttpGet("measurementtype")]
        public IActionResult GetMeasurementTypes()
        {
            var result = Enum.GetValues(typeof(MeasurementType))
                             .Cast<MeasurementType>()
                             .Select(x => new
                             {
                                 Id = (int)x,
                                 Name = x.ToString()
                             })
                             .ToList();

            return Ok(new
            {
                Success = true,
                Message = "Measurement types fetched successfully",
                Data = result
            });
        }
    }
}