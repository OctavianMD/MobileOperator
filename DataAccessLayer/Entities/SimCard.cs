using CommonLayer.Enums;

namespace DataAccessLayer.Entities
{
    public sealed class SimCard
    {
        public Guid Id { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Price { get; set; }

        public DateTime SubscriptionDate { get; set; }

        public SimCardState State { get; set; }

        public SpecialNumberType SpecialNumberType { get; set; }


        public Guid? SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}
