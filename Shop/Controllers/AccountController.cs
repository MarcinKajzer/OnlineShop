using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DTOs;
using Shop.Entities;
using Shop.Interfaces;
using Shop.ViewModels;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMailSender _mailSender;

        public AccountController(UserManager<User> userManager, 
                                SignInManager<User> signInManager,
                                IMailSender mailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailSender = mailSender;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var creationResult = await _userManager.CreateAsync(user, model.Password);

                if (creationResult.Succeeded)
                {
                    string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Id, token = confirmationToken }, "https");
                    await _mailSender.SendPasswordConfirmationAsync(user.Email, confirmationLink);

                    var addingToRoleResult = await _userManager.AddToRoleAsync(user, "User");

                    if(addingToRoleResult.Succeeded)
                        return RedirectToAction(nameof(RegistratedSuccessfully));

                    foreach (var error in addingToRoleResult.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
                    
                foreach (var error in creationResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult RegistratedSuccessfully()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                    return View("EmailConfirmedSuccesfully");
                else
                    ViewBag.Error = "Nie udało się potwierdzić adresu email.";
            }
            ViewBag.Error = "Uzytkownik o podanym identyfikatorze nie istnieje.";

            return View();
        }


        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                    return RedirectToLocal(model.ReturnUrl);
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            User user = await GetCurrentUser();
            UpdateUserViewModel viewModel = new UpdateUserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id
            };

            if(user.Adress != null)
            {
                viewModel.Adress = new AdressDTO
                {
                    City = user.Adress.City,
                    Street = user.Adress.Street,
                    PostCode = user.Adress.Street,
                    BuildingNumber = user.Adress.BuildingNumber,
                    FlatNumber = user.Adress.FlatNumber
                };
            }
            
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await GetCurrentUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                var result =  await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("index", "home");
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddAdress()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAdress(AdressDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = await GetCurrentUser();
                user.Adress = new Adress
                {
                    City = model.City,
                    PostCode = model.PostCode,
                    BuildingNumber = model.BuildingNumber,
                    FlatNumber = model.FlatNumber,
                    Street = model.Street
                };

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Update));

            }
            return View(model);
        }


        [NonAction]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
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
    }
}
