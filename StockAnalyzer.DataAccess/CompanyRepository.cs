using StockAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace StockAnalyzer.DataAccess
{
    public class CompanyRepository
    {
        public List<Company> Getcompanies()
        {
            List<Company> companies = new List<Company>();

            SqlConnection sqlConnection = new SqlConnection();


            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();

                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "select Id, StockName,StockSymbol ,StockEvaluation from CompanyShares";

                sqlCommand.Connection = sqlConnection;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Company company = new Company();

                    company.Id = reader.GetInt32(0);

                    company.Name = reader.GetString(1);

                    company.StockSymbol = reader.GetString(2);

                    company.Evaluation = reader.GetInt32(3);

                    companies.Add(company);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Ocorreu um erro ao tentar lista  as  companhia!!! Error : " + ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }

            return companies;
        }
        public bool Insertcompany(Company companyNew)
        {
            SqlConnection sqlConnection = new SqlConnection();
            int rowsAffected = 0;
            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();

                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                // sqlCommand.CommandText = "insert into StockShares(StockName,StockSymbol, StockEvaluation) values('" + companyNew.Name+ "' ,'" +companyNew.StockSymbol +"' , '"+companyNew.Evaluation + "') ";

                sqlCommand.CommandText = "insert into CompanyShares(StockName,StockSymbol, StockEvaluation ) values(@StockName, @StockSymbol, @StockEvaluation)";
                sqlCommand.Parameters.AddWithValue("@StockName", companyNew.Name);
                sqlCommand.Parameters.AddWithValue("@StockSymbol", companyNew.StockSymbol);
                sqlCommand.Parameters.AddWithValue("@StockEvaluation", companyNew.Evaluation);

                sqlCommand.Connection = sqlConnection;

                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Debug.WriteLine("Ocorreu um erro ao tentar Inserir um  companhia!!! Error : " + ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }

            return rowsAffected > 0;
        }
        public bool UpdateCompany(Company company)
        {
            SqlConnection sqlConnection = new SqlConnection();

            int rowsAffected = 0;
            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();

                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                // sqlCommand.CommandText = "update StockShares set StockName = '" + company.Name + "'where Id = " + company.Id + "update StockShares set StockSymbol = '" + company.StockSymbol + "'where Id = " + company.Id + "update StockShares set StockEvaluation = '" + company.Evaluation + "'where Id = " + company.Id + " ";
                sqlCommand.CommandText = "update CompanyShares set StockName = @StockName , StockSymbol = @StockSymbol, StockEvaluation = @StockEvaluation where Id = @Id ";

                sqlCommand.Parameters.AddWithValue("@Id", company.Id);

                sqlCommand.Parameters.AddWithValue("@StockName", company.Name);
                
                sqlCommand.Parameters.AddWithValue("@StockSymbol", company.StockSymbol);
              
                sqlCommand.Parameters.AddWithValue("@StockEvaluation", company.Evaluation);
                


                sqlCommand.Connection = sqlConnection;

                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Ocorreu um erro ao tentar Atualizar um  companhia!!! Error : " + ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }





            return rowsAffected > 0;
        }
        public bool DeleteCompany(Company company)
        {
            SqlConnection sqlConnection = new SqlConnection();

            int rowsAffected = 0;

            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();

                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

               // sqlCommand.CommandText = "delete from StockShares where Id = " + company.Id + " ";

                 sqlCommand.CommandText = "delete from CompanyShares where Id = @Id ";

                sqlCommand.Parameters.AddWithValue("@Id", company.Id);



                sqlCommand.Connection = sqlConnection;

                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocorreu um erro ao tentar deletar um  companhia!!! Error : " + ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }






            return rowsAffected > 0;
        }

    }
}
