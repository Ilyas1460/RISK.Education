using Education.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Education.Infrastructure.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor {
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, 
        InterceptionResult<int> result) {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries<Entity>()) {
            if (entry is { State: EntityState.Deleted }) {
                entry.State = EntityState.Modified;
                entry.Entity.MarkAsDeleted();
            } else if (entry is { State: EntityState.Modified }) {
                entry.Entity.MarkAsUpdated();
            }
        }

        return result;
    }
}