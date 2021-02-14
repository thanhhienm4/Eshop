using EshopSolution.Data.EF;
using EshopSolution.Data.Entities;
using EshopSolution.ViewModels.Common;
using EshopSolution.ViewModels.Sale;
using EshopSolution.ViewModels.Utilities;
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
        private readonly IProductService _productService;
        public OrderService(EshopDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }
        public async Task<ApiResult<bool>> Create(OrderCreateRequest request)
        {

            Order order = new Order()
            {
                OrderDate = DateTime.UtcNow,
                UserId = request.UserId,
                OrderDetails = request.ListCart.Select(x => new OrderDetail()
                {
                     ProductId = x.ProductId,
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

        public async Task<List<OrderDetailViewModel>> GetListOrderDetail(int orderId, string languageId)
        {
            var orderDetails = _context.OrderDetails.Where(x => x.OrderId == orderId).ToList();

            List<OrderDetailViewModel> listOrderDetail = new List<OrderDetailViewModel>();
            foreach(var orderDetail in orderDetails)
            {
                var product = (await _productService.GetById(orderDetail.ProductId, languageId)).ResultObj;
                listOrderDetail.Add(new OrderDetailViewModel()
                {

                    ProductId = orderDetail.ProductId,
                    Description = product.Description,
                    Image = product.ThumbnailImage,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = orderDetail.Quantity
                    
                });

            }
            return listOrderDetail;

        }
        private async Task<List<OrderViewModel>> GetListOrderViewModelAsync(List<Order> orders, string languageId)
        {
            var listOrder = new List<OrderViewModel>();
            foreach (Order order in orders)
            {
                listOrder.Add(new OrderViewModel()
                {
                    OrderId = order.Id,
                    ListCart = await GetListOrderDetail(order.Id, languageId),
                    OrderDate = order.OrderDate,
                    ShipAddress = order.ShipAddress,
                    ShipEmail = order.ShipEmail,
                    ShipName = order.ShipName,
                    ShipPhoneNumber = order.ShipPhoneNumber
                });
            }
            return listOrder;
        }
        public async Task<ApiResult<List<OrderViewModel>>> GetHistoryOrder(Guid userId,string languageId)
        {
            var orders = _context.Orders.Where(x => x.UserId == userId
                                               && x.Status == OrderStatus.Success).ToList();
            return new ApiSuccessResult<List<OrderViewModel>>(await GetListOrderViewModelAsync(orders, languageId));
        }
        
        public async Task<ApiResult<List<OrderViewModel>>> GetListActiveOrder(Guid userId,string languageId)
        {
            var orders = _context.Orders.Where(x => x.UserId == userId
                                               && x.Status != OrderStatus.Canceled
                                               && x.Status != OrderStatus.Success).ToList();
            return new ApiSuccessResult<List<OrderViewModel>>( await GetListOrderViewModelAsync(orders, languageId));
            

        }
    }
}
