using Microsoft.AspNetCore.Mvc;
using WatchStore.Models;
using WatchStore.Services;

namespace WatchStore.Controllers
{
    [ApiController]
    public class CheckoutController : Controller
    {
        private readonly CheckOutService checkOutService;

        public CheckoutController(CheckOutService checkOutService)
        {
            this.checkOutService = checkOutService;
        }
        
        [HttpPost("checkout")]
        public CartResult Checkout([FromBody] string[] productIds)
        {
            var cart = this.checkOutService.CheckOutCart(productIds);

            var totalPrice = this.checkOutService.GetCartResult(cart);

            return totalPrice;
        }
    }
}
