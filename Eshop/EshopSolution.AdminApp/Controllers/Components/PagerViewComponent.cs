using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.ViewModel.Common;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
