using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DemoStandardProject.Models.Products
{

    [Table("ProductGroup")]
    public class ProductGroup
    {
        [Key]
        [Required]
        public int ProductGroupId { get; set; }
        [StringLength(255)]
        public string ProductGroupDetail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActice { get; set; }
        public virtual ICollection<Product> Products { get; set; }
         = new HashSet<Product>();
    }
}
