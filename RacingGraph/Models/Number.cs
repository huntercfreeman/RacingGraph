using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingGraph.Models
{
    public class Number
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public List<double> StockValue { get; set; }
    }
}
