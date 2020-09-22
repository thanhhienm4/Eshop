using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.Application.System.Role;
using EshopSolution.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           var roles = await _roleService.GetAll();
            return Ok(roles);
        }
    }
}
