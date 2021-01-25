using EshopSolution.Data.EF;
using EshopSolution.Data.Entities;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Orders
{
    public class OrderService : IOrderSevice
    {
         private readonly EshopDbContext _context;
        public OrderService(EshopDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<bool>> Create(OrderCreateRequest request)
        {

            Order order = new Order()
            {
                OrderDate = DateTime.UtcNow,
                UserId = request.UserId,
                OrderDetails = request.ListCart.Select(x => new OrderDetail()
                {
                     ProductId = x.Id,
                     Quantity = x.Quantity,
                     Price = x.Price
                }).ToList(),
                ShipAddress = request.ShipAddress,
                ShipEmail = request.ShipEmail,
                ShipName = request.ShipName,
                ShipPhoneNumber = request.ShipPhoneNumber,
                Status = OrderStatus.InProgress

            };
            _context.Orders.Add(order);
            if(await _context.SaveChangesAsync()!=0)
            {
                return new ApiSuccessResult<bool>();
            }
            return new  ApiErrorResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if(order!=null)
            {
                _context.Orders.Remove(order);
                if(_context.SaveChanges()!=0)
                {
                    return new ApiSuccessResult<bool>();
                }
                     
                return new ApiErrorResult<bool>();

            }
            else
            {
                return new ApiErrorResult<bool>();
            }
            
        }
    }
}
