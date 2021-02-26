using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModels.Utilities.Charts
{
    public class ChartData
    {
        public List<string> Label { get; set; }
        public List<List<Decimal>> Data { get; set; }
        public ChartData()
        {
            Label = new List<string>();
            Data = new List<List<decimal>>();
        }
    }

}
