using EshopSolution.ViewModels.Utilities.Charts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface IStatisticApiClient
    {
        Task<ChartData> GetRevenuePerMonth();
        Task<ChartData> GetBestSellers(string languageId);
    }
}
