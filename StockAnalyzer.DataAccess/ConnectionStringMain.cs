using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace StockAnalyzer.DataAccess
{
    public class ConnectionStringMain
    {
        public string ConnectionDataBase()
        {
            SqlConnection sqlConnection = new SqlConnection();

            sqlConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StockSharesDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string connection = sqlConnection.ConnectionString;


            return connection;
        }
    }
}
