
using Microsoft.EntityFrameworkCore;
using Order.Core.ObjectModel;

namespace Order.Core
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Orders>()
            //    .HasMany(x => x.OrderDetails)
            //    .WithOne(x=>x.)
            //    .HasForeignKey(x => x.OrderId);
            //modelBuilder.Entity<OrderDetails>().HasNoKey();

            modelBuilder.Entity<Orders>()
             .HasMany(e => e.OrderDetails)
             .WithOne(e => e.Orders).IsRequired()
             .HasForeignKey(e => e.OrderId);

            base.OnModelCreating(modelBuilder);
        }



    }
}
