using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppModel.DTOs;
using System;
using System.Linq;
using QuantityMeasurementAppModel.Enums;

namespace QuantityMeasurementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuantityController : ControllerBase
    {
        private readonly IQuantityMeasurementService _service;

        public QuantityController(IQuantityMeasurementService service)
        {
            _service = service;
        }

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] CompareRequestDto request)
        {
            var result = _service.Compare(request);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddRequestDto request)
        {
            var result = _service.Add(request);
            return Ok(result);
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] AddRequestDto request)
        {
            var result = _service.Subtract(request);
            return Ok(result);
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromBody] CompareRequestDto request)
        {
            var result = _service.Divide(request);
            return Ok(result);
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConvertRequestDto request)
        {
            var result = _service.Convert(request);
            return Ok(result);
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            var result = _service.GetHistory();
            return Ok(result);
        }

        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var result = _service.GetCount();
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