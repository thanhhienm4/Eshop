using EshopSolution.ViewModels.Utilities.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public class StatisticApiClient : BaseApiClient, IStatisticApiClient
    {
       

        public StatisticApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor) :
            base(httpClientFactory, configuration, httpContextAccessor) { }

        public async Task<ChartData> GetRevenuePerMonth()
        {
            return await GetAsync < ChartData>("api/Statistic/GetRevenuePerMonth");
        }
        
        public async Task<ChartData> GetBestSellers(string languageId)
        {
            return await GetAsync<ChartData>($"api/Statistic/GetBestSellers/{languageId}");
        }
    }
}
