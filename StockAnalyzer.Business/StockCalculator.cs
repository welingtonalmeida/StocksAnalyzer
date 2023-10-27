using System;

namespace StockAnalyzer.Business
{
    public class StockCalculator
    {
        public object GetForecast(object stock)
        {
            return (object)new { Stock = "CIEL3", Value = "2,00" };
        }
    }
}
