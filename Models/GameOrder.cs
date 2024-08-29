namespace SIGNALR_APP.Models
{
    public class GameOrder
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class GameOrderForGraph
    {
        public string Country { get; set; }
        public int Ordr { get; set; }



    }


}
