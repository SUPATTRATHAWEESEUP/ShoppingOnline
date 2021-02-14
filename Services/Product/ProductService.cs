using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoStandardProject.Data;
using DemoStandardProject.DTOs;
using DemoStandardProject.Models.ServiceResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DemoStandardProject.Models.Products;

namespace DemoStandardProject.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpAccessor;

        public ProductService(AppDBContext db, IMapper mapper, IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
            _mapper = mapper;
            _db = db;
        }
        public async Task<ServiceResponse<List<ProductDto>>> AddProduct(AddProductDto newProduct)
        {
            ServiceResponse<List<ProductDto>> response = new ServiceResponse<List<ProductDto>>();

            var ProductGroupId = await _db.ProductGroups
            .FirstOrDefaultAsync(x => x.ProductGroupId == newProduct.ProductGroupId);

            if (ProductGroupId == null)
            {
                response.IsSuccess = false;
                response.Message = "productGroupId not found";
            }

            var PromotionId = await _db.Promotions.FirstOrDefaultAsync(x => x.PromotionId == newProduct.PromotionId);
            if (PromotionId == null)
            {
                response.IsSuccess = false;
                response.Message = "PromotionId not found";
            }

            Product products = _mapper.Map<Product>(newProduct);


            /* var products = new Product
             {
                 productGroups = newProduct.ProductGroupId,
                 PromotionId = newProduct.PromotionId,
                 ProductCode = newProduct.ProductCode,
                 ProductDetail = newProduct.ProductDetail,
                 Price = newProduct.Price,
                 Discount = newProduct.Discount,
                 Stock = newProduct.Stock,
                 CreatedDate = response.ServerDateTime,
                 UpdateDate = response.ServerDateTime,
                 IsActice = true

             };*/


            _db.Products.Add(products);
            await _db.SaveChangesAsync();
            //response.Data = _mapper.Map<ProductDto>(products);
            response.Data = (_db.Products.Select(c => _mapper.Map<ProductDto>(c))).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<ProductDto>>> GetProductAll()
        {
            ServiceResponse<List<ProductDto>> response = new ServiceResponse<List<ProductDto>>();
            List<Product> proudcts = await _db.Products
                .Include(c => c.ProductGroup)
                .Include(c => c.Promotions)
                .ToListAsync();
            response.Data = _mapper.Map<List<ProductDto>>(proudcts);
            return response;
        }

        public async Task<ServiceResponse<ProductDto>> GetProductGetById(int Id)
        {
            ServiceResponse<ProductDto> response = new ServiceResponse<ProductDto>();

            Product product = await _db.Products
            .Include(c => c.ProductGroup)
            .Include(c => c.Promotions)
            .FirstOrDefaultAsync(x => x.ProductId == Id);

            if (product == null)
            {
                response.IsSuccess = false;
                response.Message = "ProductId Not Found";
            }
            response.Data = _mapper.Map<ProductDto>(product);
            return response;
        }

        public async Task<ServiceResponse<ProductDto>> UpdateProduct(UpdateProductDto updateProduct)
        {
            ServiceResponse<ProductDto> response = new ServiceResponse<ProductDto>();
            Product product = await _db.Products
                                    .Include(x => x.ProductGroup)
                                    .Include(x => x.Promotions)
                                    .FirstOrDefaultAsync(x => x.ProductId == updateProduct.ProductId);

            if (product == null)
            {
                // response.IsSuccess = false;
                // response.Message = "ProductId not Found";
                return ResponseResult.Failure<ProductDto>("ProductId not Found");
            }
            try
            {
                product.ProductDetail = updateProduct.ProductDetail;
                product.ProductGroupId = updateProduct.ProductGroupId;
                product.PromotionId = updateProduct.PromotionId;
                product.Stock = updateProduct.Stock;
                product.Price = updateProduct.Price;
                product.UpdateDate = DateTime.Now;
                _db.Products.Update(product);
                await _db.SaveChangesAsync();

                response.Data = _mapper.Map<ProductDto>(product);


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<ServiceResponse<List<ProductDto>>> DelectProduct(int Id)
        {

            ServiceResponse<List<ProductDto>> response = new ServiceResponse<List<ProductDto>>();
            Product product = await _db.Products.FirstOrDefaultAsync(c => c.ProductId == Id);

            if (product == null)
            {
                //  response.IsSuccess = false;
                //  response.Message = "ProductId not found";
                return ResponseResult.Failure<List<ProductDto>>("ProductId not found");
            }
            try
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                response.Data = (_db.Products.Select(c => _mapper.Map<ProductDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }
}