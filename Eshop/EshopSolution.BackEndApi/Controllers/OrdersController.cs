using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EshopSolution.ApiIntergate;
using EshopSolution.Application.Cacalog.Orders;
using EshopSolution.Application.System.Users;
using EshopSolution.Utilities.Constants;
using EshopSolution.ViewModels.Sale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderSevice _orderSevice;
        private readonly IUserService _userService;
        public OrdersController(IOrderSevice orderSevice,IUserService userService)
        {
            _orderSevice = orderSevice;
            _userService = userService;
        }

        [HttpPost("Create")]

        [Authorize(Policy ="Access")]
        
        public async Task<IActionResult> Create([FromBody] OrderCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            request.OrderDate = DateTime.Today;
            request.UserId = await _userService.GetUserId(HttpContext.User);
            var result =await _orderSevice.Create(request);
            if(result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Policy = "Access")]
        
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _orderSevice.Delete(id);
            if (result.IsSuccessed)
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpGet("GetListActiveOrder/{languageId}")]
        [Authorize(Policy = "Access")]
        public async Task<IActionResult> GetListActiveOrder(string languageId)
        
        {


            Guid userId =  Guid.Parse(HttpContext.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier && c.Issuer == SystemConstants.Token.Issuer).Value.ToString());         
            var result = await _orderSevice.GetListActiveOrder(userId, languageId);
            if(result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpGet("GetAllPaging")]
        [Authorize(Policy = "Edit")]
        public async Task<IActionResult> GetAllPaging([FromQuery]OrderPagingRequest request)
        {
            var result = await _orderSevice.GetAllPaging(request);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("UpdateStatus/{orderId}/{status}")]
        [Authorize(Policy ="Edit")]
        public async Task<IActionResult> UpdateStatus(int orderId,int status)
        {
            var result = await _orderSevice.UpdateStatus(orderId,status);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("{orderId}/{languageId}")]
        [Authorize(Policy = "Access")]
        public async Task<IActionResult> GetById(int orderId, string languageId)
        {
            var result = await _orderSevice.GetById(orderId, languageId);
            if (!result.IsSuccessed)
                return BadRequest();
            else
                return Ok(result);
        }

    }
}
