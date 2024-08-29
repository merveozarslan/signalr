namespace SIGNALR_APP.Models
{
    public class GameSale
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Quantity { get; set; }
            public string Pdate { get; set; }
        
    }

    public class GameSaleForGraph
    {
        public decimal Quantities { get; set; }
        public string Pdate { get; set; }



    }
}
