using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalyzer.Api.Model
{
    public class StockQuote
    {
        public int Id { get; set; }
        public int CompanySharesId { get; set; }
        public decimal StockPrice { get; set; }
        public DateTime StockDate { get; set; }
    }
}
