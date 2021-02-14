using System;

namespace DemoStandardProject.DTOs
{
    public class AddProductGroupDto
    {
        public string ProductGroupDetail { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public bool? IsActice { get; set; } = true;
    }
}