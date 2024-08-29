using SIGNALR_APP.Models;
using System.Data.SqlClient;
using System.Data;

namespace SIGNALR_APP.Repositories
{
    public class GameSaleRepository
    {

        string connectionString;

        public GameSaleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<GameSale> GetGameSales()
        { 
            List<GameSale> gameSales = new List<GameSale>();
            GameSale gameSale;

            var data = GetGameSaleDetailsFromDb();

            foreach (DataRow row in data.Rows)
            {
                gameSale = new GameSale
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Quantity = Convert.ToDecimal(row["Quantity"]),
                    Pdate = Convert.ToDateTime(row["Pdate"]).ToString("dd-MM-yyyy")
                };
                gameSales.Add(gameSale); 

            }

            return gameSales;
        }


        public DataTable GetGameSaleDetailsFromDb()
        {
            var query = "SELECT Id, Name, Quantity, Pdate FROM GameSale";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    return dataTable;

                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        public List<GameSaleForGraph> GetGameSalesForGraph()
        {
            List<GameSaleForGraph> gameSalesForGraph = new List<GameSaleForGraph>();
            GameSaleForGraph gameSaleForGraph;

            var data = GetGameSalesForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                gameSaleForGraph = new GameSaleForGraph
                {
                    Quantities = Convert.ToDecimal(row["Quantities"]),
                    Pdate = Convert.ToDateTime(row["Pdate"]).ToString("dd-MM-yyyy")
                };
                gameSalesForGraph.Add(gameSaleForGraph);
            }

            return gameSalesForGraph;
        }


        public DataTable GetGameSalesForGraphFromDb()
        {
            var query = "SELECT SUM(Quantity) Quantities , Pdate  FROM GameSale GROUP BY Pdate";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
