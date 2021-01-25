using EshopSolution.Data.Entities;
using EshopSolution.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModels.Sale
{
    public class OrderCreateRequest
    {

        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
        public List<CartViewModel> ListCart { get; set; }


    }

}
