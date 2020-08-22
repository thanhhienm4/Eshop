using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EshopSolution.BackEndApi.Controllers
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
            return Ok();
        }
    }
}
