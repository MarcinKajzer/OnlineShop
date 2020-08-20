using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.DataAcces.Interfaces;
using Shop.Helpers;
using Shop.Models;
using Shop.ViewModels;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _repository;

        public OrderController(UserManager<User> userManager, IOrderRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult FinalizeOrder(Cart model)
        {
            TempData["cart"] = JsonConvert.SerializeObject(model);
            return RedirectToAction(nameof(Buy));
        }

        // [Authorize(Roles = "User")] returns acces denied
        [Authorize(Policy = "UserRoleRequired")] 
        [HttpGet]
        public IActionResult Buy()
        {
            CreateOrderViewModel viewModel = JsonConvert.DeserializeObject<CreateOrderViewModel>(TempData["cart"].ToString());
            return View(viewModel);
        }

        [Authorize(Policy = "UserRoleRequired")]
        [HttpPost]
        public async Task<IActionResult> Buy(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                Order order = new OrderMapper().MapToOrderModel(model, await GetCurrentUserId());

                var result = await _repository.Create(order);
                if(result != null)
                {
                    SessionHelper.Remove(HttpContext.Session, "cart");
                    return RedirectToAction("Index", "Home");
                }

                return View("PurchaseFinalizationFailed");
            }

            return View(model);
        }



        [NonAction]
        private async Task<string> GetCurrentUserId()
        {
            var currentUserName = HttpContext.User.Identity.Name;

            if (currentUserName != null)
            {
                var currentUser = await _userManager.FindByNameAsync(currentUserName);
                return currentUser.Id;
            }
            return null;
        }
    }
}
