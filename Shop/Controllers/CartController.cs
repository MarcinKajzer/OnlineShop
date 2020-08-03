using Entities;
using Microsoft.AspNetCore.Mvc;
using Shop.Common;
using Shop.DataAcces.Interfaces;
using Shop.Helpers;
using Shop.Models;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Index()
        {
            List<CartItem> cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");

            return View(cart != null ? cart : new List<CartItem>());
        }

        public async Task<IActionResult> AddProduct(AddToCartViewModel model)
        {
            List<CartItem> currentCart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");

            Product prod = await _productRepository.FindOne(model.Id);

            if (currentCart == null)
            {
                List<CartItem> newCart = new List<CartItem>
                {
                    new CartItem
                    {
                        Quantity = model.Quantity,
                        Id = prod.Id,
                        Name = prod.Name,
                        Price = prod.Price,
                        Size = model.SelectedSize
                    }
                };
                SessionHelper.Set(HttpContext.Session, "cart", newCart);
            }
            else
            {
                CartItem findProduct = currentCart.SingleOrDefault(i => i.Id == model.Id && i.Size == model.SelectedSize);

                if (findProduct != null)
                {
                    findProduct.Quantity += model.Quantity;
                }
                else
                {
                    currentCart.Add(new CartItem
                    {
                        Quantity = model.Quantity,
                        Id = prod.Id,
                        Name = prod.Name,
                        Price = prod.Price,
                        Size = model.SelectedSize
                    }); ;
                }
                SessionHelper.Set(HttpContext.Session, "cart", currentCart);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveProduct(int productId, Size productSize)
        {
            List<CartItem> cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");

            CartItem findProduct = cart.SingleOrDefault(i => i.Id == productId && i.Size == productSize);

            if (findProduct != null)
            {
                cart.Remove(findProduct);
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SetQuantity(int productId, Size productSize, int quantity)
        {
            List<CartItem> cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");

            CartItem findProduct = cart.SingleOrDefault(i => i.Id == productId);

            if (findProduct != null)
            {
                findProduct.Quantity = quantity;
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
