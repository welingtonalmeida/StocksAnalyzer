using System;

namespace StockAnalyzer.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StockSymbol { get; set; }
        public int Evaluation  { get; set; }
    }
}
