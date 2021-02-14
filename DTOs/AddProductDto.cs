using System;

namespace DemoStandardProject.DTOs
{
    public class AddProductDto
    {
        public string ProductCode { get; set; }
        public string ProductDetail { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Stock { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public bool IsActice { get; set; }
        public int ProductGroupId { get; set; }
        public int PromotionId { get; set; }
    }
}