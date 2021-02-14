using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStandardProject.Models.Sales
{
    public class Invoice
    {
        [Key]
        [StringLength(30)]
        public string InvoiceCode { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal? TotalInvoice { get; set; }

        [Column(TypeName = "decimal(16,2)")]
        public decimal? TotalDiscount { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? UserId { get; set; }

        [ForeignKey(nameof(SalesHeader))]
        public int? SalesHeaderId { get; set; }
    }
}