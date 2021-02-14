namespace DemoStandardProject.DTOs
{
    public class GetProductName
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDetail { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Stock { get; set; }
    }
}