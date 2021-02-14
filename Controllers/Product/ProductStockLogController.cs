using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoStandardProject.DTOs;
using DemoStandardProject.Models.ServiceResponse;
using DemoStandardProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoStandardProject.Controllers.Product
{
    [ApiController]
    [Route("api/stock/")]
    public class ProductStockLogController : ControllerBase
    {
        private readonly IProductStockLogService _productStockService;
        private readonly ILogger<ProductStockLogController> _logger;

        public ProductStockLogController(IProductStockLogService productStockService, ILogger<ProductStockLogController> logger)
        {
            _productStockService = productStockService;
            _logger = logger;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productStockService.GetStockLogAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockLogById(int id)
        {
            return Ok(await _productStockService.GetStockLogById(id));
        }
        [HttpPost("add")]
        public async Task<IActionResult> AppStockLog(AddProductStockLogDto stockLogDto)
        {

            return Ok(await _productStockService.AddStockLog(stockLogDto));
        }
        [HttpDelete("delect/{id}")]
        public async Task<IActionResult> DelectProductStockLog(int Id)
        {
            ServiceResponse<List<GetProductStockLogDto>> res = await _productStockService.DelectStockLog(Id);
            if (res.Data == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductStockUpdate(UpdateStockProduct update)
        {
            try
            {
                ServiceResponse<GetProductStockLogDto> res = await _productStockService.UpdateStockLog(update);
                if (res.Data == null)
                {
                    return NotFound(res);
                }
                return Ok(res);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute put");
                return BadRequest();
            }
        }


    }
}