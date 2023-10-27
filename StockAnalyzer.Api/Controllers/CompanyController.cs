using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAnalyzer.Api.Mapper;
using StockAnalyzer.Api.Model;
using StockAnalyzer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalyzer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            CompanyHandler companyHandler = new CompanyHandler();

            List<Company> result = CompanyMapper.Map(companyHandler.GetCompanies());


            return result;
        }

        [HttpPost]
        public ActionResult Post(Company company)
        {
            CompanyHandler companyHandler = new CompanyHandler();

            bool result =  companyHandler.Insert(CompanyMapper.Map(company));

            if (result)
            {
                return Created("", company);
            }

            return BadRequest();

        }

        [HttpPut]
        public ActionResult Put(Company company)
        {
            CompanyHandler companyHandler = new CompanyHandler();

            bool result = companyHandler.Update(CompanyMapper.Map(company));
            if (result)
            {
                return Ok(company);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            CompanyHandler companyHandler = new CompanyHandler();

            bool result = companyHandler.Delete(id);
            if (result)
            {
                return Ok(id);
            }

            return BadRequest();

        }
    }
}
