namespace Product.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public int MOQ { get; set; }
        public string? Brand { get; set; }
        public decimal? LastPrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal? MinSalePrice { get; set; }
        public string? DiscountType { get; set; }
        public decimal? DiscountValue { get; set; }
    }
}
