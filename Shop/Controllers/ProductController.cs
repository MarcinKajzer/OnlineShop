﻿using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Common;
using Shop.DataAcces.Interfaces;
using Shop.Enums;
using Shop.Helpers;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly ProductMapper productMapper = new ProductMapper();
        public ProductController(IProductRepository repository, 
                                 UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            CreateProductViewModel model = new CreateProductViewModel();
            List<SizeInfoDTO> sizes = new List<SizeInfoDTO>();

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                sizes.Add(new SizeInfoDTO() { Size = size, Quantity = 0 });
            }
            model.Sizes = sizes;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.Create(productMapper.MapToProductModel(model));

                if (result != null)
                {
                    return RedirectToAction(nameof(Details), new { productId = result.Id }); 
                }

                ModelState.AddModelError(string.Empty, "Unable to add product. Try again.");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            Product prod = await _repository.FindOne(productId);

            return View(productMapper.MapToUpdateProductViewModel(prod));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Product product = await _repository.FindOne(model.Id);

            if (product != null)
            {
                product = productMapper.UpdateExistingProduct(model, product);
            }
            else
            {
                return NotFound();
            }

            var result = await _repository.Update(product);

            if (result == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new { productId = result.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Filters filters)
        {
            List<Product> products = _repository.FindAll(filters).ToList();
            List<ProductDetailsViewModel> prods = new List<ProductDetailsViewModel>();

            var currentUser = await GetCurrentUser();
            if(currentUser != null )
            {
                List<int> userFavouritesProductsIds = currentUser.Favourites.Select(x => x.Id).ToList();

                foreach (var item in products)
                {
                    if (userFavouritesProductsIds.Contains(item.Id))
                        prods.Add(productMapper.MapToProductDetailsViewModel(item, true));
                    else
                        prods.Add(productMapper.MapToProductDetailsViewModel(item, false));
                }
            }
            else
            {
                foreach (var item in products)
                {
                    prods.Add(productMapper.MapToProductDetailsViewModel(item, false));
                }
            }
            
            ViewBag.Filter = filters;
            return View(prods);
        }

        [NonAction]
        private async Task<User> GetCurrentUser()
        {
            var currentUserName = HttpContext.User.Identity.Name;
            if(currentUserName != null)
            {
                var currentUser = await _userManager.FindByNameAsync(currentUserName);
                return currentUser;
            }

            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            Product prod = await _repository.FindOne(productId);

            if(prod != null)
            {
                var currentUser = await GetCurrentUser();
                List<int> userFavouritesProductsIds = currentUser.Favourites.Select(x => x.Id).ToList();

                if (userFavouritesProductsIds.Contains(prod.Id))
                    return View(productMapper.MapToProductDetailsViewModel(prod, true));
                else
                    return View(productMapper.MapToProductDetailsViewModel(prod, false));
            }
               
            return NotFound();
        }

        public async Task<IActionResult> Delete(int productId)
        {
            Product prod = await _repository.FindOne(productId);

            if(prod == null)
                return NotFound();
            
            prod.IsArchived = true;
            var result = _repository.Update(prod);

            if (result == null)
                return NotFound();

            return RedirectToAction(nameof(GetAll), new { prod.Gender, prod.Category });
        }


        [HttpGet]
        public JsonResult GetCategories(int gender)
        {
            List<SelectListItem> list;

            if (gender == 1)
            {
                list = Enum.GetValues(typeof(MansCategory)).Cast<MansCategory>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();
            }
            else
            {
                list = Enum.GetValues(typeof(WomanCategory)).Cast<WomanCategory>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();
            }
            return Json(list);
        }
    }
}
