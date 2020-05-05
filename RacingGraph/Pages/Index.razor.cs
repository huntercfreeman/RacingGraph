using Microsoft.AspNetCore.Components;
using RacingGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacingGraph.Pages
{
    public partial class Index : ComponentBase
    {
        public List<Number> Numbers = new List<Number>
            {
                new Number { Value = 1, Name = "One", ImageURL = "content/images/1.png", StockValue = new List<double> { 10, 20, 30, 40 } },
                new Number { Value = 2, Name = "Two", ImageURL = "content/images/2.png", StockValue = new List<double> { 40, 30, 20, 10 } },
                new Number { Value = 3, Name = "Three", ImageURL = "content/images/3.png", StockValue = new List<double> { 30, 20, 10, 40 } },
                new Number { Value = 4, Name = "Four", ImageURL = "content/images/4.png", StockValue = new List<double> { 1, 2, 5, 30 } },
                new Number { Value = 5, Name = "Five", ImageURL = "content/images/5.png", StockValue = new List<double> { 20, 20, 20, 20 } },
                new Number { Value = 6, Name = "Six", ImageURL = "content/images/6.png", StockValue = new List<double> { 30, 30, 30, 30 } },
                new Number { Value = 7, Name = "Seven", ImageURL = "content/images/7.png", StockValue = new List<double> { 15, 25, 15, 25 } },
                new Number { Value = 8, Name = "Eight", ImageURL = "content/images/8.png", StockValue = new List<double> { 10, 30, 40, 20 } },
                new Number { Value = 9, Name = "Nine", ImageURL = "content/images/9.png", StockValue = new List<double> { 10, 10, 10, 10 } },
            };
        protected override void OnInitialized()
        {
            base.OnInitialized();

        }
    }
}
