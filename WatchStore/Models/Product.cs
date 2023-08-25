namespace WatchStore.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public int UnitPrice { get; set; }

        public ProductDiscount? Discount { get; set; }
    }
}
