using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DemoStandardProject.Models.Sales;


namespace DemoStandardProject.Models.Products
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(30)]
        public string ProductCode { get; set; }

        [StringLength(255)]
        public string ProductDetail { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal Stock { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActice { get; set; }

        [ForeignKey(nameof(ProductGroup))]
        public int ProductGroupId { get; set; }

        [ForeignKey(nameof(Promotions))]
        public int PromotionId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual Promotions Promotions { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
         = new HashSet<SalesDetail>();
        public virtual ICollection<ProductStockLog> ProductStockLogs { get; set; }
        = new HashSet<ProductStockLog>();

    }
}