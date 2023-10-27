using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Domain
{
    public class StockQuote
    {
        public int Id { get; set; }
        public int CompanySharesId { get; set; }
        public decimal StockPrice { get; set; }
        public DateTime StockDate { get; set; }
    }
}
