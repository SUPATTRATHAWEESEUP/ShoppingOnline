using System;

namespace DemoStandardProject.DTOs
{
    public class UpdateProductGroupDto
    {
        public int ProductGroupId { get; set; }
        public string ProductGroupDetail { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActice { get; set; } = true;
    }
}