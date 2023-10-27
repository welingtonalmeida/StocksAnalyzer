using StockAnalyzer.DataAccess;
using StockAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace StockAnalyzer.Business
{
    public class CompanyHandler
    {
        public Company Getcompany(int id)
        {

            return null;
        }

        public List<Company> GetCompanies()
        {
            CompanyRepository companyRepositoryGetcomapanies = new CompanyRepository();

            var list = companyRepositoryGetcomapanies.Getcompanies();

            foreach (var company in list)
            {
                var name = company.Name;
                var stockSymbol = company.StockSymbol;
                var Evaluation = company.Evaluation;
            }

            return list;

        }

        public bool Insert(Company company)
        {
            CompanyRepository companyRepositoryInsert = new CompanyRepository();

            bool success = false;

            if (company.Name != "Error" && company.StockSymbol != "Error")
            {
                success = companyRepositoryInsert.Insertcompany(company);
            }

            return success;

        }
        public bool Update(Company company)
        {
            CompanyRepository companyRepositoryUpdate = new CompanyRepository();

            
            bool success = false;

            if (company.Name != "Error" && company.StockSymbol != "Error")
            {
               
                success = companyRepositoryUpdate.UpdateCompany(company);

            }
       
                return success;

        }
        public bool Delete(int id)
        {
            CompanyRepository companyRepositoryDelete = new CompanyRepository();

            bool success = companyRepositoryDelete.DeleteCompany(new Domain.Company { Id = id });

            return success;

        }
    }
}
