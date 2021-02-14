using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Sale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Orders
{
    public interface IOrderSevice
    {
        Task<ApiResult<bool>> Create(OrderCreateRequest request);

        Task<ApiResult<List<OrderViewModel>>> GetListActiveOrder(Guid userId,string langugeId);
        Task<ApiResult<List<OrderViewModel>>> GetHistoryOrder(Guid userId, string languageId);

        Task<ApiResult<bool>> Delete(int orderId);

    }
}
