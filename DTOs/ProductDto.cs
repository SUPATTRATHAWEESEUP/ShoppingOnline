using System;
using System.Collections.Generic;

namespace DemoStandardProject.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDetail { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActice { get; set; }
        //  public int ProductGroupId { get; set; }
        //  public int PromotionId { get; set; }
        public GetProductGroupName ProductGroup { get; set; }
        public GetPromotion Promotions { get; set; }

    }
}