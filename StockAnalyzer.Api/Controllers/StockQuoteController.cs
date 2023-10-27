using Microsoft.AspNetCore.Mvc;
using StockAnalyzer.Api.Mapper;
using StockAnalyzer.Api.Model;
using StockAnalyzer.Business;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalyzer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockQuoteController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<StockQuote> Get()
        {
            StockQuoteHandler stockQuoteHandler = new StockQuoteHandler();
    

                List<StockQuote> result = StockQuoteMapper.Map(stockQuoteHandler.GetStocks());


            return result;
        }

        [HttpPost]
        public ActionResult Post(StockQuote stockQuote)
        {
            StockQuoteHandler stockQuoteHandler = new StockQuoteHandler();

            bool result = stockQuoteHandler.Insert(StockQuoteMapper.Map(stockQuote));

            if (result)
            {
                return Created("", stockQuote);
            }

            return BadRequest();

        }

        [HttpPut]
        public ActionResult Put(StockQuote stockQuote)
        {
            StockQuoteHandler stockQuoteHandler = new StockQuoteHandler();


            bool result = stockQuoteHandler.Update(StockQuoteMapper.Map(stockQuote));
            if (result)
            {
                return Ok(stockQuote);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            StockQuoteHandler stockQuoteHandler = new StockQuoteHandler();

            bool result = stockQuoteHandler.Delete(id);
            if (result)
            {
                return Ok(id);
            }

            return BadRequest();

        }
    }

}
