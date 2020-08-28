using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAcces.Interfaces;
using Shop.Helpers;
using Shop.Interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _repository;
        private readonly IMailSender _mailSender;
        private readonly OrderMapper _orderMapper;

        public OrderController(UserManager<User> userManager, 
                                IOrderRepository repository,
                                IMailSender mailSender)
        {
            _userManager = userManager;
            _repository = repository;
            _mailSender = mailSender;
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
                model.CreationDate = DateTime.Now;
                User user = await GetCurrentUser();
                Order order = _orderMapper.MapToOrderModel(model, user.Id);

                var result = await _repository.Create(order);
                if(result != null)
                {
                    await _mailSender.SendOrderSummaryAsync(user.Email, model);

                    SessionHelper.Remove(HttpContext.Session, "cart");
                    return RedirectToAction(nameof(PurchaseFinalizedSuccesfully));
                }

                return RedirectToAction(nameof(PurchaseFinalizationFailed));
            }

            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult PurchaseFinalizedSuccesfully()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult PurchaseFinalizationFailed()
        {
            return View();
        }


        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetCurrentUserOrders()
        {
            User user = await GetCurrentUser();
            List<OrderDetailsViewModel> ords = Get(() => _repository.FindByUserId(user.Id));

            return View("GetAll",ords);
        }


        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult GetAll(bool isSent)
        {
            List<OrderDetailsViewModel> ords = isSent ? Get(_repository.FindAllSent) : Get(_repository.FindAllNotSent);

            return View(ords);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
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
        private async Task<User> GetCurrentUser()
        {
            var currentUserName = HttpContext.User.Identity.Name;

            if (currentUserName != null)
            {
                var currentUser = await _userManager.FindByNameAsync(currentUserName);
                return currentUser;
            }
            return null;
        }

        [NonAction]
        private List<OrderDetailsViewModel> Get(Func<List<Order>> del)
        {
            List<Order> orders = del.Invoke();
            List<OrderDetailsViewModel> ords = new List<OrderDetailsViewModel>();

            orders.ForEach(o => ords.Add(_orderMapper.MapToOrderDetailsViewModel(o)));

            return ords;
        }
    }
}
