using System.Collections.Generic;
using System.Threading.Tasks;
using DemoStandardProject.DTOs.SalesDtos;
using DemoStandardProject.Models.ServiceResponse;

namespace DemoStandardProject.Services.Sales
{
    public interface ISalesHeaderService
    {
        Task<ServiceResponse<List<GetSalesHeaderDto>>> GetSalesAll();
        Task<ServiceResponse<GetSalesHeaderDto>> GetSalesHeaderById(int Id);
        Task<ServiceResponse<List<GetSalesHeaderDto>>> AddSalesHeader(AddSalesHeaderDto neworder);
        Task<ServiceResponse<List<GetSalesHeaderDto>>> DelectSalesHeader(int Id);
    }
}