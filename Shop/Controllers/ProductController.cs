using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Common;
using Shop.DataAcces.Interfaces;
using Shop.Enums;
using Shop.Helpers;
using Shop.Utility;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _environment;
        private readonly ProductMapper _productMapper;

        public ProductController(IProductRepository repository, 
                                 UserManager<User> userManager,
                                 IWebHostEnvironment environment)
        {
            _repository = repository;
            _userManager = userManager;
            _environment = environment;
            _productMapper = new ProductMapper();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string newImageName = Guid.NewGuid().ToString();
                model.ImageName = newImageName;

                var result = await _repository.Create(_productMapper.MapToProductModel(model));

                if (result != null)
                {
                    ImageUploader uploader = new ImageUploader(_environment);
                    await uploader.Upload(model.Image, newImageName);

                    return RedirectToAction(nameof(Details), new { productId = result.Id }); 
                }

                ModelState.AddModelError(string.Empty, "Failed to add a new product. Try again.");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            Product product = await _repository.FindOne(productId);

            if (product == null)
                return NotFound();

            return View(_productMapper.MapToUpdateProductViewModel(product));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = await _repository.FindOne(model.Id);

                if (product == null)
                {
                    ModelState.AddModelError(string.Empty, "This product cannot be found in the database.");
                    return View(model);
                }
                   
                product = _productMapper.UpdateExistingProduct(model, product);
               
                var result = await _repository.Update(product);

                if (result == null)
                {
                    ModelState.AddModelError(string.Empty, "Product update failed. Try again.");
                    return View(model);
                }
                    
                return RedirectToAction(nameof(Details), new { productId = result.Id });
            }
                
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(Filters filters)
        {
            List<Product> products = _repository.FindAll(filters).ToList();
            List<ProductDetailsViewModel> prods = new List<ProductDetailsViewModel>();

            List<int> userFavouritesProductsIds = await GetCurrentUserFavouriteProductsIds();

            bool isFavouritesListNull = userFavouritesProductsIds != null;

            foreach (var item in products)
            {
                bool isFavourite = isFavouritesListNull && userFavouritesProductsIds.Contains(item.Id);
                prods.Add(_productMapper.MapToProductDetailsViewModel(item, isFavourite));
            }
            
            ViewBag.Filter = filters;
            return View(prods);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int productId)
        {
            Product product = await _repository.FindOne(productId);

            if(product == null)
                return NotFound();

            List<int> favouriteProductsIds = await GetCurrentUserFavouriteProductsIds();

            bool isFavourite = favouriteProductsIds != null && favouriteProductsIds.Contains(product.Id);

            return View(_productMapper.MapToProductDetailsViewModel(product, isFavourite));
        }

        
        public async Task<IActionResult> Archive(int productId, bool archive)
        {
            Product product = await _repository.FindOne(productId);

            if(product != null)
            {
                product.IsArchived = archive;
                var result = await _repository.Update(product);

                if (result == null)
                    return NotFound();
            }

            return RedirectToAction(nameof(GetAll), new { product.Gender, product.Category });
        }

       
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetCategories(Gender gender)
        {
            List<SelectListItem> list;

            if (gender == Gender.Mens)
                list = new MansCategory().ConvertToSelectList();
            else
                list = new WomanCategory().ConvertToSelectList();

            return Json(list);
        }


        [NonAction]
        private async Task<List<int>> GetCurrentUserFavouriteProductsIds()
        {
            var currentUserName = HttpContext.User.Identity.Name;
            if (currentUserName != null)
            {
                var currentUser = await _userManager.FindByNameAsync(currentUserName);
                return currentUser.Favourites.Select(p => p.Id).ToList();
            }

            return null;
        }
    }
}
