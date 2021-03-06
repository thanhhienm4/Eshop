﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EshopSolution.ApiIntergate;
using EshopSolution.Data.Entities;
using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModels.Sale;
using EshopSolution.ViewModels.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EshopSolution.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IUserApiClient _userApiClient;

        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient,
            IUserApiClient userApiClient)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
            _userApiClient = userApiClient;
        
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<OrderDetailViewModel>> GetListCart(string languageId)
        {

            List<OrderDetailViewModel> listCart = null;
            string json = HttpContext.Session.GetString(SystemConstants.AppSettings.CartSession);
            if (json != null)
                listCart = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(json);
            if (listCart == null)
                listCart = new List<OrderDetailViewModel>();

            foreach(var cart in listCart)
            {
                var productData = await _productApiClient.GetById(cart.ProductId, languageId);
                if (!productData.IsSuccessed)
                {
                    listCart.Remove(cart);
                }else
                {
                    var product = productData.ResultObj;
                    cart.Name = product.Name;
                    cart.Description = product.Description;

                }
            }
            return listCart;
            
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart( int id)
        {
            var productData = await _productApiClient.GetById(id);
            if(!productData.IsSuccessed)
            {
                RedirectToAction("Error", "Home");
            }
            List<OrderDetailViewModel> listCart = null;
            string json = HttpContext.Session.GetString(SystemConstants.AppSettings.CartSession);
            if(json != null)
                listCart= JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(json);
            if(listCart == null)
                listCart = new List<OrderDetailViewModel>();

            if(listCart.Any(cart => cart.ProductId==id))
            {
                listCart.Where(cart => cart.ProductId == id).FirstOrDefault().Quantity += 1;
            }else
            {
                var product = productData.ResultObj;
                listCart.Add(new OrderDetailViewModel()
                {
                    ProductId = product.ProductId,
                    Quantity = 1,
                    Image = product.ThumbnailImage,
                    Price = product.Price
                }) ;

            }

            HttpContext.Session.SetString(SystemConstants.AppSettings.CartSession,
                JsonConvert.SerializeObject(listCart));

            return Ok(listCart);

            
        }
        public IActionResult RemoveCart(int id)
        {
            List<OrderDetailViewModel> listCart = null;
            string json = HttpContext.Session.GetString(SystemConstants.AppSettings.CartSession);
            if (json != null)
                listCart = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(json);
            if (listCart == null)
                listCart = new List<OrderDetailViewModel>();

            foreach(var cart in listCart)
            {
                if (cart.ProductId == id)
                {
                    listCart.Remove(cart);
                    break;
                }
                    
            }
            HttpContext.Session.SetString(SystemConstants.AppSettings.CartSession,
                JsonConvert.SerializeObject(listCart));

            return Ok(listCart);
        }
        public IActionResult UpdateCart( int id, int quantity)
        {
            if(quantity == 0)
            {
                return RemoveCart(id);
            }
            List<OrderDetailViewModel> listCart = null;
            string json = HttpContext.Session.GetString(SystemConstants.AppSettings.CartSession);
            if (json != null)
                listCart = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(json);
            if (listCart == null)
                listCart = new List<OrderDetailViewModel>();

            if (listCart.Any(cart => cart.ProductId == id))
            {
                listCart.Where(cart => cart.ProductId == id).FirstOrDefault().Quantity = quantity;
            }
            

            HttpContext.Session.SetString(SystemConstants.AppSettings.CartSession,
                JsonConvert.SerializeObject(listCart));

            return Ok(listCart);


        }
        [HttpGet]
        public async Task<IActionResult> Checkout() 
        {
            var request = new OrderCreateRequest
            {
                ListCart = await GetListCart(CultureInfo.CurrentCulture.Name),
                //UserId = (Guid)await _userApiClient.GetUserId()
                
            };
            return View(request);
            
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout(OrderCreateRequest request)
        {
            request.ListCart = await GetListCart(CultureInfo.CurrentCulture.Name);
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            else
            {
                
                var result = await _orderApiClient.Create(request);
                if (result.IsSuccessed)
                    return RedirectToAction("History");
                
            }
            TempData["SuccessMsg"] = "Order puschased successful";
            return View(request);
            


        }
        
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var result = _orderApiClient.Remove(id);
            return View();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> HistoryAsync()
        {
            string culture = CultureInfo.CurrentCulture.Name;
            var result = (await _orderApiClient.GetListActiveModel(culture)).ResultObj;
            return View(result);
        }
    }
}
