using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopSolution.ApiIntergate;
using EshopSolution.Application.Cacalog.Charts;
using EshopSolution.ViewModels.Utilities.Charts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

namespace EshopSolution.AdminApp.Controllers
{
    [Authorize(Policy = "Edit")]
    public class StatisticController : BaseController
    {
        private readonly IStatisticApiClient _statisticApiClient;
        public StatisticController(IStatisticApiClient statisticApiClient)
        {
            _statisticApiClient = statisticApiClient;
        }

        [HttpPost]
        public async Task<ChartData> GetRevenuePerMonth()
        {
            var result = await _statisticApiClient.GetRevenuePerMonth();
            return result;
        }
        
        [HttpPost]
        public async Task<ChartData> GetBestSellers()
        {
            var result = await _statisticApiClient.GetBestSellers(GetLanguageId());
            return result;
        }
    }
}
