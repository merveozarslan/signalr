using SIGNALR_APP.Hubs;
using SIGNALR_APP.Models;
using TableDependency.SqlClient;

namespace SIGNALR_APP.TableDependencies
{
    public class SaleTableDependency
    {
        SqlTableDependency<GameSale> tableDependency;
        DashboardHub dashboardHub;

        public SaleTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void STableDependency()

        {
            string connectionString = "Data Source=DESKTOP-D4TKUO0;Initial Catalog=ProjectDb;Integrated Security=True";
            tableDependency = new SqlTableDependency<GameSale>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<GameSale> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.SendGameSales();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(GameSale)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}

