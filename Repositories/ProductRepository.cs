﻿
using SIGNALR_APP.Models;
using System.Data;
using System.Data.SqlClient;

namespace SIGNALR_APP.Repositories
{

    public class ProductRepository
    {
        string connectionString;

        public ProductRepository(string? connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            Product product;

            var data = GetProductDetailsFromDb();

            foreach (DataRow row in data.Rows)
            {
                product = new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Category = row["Category"].ToString(),
                    Price = Convert.ToInt16(row["Price"])
                };
                products.Add(product);
            }

            return products;
        }
        public DataTable GetProductDetailsFromDb()
        {
            var query = "SELECT Id, Name, Category, Price FROM Product";
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
        public List<ProductForGraph> GetProductsForGraph()
        {
            List<ProductForGraph> productsForGraph = new List<ProductForGraph>();
            ProductForGraph productForGraph;

            var data = GetProductsForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                productForGraph = new ProductForGraph
                {
                    Name = row["Name"].ToString(),
                    Price = Convert.ToInt16(row["Price"])
                };
                productsForGraph.Add(productForGraph);
            }

            return productsForGraph;
        }


        private DataTable GetProductsForGraphFromDb()
        {
            var query = "SELECT Name, Price  FROM Product ";
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

    