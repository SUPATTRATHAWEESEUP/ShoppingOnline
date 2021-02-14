using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStandardProject.Models.Sales
{
    [Table("SalesHeader")]
    public class SalesHeader
    {
        [Key]
        [Required]
        public int SalesHeaderId { get; set; }
        public int UserId { get; set; }
        [Required]
        public int Totalcount { get; set; }
        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal TotalAmount { get; set; }
        [Required]
        [Column(TypeName = "decimal(16,2)")]
        public decimal TotalDiscount { get; set; }
        public int SalesStatusId { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        = new HashSet<SalesDetail>();

        public virtual ICollection<Invoice> Invoices { get; set; }
        = new HashSet<Invoice>();
    }
}