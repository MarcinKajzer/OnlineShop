using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [Authorize]
        public IActionResult Index()
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            return View(cart != null && cart.Items != null ? cart.Items : new List<CartItem>());
        }

        public async Task<IActionResult> AddProduct(AddToCartViewModel model)
        {
            Cart currentCart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            Product prod = await _productRepository.FindOne(model.Id);

            if (currentCart == null)
            {
                Cart newCart = new Cart
                {
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Quantity = model.Quantity,
                            Id = prod.Id,
                            Name = prod.Name,
                            Price = prod.Price,
                            Size = model.SelectedSize,
                            Image = model.Image
                        }
                    },
                    TotalAmount = model.Quantity * prod.Price
                    
                };
                SessionHelper.Set(HttpContext.Session, "cart", newCart);
            }
            else
            {
                CartItem findProduct = currentCart.Items.SingleOrDefault(i => i.Id == model.Id && i.Size == model.SelectedSize);

                if (findProduct != null)
                {
                    findProduct.Quantity += model.Quantity;
                }
                else
                {
                    currentCart.Items.Add(new CartItem
                    {
                        Quantity = model.Quantity,
                        Id = prod.Id,
                        Name = prod.Name,
                        Price = prod.Price,
                        Size = model.SelectedSize,
                        Image = model.Image
                    });
                    
                }
                currentCart.TotalAmount += model.Quantity * prod.Price;
                SessionHelper.Set(HttpContext.Session, "cart", currentCart);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveProduct(int productId, Size productSize)
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            CartItem findProduct = cart.Items.SingleOrDefault(i => i.Id == productId && i.Size == productSize);

            if (findProduct != null)
            {
                cart.Items.Remove(findProduct);
                cart.TotalAmount -= findProduct.Price * findProduct.Quantity;
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction(nameof(Index));
        }

        public JsonResult DecreaseQuantity(int productId, Size productSize)
        {
            return Json(SetQuantity(productId, productSize, -1));
        }

        public JsonResult IncreaseQuantity(int productId, Size productSize)
        {
            return  Json(SetQuantity(productId, productSize, 1));
        }

        [NonAction]
        public CartInfo SetQuantity(int productId, Size productSize, int value)
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            CartItem findProduct = cart.Items.SingleOrDefault(i => i.Id == productId && i.Size == productSize);

            if (findProduct != null)
            {
                findProduct.Quantity += value;
                cart.TotalAmount += value * findProduct.Price;
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }

            return new CartInfo
            {
                CurrentItemQuantity = findProduct.Quantity,
                CurrentItemAmount = findProduct.Quantity * findProduct.Price,
                TotalAmount = cart.TotalAmount,
                TotalQuantity = GetTotalQuantity()
            };
        }

        public int GetTotalQuantity()
        {
            Cart cart = SessionHelper.Get<Cart>(HttpContext.Session, "cart");

            var quantity = 0;

            if (cart != null && cart.Items.Count>0)
            {
                foreach(var item in cart.Items)
                {
                    quantity += item.Quantity;
                }
            }

            return quantity;
        }
    }
}
