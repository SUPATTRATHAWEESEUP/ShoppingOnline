
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStandardProject.Models.Products
{
    public class ProductStockLog
    {
        [Key]
        public int StockLogId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal AmountBefore { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal NewEdit { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal AmountAfter { get; set; }
        public int TypeAdd { get; set; }

        [StringLength(255)]
        public string TextRemark { get; set; }
        public DateTime? Createdate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActice { get; set; } = true;
        public virtual Product Product { get; set; }
    }
}