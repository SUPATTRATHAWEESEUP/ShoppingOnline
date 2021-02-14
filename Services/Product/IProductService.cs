using System.Collections.Generic;
using System.Threading.Tasks;
using DemoStandardProject.DTOs;
using DemoStandardProject.Models;
using DemoStandardProject.Models.ServiceResponse;

namespace DemoStandardProject.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductDto>>> GetProductAll();
        Task<ServiceResponse<ProductDto>> GetProductGetById(int Id);
        Task<ServiceResponse<List<ProductDto>>> AddProduct(AddProductDto addProductDto);
        Task<ServiceResponse<ProductDto>> UpdateProduct(UpdateProductDto updateProduct);
        Task<ServiceResponse<List<ProductDto>>> DelectProduct(int Id);
    }
}