using System.ComponentModel.DataAnnotations.Schema;

namespace DemoStandardProject.DTOs.SalesDtos
{
    public class GetSalesHeaderDto
    {
        public int SalesHeaderId { get; set; }
        public int UserId { get; set; }
        public int Totalcount { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal TotalDiscount { get; set; }
        public int SalesStatusId { get; set; }
    }
}