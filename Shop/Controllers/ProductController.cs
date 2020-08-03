using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository repository, ILogger<ProductController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
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
                var result = await _repository.Create(new ProductMapper().MapToProductModel(model));

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

            return View(new ProductMapper().MapToUpdateProductViewModel(prod));
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
                product = new ProductMapper().UpdateExistingProduct(model, product);
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
        public async Task<IActionResult> GetAll(Filters filter)
        {
            List<Product> products = _repository.FindAll(filter).ToList();

            List<ProductDetailsViewModel> prods = new List<ProductDetailsViewModel>();

            foreach (var item in products)
            {
                prods.Add(new ProductMapper().MapToProductDetailsViewModel(item));
            }

            ViewBag.Filter = filter;
            return View(prods);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            Product prod = await _repository.FindOne(productId);

            if(prod != null)
                return View(new ProductMapper().MapToProductDetailsViewModel(prod));

            return NotFound();
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
