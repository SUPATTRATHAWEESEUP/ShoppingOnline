
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoStandardProject.Data;
using DemoStandardProject.DTOs;
using DemoStandardProject.Models.Products;
using DemoStandardProject.Models.ServiceResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DemoStandardProject.Services
{
    public class ProductStockLogService : IProductStockLogService
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public ProductStockLogService(AppDBContext db, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _db = db;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<ServiceResponse<List<GetProductStockLogDto>>> AddStockLog(AddProductStockLogDto newstockLogDto)
        {
            ServiceResponse<List<GetProductStockLogDto>> res = new ServiceResponse<List<GetProductStockLogDto>>();

            var Product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == newstockLogDto.ProductId);
            var stock = Product.Stock;

            if (Product == null)
            {
                res.IsSuccess = false;
                res.Message = "date not found";
            }
            if (newstockLogDto.TypeAdd == 2)    // 2 = ลบ
            {
                if (newstockLogDto.NewEdit > stock)
                {
                    res.IsSuccess = false;
                    res.Message = " calculate fail";
                }
                else
                {
                    Product.Stock = (stock - newstockLogDto.NewEdit);
                }
            }
            else
            {
                Product.Stock = (newstockLogDto.NewEdit + stock);
            }

            if (res.IsSuccess == true)
            {

                _db.Products.Update(Product);
                await _db.SaveChangesAsync();

                ProductStockLog productStockLog = _mapper.Map<ProductStockLog>(newstockLogDto);
                _db.ProductStockLogs.Add(productStockLog);

                await _db.SaveChangesAsync();

                res.Data = (_db.ProductStockLogs.Select(c => _mapper.Map<GetProductStockLogDto>(c))).ToList();

            }

            return res;
        }

        public async Task<ServiceResponse<List<GetProductStockLogDto>>> DelectStockLog(int Id)
        {
            ServiceResponse<List<GetProductStockLogDto>> res = new ServiceResponse<List<GetProductStockLogDto>>();
            ProductStockLog stockLog = await _db.ProductStockLogs
                    .Include(c => c.Product)
                    .FirstOrDefaultAsync(c => c.StockLogId == Id);
            if (stockLog == null)
            {
                return ResponseResult.Failure<List<GetProductStockLogDto>>("Data Not Found");
            }
            try
            {
                _db.ProductStockLogs.Remove(stockLog);
                await _db.SaveChangesAsync();
                res.Data = (_db.ProductStockLogs.Select(c => _mapper.Map<GetProductStockLogDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }
        public async Task<ServiceResponse<List<GetProductStockLogDto>>> GetStockLogAll()
        {
            ServiceResponse<List<GetProductStockLogDto>> res = new ServiceResponse<List<GetProductStockLogDto>>();
            List<ProductStockLog> stockLogs = await _db.ProductStockLogs
                    .Include(c => c.Product)
                   .ToListAsync();
            res.Data = _mapper.Map<List<GetProductStockLogDto>>(stockLogs);
            return res;
        }
        public async Task<ServiceResponse<GetProductStockLogDto>> GetStockLogById(int Id)
        {
            ServiceResponse<GetProductStockLogDto> res = new ServiceResponse<GetProductStockLogDto>();
            ProductStockLog stockLog = await _db.ProductStockLogs
                                        .Include(c => c.Product)
                                        .FirstOrDefaultAsync(x => x.StockLogId == Id);
            if (stockLog == null)
            {
                res.IsSuccess = false;
                res.Message = "Data not found";
            }
            res.Data = _mapper.Map<GetProductStockLogDto>(stockLog);
            return res;
        }

        public async Task<ServiceResponse<GetProductStockLogDto>> UpdateStockLog(UpdateStockProduct updateStock)
        {
            ServiceResponse<GetProductStockLogDto> res = new ServiceResponse<GetProductStockLogDto>();
            ProductStockLog stockLog = await _db.ProductStockLogs
                                     .Include(x => x.Product)
                                     .FirstOrDefaultAsync(c => c.StockLogId == updateStock.StockLogId);

            if (stockLog == null)
            {
                return ResponseResult.Failure<GetProductStockLogDto>("data not found");
            }

            try
            {
                stockLog.NewEdit = updateStock.NewEdit;
                stockLog.UpdatedDate = DateTime.Now;
                stockLog.AmountAfter = updateStock.AmountAfter;
                stockLog.AmountBefore = updateStock.AmountBefore;
                stockLog.TextRemark = updateStock.TextRemark;
                stockLog.IsActice = updateStock.IsActice;
                _db.ProductStockLogs.Update(stockLog);
                await _db.SaveChangesAsync();
                res.Data = _mapper.Map<GetProductStockLogDto>(stockLog);
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;

        }
    }
}