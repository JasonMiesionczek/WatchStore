using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.Controllers;
using WatchStore.Repository;
using WatchStore.Services;

namespace WatchStore.Tests
{
    [TestClass]
    public class CheckoutControllerTests
    {
        [TestMethod]
        public void CheckoutControllerTest()
        {
            var productRepository = new ProductRepository();
            var checkoutService = new CheckOutService(productRepository);
            var controller = new CheckoutController(checkoutService);
            
            
        }
    }
}
