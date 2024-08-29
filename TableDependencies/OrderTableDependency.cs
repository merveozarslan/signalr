using SIGNALR_APP.Hubs;
using SIGNALR_APP.Models;
using TableDependency.SqlClient;

namespace SIGNALR_APP.TableDependencies
{
    public class OrderTableDependency
    {
        SqlTableDependency<GameOrder> tableDependency;
        DashboardHub dashboardHub;

        public OrderTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }

        public void OTableDependency()

        {
            string connectionString = "Data Source=DESKTOP-D4TKUO0;Initial Catalog=ProjectDb;Integrated Security=True";
            tableDependency = new SqlTableDependency<GameOrder>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<GameOrder> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                dashboardHub.SendGameOrders();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(GameOrder)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}

