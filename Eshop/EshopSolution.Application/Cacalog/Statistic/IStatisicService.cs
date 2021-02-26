using EshopSolution.ViewModels.Utilities.Charts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Application.Cacalog.Charts
{
    public interface  IStatisicService
    {
        ChartData CalRevenuePerMonth();
        ChartData GetBestSellers(string languageId);
    }
}
