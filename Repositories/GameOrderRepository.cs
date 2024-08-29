using SIGNALR_APP.Models;
using System.Data;
using System.Data.SqlClient;



namespace SIGNALR_APP.Repositories
{
    public class GameOrderRepository
    {
        string connectionString;

        public GameOrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<GameOrder> GetGameOrders()
        {
            List<GameOrder> gameOrders = new List<GameOrder>();
            GameOrder gameOrder;

            var data = GetGameOrderDetailsFromDb();

            foreach (DataRow row in data.Rows)
            {
                gameOrder = new GameOrder
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Country = row["Country"].ToString(),
                };
                gameOrders.Add(gameOrder);
            }

            return gameOrders;
        }


        public DataTable GetGameOrderDetailsFromDb()
        {
            var query = "SELECT Id, Name, Country FROM GameOrder";
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
        public List<GameOrderForGraph> GetGameOrdersForGraph()
        {
            List<GameOrderForGraph> gameOrdersForGraph = new List<GameOrderForGraph>();
            GameOrderForGraph gameOrderForGraph;

            var data = GetGameOrdersForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                gameOrderForGraph = new GameOrderForGraph
                {
                    Country = row["Country"].ToString(),
                    Ordr = Convert.ToInt32(row["Ordr"])
                };
                gameOrdersForGraph.Add(gameOrderForGraph);
            }

            return gameOrdersForGraph;
        }


        public DataTable GetGameOrdersForGraphFromDb()
        {
            var query = "SELECT Country, COUNT(Country) Ordr  FROM GameOrder GROUP BY Country";
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



