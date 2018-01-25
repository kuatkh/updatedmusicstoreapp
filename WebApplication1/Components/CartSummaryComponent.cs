using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Components
{
    [ViewComponent(Name = "CartSummary")]
    public class CartSummaryComponent : ViewComponent
    {
        public CartSummaryComponent(WebApplication1Context dbContext)
        {
            DbContext = dbContext;
        }

        private WebApplication1Context DbContext { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = ShoppingCart.GetCart(DbContext, HttpContext);
            
            var cartItems = await cart.GetCartItems();

            ViewBag.CartCount = cartItems.Sum(c => c.Count);
            ViewBag.CartSummary = string.Join("\n", cartItems.Select(c => c.Album.Title).Distinct());

            return View();
        }
    }
}