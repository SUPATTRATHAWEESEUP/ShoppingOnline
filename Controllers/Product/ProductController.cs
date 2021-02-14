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
    [Route("api/product/")]
    public class ProductController : ControllerBase
    {
        ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetProductAll()
        {
            return Ok(await _productService.GetProductAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _productService.GetProductGetById(id));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(AddProductDto newproduct)
        {
            try
            {
                return Ok(await _productService.AddProduct(newproduct));
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute POST");
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProduct)
        {
            try
            {
                ServiceResponse<ProductDto> response = await _productService.UpdateProduct(updateProduct);
                if (response.Data == null)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute PUT");
                return BadRequest();
            }
        }

        [HttpDelete("delect/{id}")]
        public async Task<IActionResult> DelectProduct(int id)
        {
            try
            {
                ServiceResponse<List<ProductDto>> response = await _productService.DelectProduct(id);
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
    }
}