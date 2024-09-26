namespace WMS_backend.Models.Product
{
    public class ProductVariantDTO
    {
        public Guid ProductVariantId { get; set; }
        public string? SKU { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string? Barcode1 { get; set; }
        public string? Barcode2 { get; set; }
        public string? Barcode3 { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public float? PurchasePrice { get; set; }
        public float? RetailPrice { get; set; }
        public float? TaxRate { get; set; }
        public bool IsArchived { get; set; } = false;
    }
}
