using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.ApiIntergate;
using EshopSolution.Application.Cacalog.Orders;
using EshopSolution.Application.System.Users;
using EshopSolution.ViewModels.Sale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> GetListActiveOrder(string languageId)
        {
            Guid userId = await _userService.GetUserId(HttpContext.User);
            var result = await _orderSevice.GetListActiveOrder(userId, languageId);
            if(result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest();

        }
       
    }
}
