using EshopSolution.ApiIntergate;
using EshopSolution.Data.Enums;
using EshopSolution.ViewModels.Sale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopSolution.AdminApp.Controllers
{
    [Authorize(Policy = "Edit")]
    public class OrderController : BaseController
    {
        private readonly IOrderApiClient _orderApiClient;
        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, DateTime fromDate, DateTime toDate ,OrderStatus? status
            , int pageSize = 5,int pageIndex = 1)
        {
            if (toDate == DateTime.MinValue)
                toDate = DateTime.Now;
            var request = new OrderPagingRequest()
            {
                FromDate = fromDate,
                Keyword = keyword,
                ToDate = toDate,
                PageIndex = pageIndex,
                PageSize =pageSize,
                Status = status

            };
            ViewBag.Statuss = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>()
                .Select(x => new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString(),
                    Selected = status.HasValue && status.ToString() == x.ToString()
                }).ToList();
            var orders = (await _orderApiClient.GetAllPaging(request)).ResultObj;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;
            ViewBag.keyword = keyword;

            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int orderId, int status)
        {
            var result = await _orderApiClient.UpdateStatus(orderId, status);
            if (result.IsSuccessed == true)
            {
                return Ok(result);
                
            }
            else
                return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult>Detail(int orderId)
        {
            var result = await _orderApiClient.GetById(orderId, GetLanguageId());
            if (result.IsSuccessed)
                return View(result.ResultObj);
            return RedirectToAction("Error", "Home");

        }
        
    }
}
