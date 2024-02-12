using Microsoft.AspNetCore.Mvc;
using POC.Negocio.ViewModels;
using System.Diagnostics;

namespace POC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
