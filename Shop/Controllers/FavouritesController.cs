using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAcces.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FavouritesController(IProductRepository repository, 
                                    UserManager<User> userManager,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task Add(int productId)
        {
            var currentUser = await GetCurrentUser();

            Product product = await _repository.FindOne(productId);
            currentUser.Favourites.Add(product);

            await _userManager.UpdateAsync(currentUser);
        }

        [HttpGet]
        public async Task Remove(int productId)
        {
            var currentUser = await GetCurrentUser();

            Product product = await _repository.FindOne(productId);
            currentUser.Favourites.Remove(product);

            await _userManager.UpdateAsync(currentUser);
        }

        [NonAction]
        private async Task<User> GetCurrentUser()
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            return currentUser;
        }

        public async Task<List<Product>> GetAll ()
        {
            var currentUser = await GetCurrentUser();
            return currentUser.Favourites.ToList();
        }

        public async Task<int> GetQuantity()
        {
            var currentUser = await GetCurrentUser();
            return currentUser.Favourites.Count();
        }
    }
}
