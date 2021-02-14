using System;

namespace DemoStandardProject.DTOs
{
    public class ProductGroupDto
    {
        public int ProductGroupId { get; set; }
        public string ProductGroupDetail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActice { get; set; }

    }
}