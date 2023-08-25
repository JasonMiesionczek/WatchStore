using WatchStore.Models;

namespace WatchStore.Repository
{
    public class ProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>() {
                new Product { Id = "001", Name = "Rolex", UnitPrice = 100, Discount = new ProductDiscount { Id = 1, Quantity = 3, TotalCost = 200} },
                new Product { Id = "002", Name = "Michael Kors", UnitPrice = 80, Discount = new ProductDiscount { Id = 2, Quantity = 2, TotalCost = 120} },
                new Product { Id = "003", Name = "Swatch", UnitPrice = 50 },
                new Product { Id = "004", Name = "Casio", UnitPrice = 30 }
            };
        }

        public Product? GetProductById(string id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
