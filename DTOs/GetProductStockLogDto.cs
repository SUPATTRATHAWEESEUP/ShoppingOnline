using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DemoStandardProject.Models.Products;

namespace DemoStandardProject.DTOs
{
    public class GetProductStockLogDto
    {
        public int StockLogId { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal AmountBefore { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal NewEdit { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal AmountAfter { get; set; }
        public int TypeAdd { get; set; }
        public GetProductName Product { get; set; }

        [StringLength(255)]
        public string TextRemark { get; set; }
        public DateTime? Createdate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActice { get; set; } = true;
    }
}