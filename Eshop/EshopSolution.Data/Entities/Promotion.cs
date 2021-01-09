using System;

namespace EshopSolution.Data.Entities
{
    public class Promotion
    {
        public int Id { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public decimal? DiscountAmount { set; get; }
        public int ProductId { set; get; }
        public int ProductCategoryId { set; get; }
        public Status Status { set; get; }
        public string Name { set; get; }
    }
}