using EshopSolution.Data.Entities;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Sale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.ApiIntergate
{
    public interface IOrderApiClient
    {
        Task<ApiResult<bool>> Create(OrderCreateRequest request);
        Task<ApiResult<bool>> Remove(int id);
        Task<ApiResult<List<OrderViewModel>>> GetListActiveModel(string langugeId);

    }
}
