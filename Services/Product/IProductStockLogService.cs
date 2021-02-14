using System.Collections.Generic;
using System.Threading.Tasks;
using DemoStandardProject.DTOs;
using DemoStandardProject.Models.ServiceResponse;

namespace DemoStandardProject.Services
{
    public interface IProductStockLogService
    {
        Task<ServiceResponse<List<GetProductStockLogDto>>> GetStockLogAll();
        Task<ServiceResponse<GetProductStockLogDto>> GetStockLogById(int Id);
        Task<ServiceResponse<List<GetProductStockLogDto>>> AddStockLog(AddProductStockLogDto newstockLogDto);
        Task<ServiceResponse<List<GetProductStockLogDto>>> DelectStockLog(int Id);
        Task<ServiceResponse<GetProductStockLogDto>> UpdateStockLog(UpdateStockProduct updateStock);

    }
}