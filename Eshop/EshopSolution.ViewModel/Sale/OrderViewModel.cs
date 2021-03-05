using EshopSolution.Data.Enums;
using EshopSolution.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModels.Sale
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
        public List<OrderDetailViewModel> ListCart { get; set; }
    }
}
