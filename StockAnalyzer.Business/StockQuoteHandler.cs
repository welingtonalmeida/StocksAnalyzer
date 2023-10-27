using StockAnalyzer.DataAccess;
using StockAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Business
{
    public class StockQuoteHandler
    {
        public List<StockQuote> GetStocks()
        {
            StockQuoteRepository stockRepositoryGetStocks = new StockQuoteRepository();

            var list = stockRepositoryGetStocks.GetStocks();

            foreach (var stock in list)
            {
                decimal stockPrice = stock.StockPrice;
                DateTime stockDate = stock.StockDate;

            }

            return list;

        }

        public bool Insert(StockQuote stock)
        {
            StockQuoteRepository StockRepositoryInsert = new StockQuoteRepository();

            int companySharesId = stock.CompanySharesId;

            decimal stockPriceNew = stock.StockPrice;

            DateTime stockDate = stock.StockDate;

            bool success = StockRepositoryInsert.Insertstock(new Domain.StockQuote { CompanySharesId = companySharesId, StockPrice = stockPriceNew, StockDate = stockDate });

            return success;
        }

        public bool Update(StockQuote stock)
        {
            StockQuoteRepository StockRepositoryUpdate = new StockQuoteRepository();

            int stockIdUpdate = stock.Id;
            int CompanySharesId = stock.CompanySharesId;

            decimal stockPriceUpdate = stock.StockPrice;
            DateTime stockDateUpdate = stock.StockDate;

            bool success = StockRepositoryUpdate.Updatedstock(new Domain.StockQuote { Id = stockIdUpdate, CompanySharesId = CompanySharesId, StockPrice = stockPriceUpdate, StockDate = stockDateUpdate });

            return success;
            // return stock.Id + stock.CompanySharesId + stock.StockPrice + stock.StockDate != "Error";
        }

        public bool Delete(int id)
        {
            StockQuoteRepository StockRepositoryDelete = new StockQuoteRepository();

            bool success = StockRepositoryDelete.DeleteStock(new Domain.StockQuote { Id = id });

            return success;

        }
    }
}
