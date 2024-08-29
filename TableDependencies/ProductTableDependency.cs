
using SIGNALR_APP.Hubs;
using SIGNALR_APP.Models;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Abstracts;

namespace SIGNALR_APP.TableDependencies
{
    public class ProductTableDependency 
    {
        SqlTableDependency<Product> tableDependency;
        DashboardHub dashboardHub;

        public ProductTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void PTableDependency()

        {
            string connectionString = "Data Source=DESKTOP-D4TKUO0;Initial Catalog=ProjectDb;Integrated Security=True";
            tableDependency = new SqlTableDependency<Product>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.SendProducts();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Product)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
