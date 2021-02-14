using System.Collections.Generic;
using System.Threading.Tasks;
using DemoStandardProject.DTOs;
using DemoStandardProject.Models.ServiceResponse;

namespace DemoStandardProject.Services
{
    public interface IProductGroupService
    {
        Task<ServiceResponse<List<ProductGroupDto>>> GetProductGroup();
        Task<ServiceResponse<ProductGroupDto>> GetProductGroupById(int Id);
        Task<ServiceResponse<List<ProductGroupDto>>> AddProductGroup(AddProductGroupDto newproductgroup);
        Task<ServiceResponse<List<ProductGroupDto>>> DelectProductGroup(int Id);
        Task<ServiceResponse<ProductGroupDto>> UpdateProductGroup(UpdateProductGroupDto updateProductGroup);
    }
}