using AutoMapper;
using DemoStandardProject.DTOs;
using System.Collections.Generic;
using DemoStandardProject.Models.Sales;
using DemoStandardProject.Models.Products;

namespace DemoStandardProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<ProductGroup, ProductGroupDto>();
            CreateMap<ProductGroup, GetProductGroupName>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductStockLog, GetProductStockLogDto>();
            CreateMap<AddProductGroupDto, ProductGroup>();
            CreateMap<AddProductDto, Product>();
            CreateMap<Promotions, GetPromotion>();
            CreateMap<AddProductStockLogDto, ProductStockLog>();
            CreateMap<Product, GetProductName>();

            // .ForMember(x => x.ProductGroupId, x => x.MapFrom(x => x.ProductGroupId))
            //  .ForMember(x => x.PromotionId, x => x.MapFrom(x => x.PromotionId));
        }



    }
}