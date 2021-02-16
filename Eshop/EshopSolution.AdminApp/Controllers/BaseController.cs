using EshopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EshopSolution.AdminApp.Controllers
{
    public class BaseController : Controller

    {
      
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            if (sessions == null)
                    {
                string token = Request.Cookies[SystemConstants.AppSettings.Bearer];
                if(token==null)
                    context.Result = new RedirectToActionResult("Index", "Login", null);
                else
                    context.HttpContext.Session.SetString(SystemConstants.AppSettings.Token, token);
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