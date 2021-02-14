using System;
using DemoStandardProject.Models.Products;

namespace DemoStandardProject.DTOs
{
    public class UpdateStockProduct
    {

        public int StockLogId { get; set; }
        public int ProductId { get; set; }
        public decimal AmountBefore { get; set; }
        public decimal NewEdit { get; set; }
        public decimal AmountAfter { get; set; }
        public string Remark { get; set; }
        public int TypeAdd { get; set; }
        public bool IsActice { get; set; }

        public string TextRemark { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}