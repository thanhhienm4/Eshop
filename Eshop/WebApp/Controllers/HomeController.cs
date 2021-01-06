using EshopSolution.ApiIntergate;
using EshopSolution.WebApp.Models;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISlideApiClient _slideApiClient;
        private readonly ISharedCultureLocalizer _loc;
        public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient, ISharedCultureLocalizer loc)
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
            _loc = loc;
        }

        public async Task<IActionResult> Index()
        {
            var msg = _loc.GetLocalizedString("Vietnamese");
            var slides = await _slideApiClient.GetAll();
            var viewModel = new HomeViewModel()
            {
                Slides = slides
            };
            return View(viewModel);
        }
            
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}