using Microsoft.AspNetCore.SignalR;
using SIGNALR_APP.Repositories;

namespace SIGNALR_APP.Hubs
{
    public class DashboardHub : Hub
    {
        ProductRepository productRepository;
        GameOrderRepository gameOrderRepository;
        GameSaleRepository gameSaleRepository;
     

        public DashboardHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            productRepository = new ProductRepository(connectionString);
            gameOrderRepository = new GameOrderRepository(connectionString);  
            gameSaleRepository = new GameSaleRepository(connectionString);

        }

        public async Task SendProducts()


        {
            var products = productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", products);

            var productsForGraph = productRepository.GetProductsForGraph();
            await Clients.All.SendAsync("ReceivedProductsForGraph", productsForGraph);
             
        }
        public async Task SendGameOrders()


        {
            var gameOrders = gameOrderRepository.GetGameOrders();
            await Clients.All.SendAsync("ReceivedGameOrders", gameOrders);

            var gameOrdersForGraph = gameOrderRepository.GetGameOrdersForGraph();
            await Clients.All.SendAsync("ReceivedGameOrdersForGraph", gameOrdersForGraph);



        }

        public async Task SendGameSales()


        {
            var gameSales = gameSaleRepository.GetGameSales();
            await Clients.All.SendAsync("ReceivedGameSales", gameSales);

            var gameSalesForGraph = gameSaleRepository.GetGameSalesForGraph();
            await Clients.All.SendAsync("ReceivedGameSalesForGraph", gameSalesForGraph); 

        }

    }
}
