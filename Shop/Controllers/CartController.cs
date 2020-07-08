using Entities;
using Microsoft.AspNetCore.Mvc;
using Shop.Common;
using Shop.DataAcces.Interfaces;
using Shop.Helpers;
using Shop.Models;
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

        [HttpPost]
        public async Task<IActionResult> AddProduct(int productId, int quantity, SizeEnum size)
        {
            List<CartItem> currentCart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");

            if (currentCart == null)
            {
                Product prod = await _productRepository.FindOne(productId);

                ProductModel prodModel = new ProductModel
                {
                    Category = prod.Category,
                    Color = prod.Color,
                    Description = prod.Description,
                    Gender = prod.Gender,
                    Id = prod.Id,
                    Name = prod.Name,
                    Price = prod.Price,
                    Sizes = new List<SizeModel>
                    {
                        new SizeModel
                        {
                            Name = size,
                            Quantity = quantity
                        }
                    }
                };

                List<CartItem> newCart = new List<CartItem>
                {
                    new CartItem
                    {
                        Product = prodModel,
                        Quantity = quantity
                    }
                };
                SessionHelper.Set(HttpContext.Session, "cart", newCart);
            }
            else
            {
                CartItem findProduct = currentCart.SingleOrDefault(i => i.Product.Id == productId);

                if (findProduct != null)
                {
                    findProduct.Quantity += quantity;

                    if(findProduct.Product.Sizes.Where(s => s.Name == size).Count() == 0)
                    {
                        findProduct.Product.Sizes.Add(new SizeModel
                        {
                            Name = size,
                            Quantity = quantity
                        });
                    }
                    else
                    {
                        for (int i = 0; i < findProduct.Product.Sizes.Count(); i++)
                        {
                            if (findProduct.Product.Sizes[i].Name == size)
                            {
                                findProduct.Product.Sizes[i].Quantity += quantity;
                            }
                        }
                    }
                }
                else
                {
                    Product prod = await _productRepository.FindOne(productId);

                    ProductModel prodModel = new ProductModel
                    {
                        Category = prod.Category,
                        Color = prod.Color,
                        Description = prod.Description,
                        Gender = prod.Gender,
                        Id = prod.Id,
                        Name = prod.Name,
                        Price = prod.Price,
                        Sizes = new List<SizeModel>
                        {
                            new SizeModel
                            {
                                Name = size,
                                Quantity = quantity
                            }
                        }
                    };

                    currentCart.Add(new CartItem
                    {
                        Product = prodModel,
                        Quantity = quantity
                    });
                }
                SessionHelper.Set(HttpContext.Session, "cart", currentCart);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveProduct(int productId)
        {
            List<CartItem> cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");

            CartItem findProduct = cart.SingleOrDefault(i => i.Product.Id == productId);

            if (findProduct != null)
            {
                cart.Remove(findProduct);
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SetQuantity(int productId, int quantity)
        {
            List<CartItem> cart = SessionHelper.Get<List<CartItem>>(HttpContext.Session, "cart");

            CartItem findProduct = cart.SingleOrDefault(i => i.Product.Id == productId);

            if (findProduct != null)
            {
                findProduct.Quantity = quantity;
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
