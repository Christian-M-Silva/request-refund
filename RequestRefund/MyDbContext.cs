using Microsoft.EntityFrameworkCore;
using RequestRefund.Models.Entities;

namespace RequestRefund
{


    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<RequestRefundEntity> Requests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public override int SaveChanges()
        {
            UpdateDate();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateDate();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateDate()
        {
            var now = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries<RequestRefundEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateAt = now;
                    entry.Entity.UpdateAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdateAt = now;
                }
            }
        }
    }



}
