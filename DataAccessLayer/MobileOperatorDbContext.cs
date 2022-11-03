using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class MobileOperatorDbContext: DbContext
    {
        public MobileOperatorDbContext(DbContextOptionsBuilder options): base()
        {
        }

        private DbSet<SimCard> SimCard { get; set; }
        private DbSet<Subscription> Subscription { get; set; }
        private DbSet<SubscriptionOffer> SubscriptionOffer { get; set; }
        private DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimCard>().HasKey(x => x.Id);
            modelBuilder.Entity<SimCard>().Property(x => x.PhoneNumber).IsRequired();
            modelBuilder.Entity<SimCard>().Property(x => x.PhoneNumber).HasMaxLength(9);
            modelBuilder.Entity<SimCard>().Property(x => x.Price).HasPrecision(2,18);
            modelBuilder.Entity<SimCard>().HasOne<User>().WithMany(x=>x.SimCards);
            modelBuilder.Entity<SimCard>().HasOne<Subscription>().WithMany(x=>x.SimCards);


            modelBuilder.Entity<Subscription>().HasKey(x => x.Id);
            modelBuilder.Entity<Subscription>().Property(x => x.Price).HasPrecision(2,18);
            modelBuilder.Entity<Subscription>().Property(x => x.Messages).IsRequired();
            modelBuilder.Entity<Subscription>().Property(x => x.Minutes).IsRequired();
            modelBuilder.Entity<Subscription>().Property(x => x.InternetMegabytes).IsRequired();
            modelBuilder.Entity<Subscription>().HasMany<SimCard>().WithOne(x=>x.Subscription);


            modelBuilder.Entity<SubscriptionOffer>().HasKey(x => x.Id);
            modelBuilder.Entity<SubscriptionOffer>().Property(x => x.Price).HasPrecision(2,18);
            modelBuilder.Entity<SubscriptionOffer>().Property(x => x.Messages).IsRequired();
            modelBuilder.Entity<SubscriptionOffer>().Property(x => x.Minutes).IsRequired();
            modelBuilder.Entity<SubscriptionOffer>().Property(x => x.InternetMegabytes).IsRequired();
            modelBuilder.Entity<SubscriptionOffer>().Property(x => x.ExpirationDate).IsRequired();
            modelBuilder.Entity<SubscriptionOffer>().HasMany<User>().WithMany(x=>x.SubscriptionOffers);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(x=>x.Name).IsRequired();
            modelBuilder.Entity<User>().Property(x=>x.Surname).IsRequired();
            modelBuilder.Entity<User>().HasMany(x=>x.SimCards).WithOne(x=>x.User);
            modelBuilder.Entity<User>().HasMany(x => x.SubscriptionOffers).WithMany(x => x.Users);
        }
    }
}
