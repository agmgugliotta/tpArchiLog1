using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatalogAPI.Core.Entity
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext() : base()
        {

        }

        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTracking();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTracking()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var item in entries)
            {
                if(item.State == EntityState.Added)
                    ((Entity)item.Entity).CreatedAt = DateTime.Now;
                ((Entity)item.Entity).UpdateAt = DateTime.Now;
            }
        }
    }
}
