using DataAccessLayer.Structures;

namespace DataAccessLayer.Entities
{
    public sealed class SubscriptionOffer: SubscriptionData
    {
        public Guid Id { get; set; }

        public DateOnly ExpirationDate { get; set; }


        public IList<User> Users { get; set; }
    }
}
