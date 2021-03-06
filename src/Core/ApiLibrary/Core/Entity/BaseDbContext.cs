﻿using ApiLibrary.Core.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
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
            AddTracking();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTracking()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var item in entries)
            {
                if (item.State == EntityState.Modified)
                {
                    var properties = item.Entity.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        if (prop.GetCustomAttribute<NoModifiedAttribute>() != null)
                        {
                            item.Property(prop.Name).IsModified = false;
                        }
                    }

                   ((BaseEntity)item.Entity).UpdateAt = DateTime.Now;
                }

                if (item.State == EntityState.Deleted)
                {
                    ((BaseEntity)item.Entity).DeleteAt = DateTime.Now;
                    item.State = EntityState.Modified;
                }

                if (item.State == EntityState.Added)
                {
                    ((BaseEntity)item.Entity).CreatedAt = DateTime.Now;
                }

            }
        }
    }
}
