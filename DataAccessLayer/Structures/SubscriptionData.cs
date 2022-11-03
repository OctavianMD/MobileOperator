namespace DataAccessLayer.Structures
{
    public abstract class SubscriptionData
    {
        public decimal Price { get; set; }
        
        public int Minutes { get; set; }

        public int Messages { get; set; }

        public float InternetMegabytes { get; set; }
    }
}
