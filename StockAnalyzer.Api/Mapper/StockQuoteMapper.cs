using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalyzer.Api.Mapper
{
    public class StockQuoteMapper
    {
        public static Domain.StockQuote Map(Model.StockQuote stockQuoteContract)
        {
            Domain.StockQuote stockQuoteEntity = new Domain.StockQuote();

            stockQuoteEntity.Id = stockQuoteContract.Id;
            stockQuoteEntity.CompanySharesId = stockQuoteContract.CompanySharesId;
            stockQuoteEntity.StockPrice = stockQuoteContract.StockPrice;
            stockQuoteEntity.StockDate = stockQuoteContract.StockDate;

            return stockQuoteEntity;
        }

        public static Model.StockQuote Map(Domain.StockQuote stockQuoteEntity)
        {
            Model.StockQuote stockQuoteContract = new Model.StockQuote();

            stockQuoteContract.Id = stockQuoteEntity.Id;
            stockQuoteContract.CompanySharesId = stockQuoteEntity.CompanySharesId;
            stockQuoteContract.StockPrice = stockQuoteEntity.StockPrice;
            stockQuoteContract.StockDate = stockQuoteEntity.StockDate;


            return stockQuoteContract;
        }

        public static List<Model.StockQuote> Map(List<Domain.StockQuote> stockQuotesEntities)
        {
            List<Model.StockQuote> stocksQuoteContract = new List<Model.StockQuote>();

            foreach (var item in stockQuotesEntities)
            {
                stocksQuoteContract.Add(Map(item));
            }

            return stocksQuoteContract;
        }
    }
}
