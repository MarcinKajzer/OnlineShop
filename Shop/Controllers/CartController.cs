using Entities;
using Microsoft.AspNetCore.Mvc;
using Shop.Common;
using Shop.DataAcces.Interfaces;
using Shop.Helpers;
using Shop.Models;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            return View(cart != null && cart.Items != null ? cart.Items : new List<CartItem>());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductToCartViewModel model)
        {
            Product prod = await _productRepository.FindOne(model.Id);
            if (prod == null)
                return NotFound();

            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            if (cart == null)
                cart = new Cart();

            cart.AddItem(new CartItem(model));

            SessionHelper.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult RemoveProduct(int productId, Size productSize)
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            cart.RemoveItem(productId, productSize);
            
            SessionHelper.Set(HttpContext.Session, "cart", cart);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public int GetTotalQuantity()
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            if(cart != null)
                return cart.TotalQuantity;

            return 0;
        }

        [HttpGet]
        public void DecreaseQuantity(int productId, Size productSize)
        {
            ChangeQunatity(productId, productSize, -1);
        }

        [HttpGet]
        public void IncreaseQuantity(int productId, Size productSize)
        {
            ChangeQunatity(productId, productSize, 1);
        }

        [NonAction]
        public void ChangeQunatity(int productId, Size productSize, int difference)
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            cart.ChangeQuantity(productId, productSize, difference);

            SessionHelper.Set(HttpContext.Session, "cart", cart);
        }

        [HttpGet]
        public JsonResult GetSingleItemInfo(int productId, Size productSize)
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            return Json(cart.GetSingleIntemInfo(productId, productSize));
        }

        [HttpGet]
        public JsonResult GetTotalInfo()
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            return Json(cart.GetTotalInfo());
        }
    }
}
