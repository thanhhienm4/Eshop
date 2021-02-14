using EshopSolution.ApiIntergate;
using EshopSolution.Utilities.Constants;
using EshopSolution.WebApp.Models;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISlideApiClient _slideApiClient;
        private readonly IProductApiClient _productApiClient;
        private readonly ISharedCultureLocalizer _loc;
        public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient, ISharedCultureLocalizer loc,IProductApiClient productApiClient)
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
            _loc = loc;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index()
        {
            //var msg = _loc.GetLocalizedString("Vietnamese");
            string culture = CultureInfo.CurrentCulture.Name;
            var viewModel = new HomeViewModel()
            {
                Slides = await _slideApiClient.GetAll(),
                FeaturedProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts),
                LatestProducts = await _productApiClient.GetLatestProducts(culture,SystemConstants.ProductSettings.NumberOfLastestProducts)
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