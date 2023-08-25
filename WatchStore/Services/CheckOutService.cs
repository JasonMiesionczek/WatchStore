using Microsoft.Extensions.ObjectPool;
using WatchStore.Models;
using WatchStore.Repository;

namespace WatchStore.Services
{
    public class CheckOutService
    {
        private readonly ProductRepository repository;
        public CheckOutService(ProductRepository repository) 
        { 
            this.repository = repository;
        }

        public Cart CheckOutCart(string[] productIds)
        {
            var cart = new Cart();
            foreach (var product in productIds)
            {
                AddProductToCart(cart, product);
            }

            ApplyDiscounts(cart);

            return cart;
        }

        public CartResult GetCartResult(Cart cart)
        {
            var totalPrice = cart.CartEntries.Select(e => e.TotalCost).Sum();

            return new CartResult { Price = totalPrice };
        }

        private void AddProductToCart(Cart cart, string productId)
        {
            var product = repository.GetProductById(productId) ?? throw new Exception("Invalid product");
            var existingEntry = cart.CartEntries.FirstOrDefault(e => e.ProductID == productId);
            if (existingEntry != null)
            {
                existingEntry.Quantity += 1;
                existingEntry.TotalCost += product.UnitPrice;
            }
            else
            {
                cart.CartEntries.Add(new CartEntry { ProductID = productId, Quantity = 1, TotalCost = product.UnitPrice });
            }
        }

        private void ApplyDiscounts(Cart cart)
        {
            foreach (var entry in cart.CartEntries)
            {
                var tempQuantity = entry.Quantity;
                var product = repository.GetProductById(entry.ProductID);
                if (product == null) { continue; }

                var discount = product.Discount;
                if (discount == null) { continue; }
                
                while (tempQuantity >= discount.Quantity)
                {
                    // Subtract the original cost for these items
                    entry.TotalCost -= (discount.Quantity * product.UnitPrice);
                    entry.TotalCost += discount.TotalCost;
                    tempQuantity -= discount.Quantity;
                }
            }
        }

        
    }
}
