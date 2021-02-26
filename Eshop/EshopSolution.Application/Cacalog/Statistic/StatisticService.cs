using EshopSolution.Application.Cacalog.Orders;
using EshopSolution.Data.EF;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Utilities.Charts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Charts
{
    public class StatisticService : IStatisicService
    {
        private readonly EshopDbContext _context;
        private readonly IOrderService _orderService;
        public StatisticService(EshopDbContext context,IOrderService orderSevice)
        {
            _context = context;
            _orderService = orderSevice;
        }
        public ChartData CalRevenuePerMonth()
        {
            Dictionary<string, decimal> revenue = new Dictionary<string, decimal>();
            DateTime start = DateTime.Now.AddYears(-1);
            DateTime end = DateTime.Now;
            DateTime temp = start;
            while(!(temp.Month==end.Month && temp.Year==end.Year))
            {
                revenue.Add(temp.Month.ToString(), 0);
                temp = temp.AddMonths(1);
            }

            var orders = _context.Orders.ToList();

            if(orders !=null)
                foreach(var order in orders)
                {
                    if(order.OrderDate.Date >= new DateTime(start.Year,start.Month,1) &&
                      order.OrderDate.Date <= new DateTime(DateTime.Now.Year,DateTime.Now.Month,1).AddDays(-1))
                    {
                        revenue[order.OrderDate.Month.ToString()] += _orderService.CalTotalPrice(order.Id);
                    }
                }
            var chartData = new ChartData()
            {
                Label = revenue.Keys.ToList()

            };
            chartData.Data.Add(revenue.Values.ToList());
            return chartData;
        }
        public ChartData GetBestSellers(string languageId)
        {
            var chartData = new ChartData();
           

            var result = _context.ProductTranslations
                .SelectMany(pr => _context.OrderDetails.Where(od => od.ProductId == pr.ProductId).DefaultIfEmpty()
                , (pr,od) => new {pr=pr,od=od})
                .Where(x=>x.pr.LanguageId ==languageId)
                .GroupBy(x => new { x.pr.ProductId, x.pr.Name })
                .Select(x => new { TotalQuantity = x.Sum(y => y.od.Quantity), Name = x.Key.Name })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(10).ToList();

            var listLabel = new List<string>();
            var listData = new List<decimal>();
            if(result!=null)
                foreach(var item in result)
                {
                    listLabel.Add(item.Name);
                    listData.Add(item.TotalQuantity);
                }

            chartData.Data.Add(listData);
            chartData.Label = listLabel;
                        
            return chartData;
        }
    }
}
