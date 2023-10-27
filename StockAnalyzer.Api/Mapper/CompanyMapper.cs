using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAnalyzer.Api.Mapper
{
    public class CompanyMapper
    {
        public static Domain.Company Map(Model.Company companyContract)
        {
            Domain.Company companyEntity = new Domain.Company();

            companyEntity.Id = companyContract.Id;
            companyEntity.Name = companyContract.Name;
            companyEntity.StockSymbol = companyContract.StockSymbol;
            companyEntity.Evaluation = companyContract.Evaluation;

            return companyEntity;
        }
        public static Model.Company Map(Domain.Company companyEntity)
        {
            Model.Company companyContract = new Model.Company();

            companyContract.Id = companyEntity.Id;
            companyContract.Name = companyEntity.Name;
            companyContract.StockSymbol = companyEntity.StockSymbol;
            companyContract.Evaluation = companyEntity.Evaluation;
            
            return companyContract;
        }
    
        public static List<Model.Company> Map(List<Domain.Company> companiesEntities)
        {
            List < Model.Company > companiesContract = new List< Model.Company>();

            foreach (var item in companiesEntities)
            {
                companiesContract.Add(Map(item));
            }

            return companiesContract;
        }




    }
}
