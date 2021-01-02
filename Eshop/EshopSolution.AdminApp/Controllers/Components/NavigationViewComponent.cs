using EshopSolution.AdminApp.Models;
using EshopSolution.AdminApp.Services;
using EshopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageApiClient _languageApiClient;

        public NavigationViewComponent(ILanguageApiClient languageApiClient)
        {
            _languageApiClient = languageApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageApiClient.GetAll();
            string curentLanguageId = HttpContext.Session.GetString(SystemConstants.AppSettings.LanguageId);
            if(string.IsNullOrEmpty(curentLanguageId))
            {
                curentLanguageId = SystemConstants.AppSettings.DefaultLangaueId;
            }

            var navigationVm = new NavigationViewModel()
            {
                CurrentLanguageId = curentLanguageId,
                
                Languages = languages.ResultObj
            };
            return View("Default", navigationVm);
        }
    }
}
