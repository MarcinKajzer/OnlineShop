using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
