using Microsoft.EntityFrameworkCore;

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
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deposit>()
                .HasOne(d => d.Address)
                .WithOne(a => a.Deposit)
                .HasForeignKey<Deposit>(d => d.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Product>()
            //    .HasOne(d => d.Deposit)
            //    .WithOne(a => a.Products)
            //    .HasForeignKey<Product>(d => d.DepositId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(d => d.Category)
                .WithOne(a => a.Product)
                .HasForeignKey<Product>(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Product && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((Product)entry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    ((Product)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
