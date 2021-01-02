using EshopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EshopSolution.AdminApp.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            if (sessions == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }

        protected string GetLanguageId()
        {
            string languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.LanguageId);
            if (string.IsNullOrEmpty(languageId))
                languageId = SystemConstants.AppSettings.DefaultLangaueId;
            return languageId;
        }
    }
}