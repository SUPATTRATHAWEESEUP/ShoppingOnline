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
    public class ProductGroupService : IProductGroupService
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductGroupService(AppDBContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = db;
        }
        public async Task<ServiceResponse<List<ProductGroupDto>>> AddProductGroup(AddProductGroupDto newproductgroup)
        {
            ServiceResponse<List<ProductGroupDto>> res = new ServiceResponse<List<ProductGroupDto>>();
            ProductGroup group = _mapper.Map<ProductGroup>(newproductgroup);
            _db.ProductGroups.Add(group);
            await _db.SaveChangesAsync();
            res.Data = (_db.ProductGroups.Select(c => _mapper.Map<ProductGroupDto>(c))).ToList();
            return res;
        }
        public async Task<ServiceResponse<List<ProductGroupDto>>> DelectProductGroup(int Id)
        {
            ServiceResponse<List<ProductGroupDto>> response = new ServiceResponse<List<ProductGroupDto>>();
            ProductGroup productGroup = await _db.ProductGroups.FirstOrDefaultAsync(x => x.ProductGroupId == Id);
            if (productGroup == null)
            {
                //  response.IsSuccess = false;
                //  response.Message = "ProductId not found";
                return ResponseResult.Failure<List<ProductGroupDto>>("ProductGroupId not found");
            }
            try
            {
                _db.ProductGroups.Remove(productGroup);
                await _db.SaveChangesAsync();
                response.Data = (_db.ProductGroups.Select(c => _mapper.Map<ProductGroupDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<ProductGroupDto>>> GetProductGroup()
        {
            ServiceResponse<List<ProductGroupDto>> res = new ServiceResponse<List<ProductGroupDto>>();
            List<ProductGroup> productGroups = await _db.ProductGroups.ToListAsync();
            res.Data = _mapper.Map<List<ProductGroupDto>>(productGroups);
            return res;
        }

        public async Task<ServiceResponse<ProductGroupDto>> GetProductGroupById(int Id)
        {
            ServiceResponse<ProductGroupDto> res = new ServiceResponse<ProductGroupDto>();
            ProductGroup productGroup = await _db.ProductGroups.FirstOrDefaultAsync(x => x.ProductGroupId == Id);
            if (productGroup == null)
            {
                res.IsSuccess = false;
                res.Message = "ProductId Not Found";
            }
            res.Data = _mapper.Map<ProductGroupDto>(productGroup);
            return res;
        }

        public async Task<ServiceResponse<ProductGroupDto>> UpdateProductGroup(UpdateProductGroupDto update)
        {
            ServiceResponse<ProductGroupDto> res = new ServiceResponse<ProductGroupDto>();
            ProductGroup productGroup = await _db.ProductGroups.FirstOrDefaultAsync(x => x.ProductGroupId == update.ProductGroupId);
            if (productGroup == null)
            {
                return ResponseResult.Failure<ProductGroupDto>("ProductGroup Not Found");
            }
            try
            {
                productGroup.ProductGroupDetail = update.ProductGroupDetail;
                _db.ProductGroups.Update(productGroup);
                await _db.SaveChangesAsync();
                res.Data = _mapper.Map<ProductGroupDto>(productGroup);

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