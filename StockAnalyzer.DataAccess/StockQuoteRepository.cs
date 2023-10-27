using System;
using System.Collections.Generic;
using System.Text;
using StockAnalyzer.Domain;
using System.Data.SqlClient;
using System.Diagnostics;


namespace StockAnalyzer.DataAccess
{
    public class StockQuoteRepository
    {
           
        public List<StockQuote> GetStocks()
        {
            List<StockQuote> stocks = new List<StockQuote>();

            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();

                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "select Id,CompanySharesId, StockPrice,StockDate from StockQuote";

                sqlCommand.Connection = sqlConnection;

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    StockQuote stockQuote = new StockQuote();

                    stockQuote.Id = dataReader.GetInt32(0);
                    stockQuote.CompanySharesId = dataReader.GetInt32(1);
                    stockQuote.StockPrice = dataReader.GetDecimal(2);
                    stockQuote.StockDate = dataReader.GetDateTime(3);

                    stocks.Add(stockQuote);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocorreu um erro ao tentar lista  as  ações!!! Error : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return stocks;
        }

        public bool Insertstock(StockQuote stockNew)
        {
            SqlConnection sqlConnection = new SqlConnection();

            int rowsAffected = 0;

            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();

                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "insert into StockQuote(CompanySharesId, StockPrice,StockDate ) values(@CompanySharesId, @StockPrice,@StockDate)";
                sqlCommand.Parameters.AddWithValue("@CompanySharesId", stockNew.CompanySharesId);
                sqlCommand.Parameters.AddWithValue("@StockPrice", stockNew.StockPrice);
                sqlCommand.Parameters.AddWithValue("@StockDate", stockNew.StockDate);

                sqlCommand.Connection = sqlConnection;

                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocorreu um erro ao tentar Inserir um  stock!!! Error : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return rowsAffected > 0;
        }

        public bool Updatedstock(StockQuote stock)
        {
            SqlConnection sqlConnection = new SqlConnection();
            int rowsAffected = 0;
            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();


                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText = sqlCommand.CommandText = "update StockQuote set  CompanySharesId = @CompanySharesId,  StockPrice = @StockPrice, StockDate = @StockDate  where Id = @Id ";
                sqlCommand.Parameters.AddWithValue("@Id", stock.Id);
                sqlCommand.Parameters.AddWithValue("@CompanySharesId", stock.CompanySharesId);
                sqlCommand.Parameters.AddWithValue("@StockPrice", stock.StockPrice);
                sqlCommand.Parameters.AddWithValue("@StockDate", stock.StockDate);

                sqlCommand.Connection = sqlConnection;

                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Debug.WriteLine("Ocorreu um erro ao tentar Atualizar uma  stock!!! Error : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return rowsAffected > 0 ;
        }
        public bool DeleteStock(StockQuote stock)
        {
            SqlConnection sqlConnection = new SqlConnection();

            int rowsAffected = 0;

            try
            {
                ConnectionStringMain connectionStringMain = new ConnectionStringMain();

                sqlConnection.ConnectionString = connectionStringMain.ConnectionDataBase();

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandText = "delete from StockQuote where Id = @Id ";
                sqlCommand.Parameters.AddWithValue("@Id", stock.Id);

                sqlCommand.Connection = sqlConnection;

                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocorreu um erro ao tentar deletar um  stock!!! Error : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return rowsAffected > 0 ;
        }

    }
}
