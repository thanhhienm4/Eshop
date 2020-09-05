using EshopSolution.AdminApp.Services;
using EshopSolution.ViewModel.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Controllers
{
   
    public class UserController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        //private readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
            //_configuration = configuration;
        }
        [Authorize]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var session = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                BearerToken = session,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _userApiClient.GetUserPaging(request);
            return View(data.ResultObj);
        }
        
       

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _userApiClient.Register(request);
            if(result.IsSuccessed)
            {
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(Guid id ,UpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _userApiClient.Update(id , request);
            if (result.IsSuccessed)
            {
                return RedirectToAction("Index", "User");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}