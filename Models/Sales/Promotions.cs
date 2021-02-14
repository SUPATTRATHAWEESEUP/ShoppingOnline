using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DemoStandardProject.Models.Products;

namespace DemoStandardProject.Models.Sales
{
    [Table("Promotions")]
    public class Promotions
    {

        [Key]
        public int PromotionId { get; set; }
        [StringLength(255)]
        public string Detail { get; set; }
        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal Discount { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public bool IsActice { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        = new HashSet<Product>();
    }
}