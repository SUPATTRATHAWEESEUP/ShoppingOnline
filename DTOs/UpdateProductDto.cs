using System;

namespace DemoStandardProject.DTOs
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string ProductDetail { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Stock { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActice { get; set; }
        public int ProductGroupId { get; set; }
        public int PromotionId { get; set; }
    }
}