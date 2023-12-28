using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleSelection_ScatterPoints
{
    public class StockModel
    {
        public DateTime Year { get; set; }

        public double Count { get; set; }

        public double Variation { get; set; }

        public StockModel(DateTime year, double count, double variation)
        {
            Year = year;
            Count = count;
            Variation = variation;
        }
    }
}
