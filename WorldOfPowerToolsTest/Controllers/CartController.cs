using Microsoft.AspNetCore.Mvc;
using WorldOfPowerToolsTest.Models;
using WorldOfPowerToolsTest.Models.ViewModels;

namespace WorldOfPowerToolsTest
{
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly Cart _cartService;
        public CartController(IProductRepository repository, Cart cartService)
        {
            _repository = repository;
            _cartService = cartService;
        }

        public ViewResult Index(string returnUrl) => View(new CartIndexViewModel { Cart = _cartService, ReturnUrl = returnUrl });

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _cartService.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _cartService.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}