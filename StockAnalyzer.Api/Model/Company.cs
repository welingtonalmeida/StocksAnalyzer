using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalyzer.Api.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StockSymbol { get; set; }
        public int Evaluation { get; set; }

    }
}
