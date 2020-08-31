using EshopSolution.Application.System.Users;
using EshopSolution.ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("UserName or Password is incorrect");
            }else
           
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _userService.Register(request);
            if (result == false)
            {
                return BadRequest("Register fail");
            }
            return Ok();
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

    }
}