using Microsoft.EntityFrameworkCore;
using Skillz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skillz.Data
{
    static class AuditExtensions
    {
        public static void AddAuditInfo(this DbContext ctx)
        {
            var entries = ctx.ChangeTracker.Entries().Where(e => e.Entity is BaseAuditableEntity && (e.State is EntityState.Added || e.State is EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State is EntityState.Added) ((BaseAuditableEntity)entry.Entity).Created = DateTime.UtcNow;
                ((BaseAuditableEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
