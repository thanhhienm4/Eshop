﻿using EshopSolution.Data.EF;
using EshopSolution.Data.Entities;
using EshopSolution.Data.Enums;
using EshopSolution.Utilities.Exceptions;
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
    public class OrderService : IOrderService
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
            if (await _context.SaveChangesAsync() != 0)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>();
        }
        public async Task<ApiResult<bool>> Delete(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                if (_context.SaveChanges() != 0)
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
            foreach (var orderDetail in orderDetails)
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
        public async Task<ApiResult<List<OrderViewModel>>> GetHistoryOrder(Guid userId, string languageId)
        {
            var orders = _context.Orders.Where(x => x.UserId == userId
                                               && x.Status == OrderStatus.Success).ToList();
            return new ApiSuccessResult<List<OrderViewModel>>(await GetListOrderViewModelAsync(orders, languageId));
        }
        public async Task<ApiResult<List<OrderViewModel>>> GetListActiveOrder(Guid userId, string languageId)
        {
            var orders = _context.Orders.Where(x => x.UserId == userId
                                               && x.Status != OrderStatus.Canceled
                                               && x.Status != OrderStatus.Success).ToList();
            return new ApiSuccessResult<List<OrderViewModel>>(await GetListOrderViewModelAsync(orders, languageId));


        }
        public async Task<ApiResult<PageResult<OrderViewModel>>> GetAllPaging(OrderPagingRequest request)
        {
            //Filter
            var orders = _context.Orders.ToList();
            if (orders == null)
                orders = new List<Order>();
            if (string.IsNullOrWhiteSpace(request.Keyword) == false)
                orders = _context.Orders.Where(x => x.Id.ToString().Contains(request.Keyword)
                                                || x.ShipName.Contains(request.Keyword)
                                                || x.ShipEmail.Contains(request.Keyword)
                                                || x.ShipAddress.Contains(request.Keyword)).ToList();
            if(request.Status!=null)
            {
                orders = orders.Where(x => x.Status == request.Status).ToList();
            }
            if (request.FromDate != null)
                orders = orders.Where(x => x.OrderDate.Date >= request.FromDate.Date).ToList();

            if (request.ToDate != null)
                orders = orders.Where(x => x.OrderDate.Date <= request.ToDate.Date).ToList();

            //Paging
            int totaRow = orders.Count();
            orders = orders.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToList();

            var orderVMDs = orders.Select(x => new OrderViewModel()
            {
                OrderId = x.Id,
                ShipName = x.ShipName,
                ShipAddress = x.ShipAddress,
                ShipEmail = x.ShipEmail,
                ShipPhoneNumber = x.ShipPhoneNumber,
                Status = x.Status,
                OrderDate = x.OrderDate

            }).ToList();

            var pageResult = new PageResult<OrderViewModel>()
            {
                TotalRecord = totaRow,
                Item = orderVMDs,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize

            };

            return new ApiSuccessResult<PageResult<OrderViewModel>>(pageResult);

        }
        public async Task<ApiResult<bool>> UpdateStatus(int orderId, int status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return new ApiErrorResult<bool>();

            order.Status = (OrderStatus)status;
            if (_context.SaveChanges() == 0)
                return new ApiErrorResult<bool>();
            else
                return new ApiSuccessResult<bool>();
        }
        public async Task<ApiResult<OrderViewModel>>GetById(int orderId, string languageId)
        {
            var order =  await _context.Orders.FindAsync(orderId);
            if (order == null)
                return new ApiErrorResult<OrderViewModel>();
            var orderVM = new OrderViewModel()
            {
                ListCart = await GetListOrderDetail(orderId, languageId),
                OrderDate = order.OrderDate,
                OrderId = order.Id,
                ShipAddress = order.ShipAddress,
                ShipEmail = order.ShipEmail,
                ShipName = order.ShipName,
                ShipPhoneNumber = order.ShipPhoneNumber,
                Status = order.Status
            };
            return new  ApiSuccessResult<OrderViewModel>(orderVM);
        }
        public decimal CalTotalPrice(int orderId)
        {
            var orderDetails = _context.OrderDetails.Where(x => x.OrderId == orderId).ToList();
            decimal total = 0;
            if(orderDetails!=null)
                foreach(var orderDetail in orderDetails)
                {
                    total += orderDetail.Quantity * orderDetail.Price;
                }
            return total;
        }


       

    }
}
