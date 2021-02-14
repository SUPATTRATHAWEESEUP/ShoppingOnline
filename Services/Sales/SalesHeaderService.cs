using System.Collections.Generic;
using System.Threading.Tasks;
using DemoStandardProject.DTOs.SalesDtos;
using DemoStandardProject.Models.ServiceResponse;

namespace DemoStandardProject.Services.Sales
{
    public class SalesHeaderService : ISalesHeaderService
    {
        public Task<ServiceResponse<List<GetSalesHeaderDto>>> AddSalesHeader(AddSalesHeaderDto neworder)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<GetSalesHeaderDto>>> DelectSalesHeader(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<GetSalesHeaderDto>>> GetSalesAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<GetSalesHeaderDto>> GetSalesHeaderById(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}