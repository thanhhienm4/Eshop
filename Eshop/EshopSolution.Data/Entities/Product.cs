using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Promotion { get; set; }
        public int Stock { get; set; }
        public int Count  { get; set; }
        public DateTime Datecreate { get; set; }

        public string Image  { get; set; }

    }
}
