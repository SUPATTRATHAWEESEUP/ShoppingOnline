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
    [Route("api/productgroup/")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupService _productGroupService;
        private readonly ILogger<ProductGroupController> _logger;

        public ProductGroupController(IProductGroupService productGroupService, ILogger<ProductGroupController> logger)
        {
            _logger = logger;
            _productGroupService = productGroupService;

        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productGroupService.GetProductGroup());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductGroupById(int id)
        {
            return Ok(await _productGroupService.GetProductGroupById(id));
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddProductGroup(AddProductGroupDto newproductgroup)
        {
            try
            {
                return Ok(await _productGroupService.AddProductGroup(newproductgroup));
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute POST");
                return BadRequest();
            }
        }
        [HttpDelete("delect/{id}")]
        public async Task<IActionResult> DelectProductGroup(int id)
        {
            try
            {
                ServiceResponse<List<ProductGroupDto>> response = await _productGroupService.DelectProductGroup(id);
                if (response.Data == null)
                {
                    return NotFound(response);
                }
                return Ok(response);

            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute DELETE");
                return BadRequest();
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductGroup(UpdateProductGroupDto update)
        {
            try
            {
                ServiceResponse<ProductGroupDto> res = await _productGroupService.UpdateProductGroup(update);
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