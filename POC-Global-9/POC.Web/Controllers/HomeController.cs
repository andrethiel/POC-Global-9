using Microsoft.AspNetCore.Mvc;
using POC.Negocio.ViewModels;
using System.Diagnostics;
using System.Text;

namespace POC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using StringContent jsonContent = new(
                System.Text.Json.JsonSerializer.Serialize(new
                {
                    token = "db012306-a243-470d-9677-2d0261958aa1",
                    number = "5541999143949",
                    message = "write code sample"
                }),
                Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var response = await client.PostAsync("https://api.whatsprofissional.com/v1/api/sendMessage", jsonContent);
            client.Dispose();
            return View();
        }
    }
}
