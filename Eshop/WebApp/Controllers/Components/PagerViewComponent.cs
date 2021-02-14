using EshopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EshopSolution.WebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}