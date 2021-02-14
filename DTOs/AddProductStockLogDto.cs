using System;
using DemoStandardProject.Models.Products;

namespace DemoStandardProject.DTOs
{
    public class AddProductStockLogDto
    {
        // public int StockLogId { get; set; }
        public int ProductId { get; set; }
        public decimal AmountBefore { get; set; }
        public decimal NewEdit { get; set; }
        public decimal AmountAfter { get; set; }
        public string Remark { get; set; }
        public int TypeAdd { get; set; }
        public virtual Product Product { get; set; }
        public DateTime? Createdate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActice { get; set; } = true;
    }
}