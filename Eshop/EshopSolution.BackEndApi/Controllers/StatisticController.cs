using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.Application.Cacalog.Charts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Organization.Client;

namespace EshopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Edit")]
    public class StatisticController : ControllerBase
    {

        private readonly IStatisicService _statisticService;
        public StatisticController(IStatisicService statisicService)
        {
            _statisticService = statisicService;
        }

        [HttpGet("GetRevenuePerMonth")]
        public async Task<IActionResult> GetRevenuePerMonth()
        {
            var result =  _statisticService.CalRevenuePerMonth();
            return Ok(result);

        }
        [HttpGet("GetBestSellers/{languageId}")]
        public async Task<IActionResult> GetBestSellers(string languageId)
        {
            var result = _statisticService.GetBestSellers(languageId);
            return Ok(result);

        }
    }
   
}
