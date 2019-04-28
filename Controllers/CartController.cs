using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OtherPerspectivesWebApp.Data;
using OtherPerspectivesWebApp.Models;
using OtherPerspectivesWebApp.ViewModels;

namespace OtherPerspectivesWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly OtherPerspectivesContext _dbContext;
        
        public CartController(Cart cart, OtherPerspectivesContext context)
        {
            _cart = cart;
            _dbContext = context;
        }
        
        public IActionResult Index()
        {
            var items = _cart.GetCartItems();
            _cart.Items = items;

            var cartVM = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };

            return View(cartVM);
        }

        public IActionResult AddToCart(int productId)
        {
            var selectedProduct = _dbContext.Products.FirstOrDefault(x => x.Id == productId);

            if (selectedProduct != null)
            {
                _cart.AddItem(selectedProduct, 1);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var selectedProduct = _dbContext.Products.FirstOrDefault(x => x.Id == productId);

            if (selectedProduct != null)
            {
                _cart.RemoveItem(selectedProduct);
            }

            return RedirectToAction("Index");
        }
    }
}