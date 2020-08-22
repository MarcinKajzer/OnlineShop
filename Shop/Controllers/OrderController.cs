using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAcces.Interfaces;
using Shop.Helpers;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _repository;
        private readonly OrderMapper _orderMapper;

        public OrderController(UserManager<User> userManager, IOrderRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
            _orderMapper = new OrderMapper();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Buy()
        {
            CreateOrderViewModel viewModel = SessionHelper.Get<CreateOrderViewModel>(HttpContext.Session, "cart");
            return View(viewModel);
        }

        [Authorize(Roles = "User")]
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

        public IActionResult GetAll(bool isSent)
        {
            List<Order> orders;

            if (isSent)
                orders = _repository.FindAllSent();
            else
                orders = _repository.FindAllNotSent();

            List<OrderDetailsViewModel> ords = new List<OrderDetailsViewModel>();

            foreach(var order in orders)
                ords.Add(_orderMapper.MapToOrderDetailsViewModel(order));

            return View(ords);
        }

        public async Task<IActionResult> SendShipping(int orderId)
        {
            Order order = await _repository.FindOne(orderId);
            order.IsSent = true;

            var result = await _repository.Update(order);

            if (result == null)
                return NotFound();

            return RedirectToAction(nameof(GetAll), new { isSent = false });
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
