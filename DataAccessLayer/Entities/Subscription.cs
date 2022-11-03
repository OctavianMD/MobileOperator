using DataAccessLayer.Structures;

namespace DataAccessLayer.Entities
{
    public sealed class Subscription: SubscriptionData
    {
        public Guid Id { get; set; }

        public IList<SimCard> SimCards { get; set; }
    }
}
