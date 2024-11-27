using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace RestApiStockify.Model.Context
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Deposit> Deposit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Address)
                .WithOne(a => a.Deposit)
                .HasForeignKey<Deposit>(d => d.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
