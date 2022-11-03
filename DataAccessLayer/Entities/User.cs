namespace DataAccessLayer.Entities
{
    public sealed class User
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public IList<SimCard> SimCards { get; set; }

        public IList<SubscriptionOffer> SubscriptionOffers { get; set; }
    }
}
