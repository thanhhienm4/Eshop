using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Data.Entities
{
    public enum OrderStatus
    {
        InProgress,
        Confirmed,
        Shipping,
        Success,
        Canceled
    }
}
