using EshopSolution.Application.System.Users;
using EshopSolution.ViewModel.Common;
using EshopSolution.ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var resultToken = await _userService.Authenticate(request);
            if (!resultToken.IsSuccessed)
            {
                return BadRequest(resultToken);
            } else

                return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _userService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserPaging(request);
            return Ok(user);

        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _userService.Update(id, request);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("{id}/getbyid")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var respond = await _userService.GetById(id);
            if (respond.IsSuccessed)
            {
                return Ok(respond);
            }
            return BadRequest(respond);

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _userService.Delete(Id);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}