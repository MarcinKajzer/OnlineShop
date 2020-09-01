using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DTOs;
using Shop.Helpers;
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
        private readonly UserMapper _userMapper;

        public AccountController(UserManager<User> userManager, 
                                SignInManager<User> signInManager,
                                IMailSender mailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailSender = mailSender;
            _userMapper = new UserMapper();
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
                User user = _userMapper.MapToUserModel(model);
                
                var creationResult = await _userManager.CreateAsync(user, model.Password);

                if (creationResult.Succeeded)
                {
                    string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Id, token = confirmationToken }, "https");
                    await _mailSender.SendEmailConfirmationAsync(user.Email, confirmationLink);

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
        public IActionResult RegistratedSuccessfully() => View();
       

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

            return View("EmailConfirmationFailed");
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
                    ModelState.AddModelError(string.Empty, "Nieprawidłowa nazwa użytkownika lub hasło.");
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
            UpdateUserViewModel viewModel = _userMapper.MapToUpdateUserViewModel(await GetCurrentUser());
            
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userMapper.UpdateExistingUser(model, await GetCurrentUser());

                var result =  await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("index", "home");

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddAdress() => View();
      

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAdress(AdressDTO model)
        {
            if (ModelState.IsValid)
            {
                User user = await GetCurrentUser();
                user.Adress = _userMapper.MapAdress(model);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Update));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult ForgotPassword() => View();
       

        [HttpPost]
        public async Task<IActionResult> SendResetPasswordLink(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if(user != null && user.EmailConfirmed)
            {
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetLink = Url.Action(nameof(ResetPassword), "Account", new { token, email }, "https");

                await _mailSender.SendPasswordResetAsync(email, resetLink);
            }

            return View("PasswordResetMailSentSuccesfully");
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token) => View();


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(model.Email);

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                    return RedirectToAction(nameof(PasswordResetSuccesfully));
                else
                    return RedirectToAction(nameof(PasswordResetFailed));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PasswordResetSuccesfully() => View();

        [HttpGet]
        public IActionResult PasswordResetFailed() => View();

        [HttpGet]
        public IActionResult ChangePassword() => View();
        

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await GetCurrentUser();

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                    return RedirectToAction(nameof(PasswordChangedSuccesfully));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult PasswordChangedSuccesfully() => View();
      



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
