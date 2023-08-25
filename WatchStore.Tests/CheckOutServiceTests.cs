using WatchStore.Repository;
using WatchStore.Services;

namespace WatchStore.Tests
{
    [TestClass]
    public class CheckOutServiceTests
    {
        [TestMethod]
        public void CheckoutCartCorrectTotals()
        {
            var productRepository = new ProductRepository();
            var checkoutService = new CheckOutService(productRepository);

            var cart = checkoutService.CheckOutCart(new string[] { "001", "001", "002", "003", "001", "001" });

            Assert.IsNotNull(cart);
            Assert.AreEqual(cart.CartEntries.Count, 3);
            
            var firstEntry = cart.CartEntries[0];
            
            Assert.AreEqual(firstEntry.Quantity, 4);
            Assert.AreEqual(firstEntry.TotalCost, 300);
        }

        [TestMethod]
        public void CheckoutCartCartResult()
        {
            var productRepository = new ProductRepository();
            var checkoutService = new CheckOutService(productRepository);

            var cart = checkoutService.CheckOutCart(new string[] { "001", "001", "002", "003", "001", "001" });
            var result = checkoutService.GetCartResult(cart);

            Assert.AreEqual(result.Price, 430);
        }
    }
}