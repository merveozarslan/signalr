namespace SIGNALR_APP.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }

    public class ProductForGraph
    {
      public string Name { get; set; }
      public int Price { get; set; }



    }


}


