using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Data.Entities
{
    public class Slide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public int SortOther { get; set; }
        public Status status { get; set; }
       
    }
}
