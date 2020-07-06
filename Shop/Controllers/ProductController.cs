using Entities;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAcces.Interfaces;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Category = model.Category,
                    Color = model.Color,
                    Description = model.Description,
                    Gender = model.Gender,
                    Name = model.Name,
                    Price = model.Price,
                    Size = model.Size
                };

                var result = await _repository.Create(product);

                if (result != null)
                {
                    return RedirectToAction(nameof(Details), new { productId = result.Id }); 
                }

                ModelState.AddModelError(string.Empty, "Unable to add product. Try again.");
                return View(model);

            }
           
            return View(model);
        }

        public async Task<IActionResult> GetByCategory(int gender, int category)
        {
            List<Product> products = _repository.FindByCategory(gender, category).ToList();

            List<ProductDetailsViewModel> prods = new List<ProductDetailsViewModel>();

            foreach(var item in products)
            {
                prods.Add(new ProductDetailsViewModel
                {
                    Category = item.Category,
                    Color = item.Color,
                    Description = item.Description,
                    Gender = item.Gender,
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Size = item.Size
                });
            }

            // validation, filtation, sorting

            return View(prods);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            Product prod = await _repository.FindOne(productId);

            if(prod != null)
            {
                ProductDetailsViewModel product = new ProductDetailsViewModel
                {
                    Id = prod.Id,
                    Category = prod.Category,
                    Color = prod.Color,
                    Description = prod.Description,
                    Gender = prod.Gender,
                    Name = prod.Name,
                    Price = prod.Price,
                    Size = prod.Size
                };

                return View(product);
            }

            return NotFound();
        }

       
    }
}
