using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DemoStandardProject.Models.Products;

namespace DemoStandardProject.Models.Sales
{
    [Table("SalesDetail")]
    public class SalesDetail
    {
        [Key]
        [Required]
        public int SalesDetailId { get; set; }

        [ForeignKey(nameof(SalesHeader))]
        public int SalesHeaderId { get; set; }

        [ForeignKey(nameof(Product))]
        public string ProductCode { get; set; }
        [Required]
        public int ItemCount { get; set; }
        public DateTime OrderCreatdDate { get; set; }
        public DateTime OrderUpdateDate { get; set; }
        public bool IsAcctice { get; set; }
    }
}