﻿using Education.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Education.Infrastructure.Interceptors;

public sealed class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        ApplyAuditRules(eventData);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAuditRules(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void ApplyAuditRules(DbContextEventData eventData)
    {
        if (eventData.Context is null)
        {
            return;
        }

        foreach (EntityEntry<BaseEntity>? entry in eventData.Context.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.MarkAsDeleted();
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.MarkAsUpdated();
            }
        }
    }
}
