using EshopSolution.ApiIntergate;
using EshopSolution.Application.Cacalog.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.WebApp.Controllers.Components
{
    public class SlideBarViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;
        public SlideBarViewComponent (ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string culture = CultureInfo.CurrentCulture.Name;
            var categorys = await _categoryApiClient.GetAll(culture);
            return View(categorys);
        }
    }
}
