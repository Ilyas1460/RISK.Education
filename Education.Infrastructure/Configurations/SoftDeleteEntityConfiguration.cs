using Education.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Configurations;

internal abstract class SoftDeleteEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> 
    where TEntity : Entity {
    public virtual void Configure(EntityTypeBuilder<TEntity> builder) {
        builder.HasQueryFilter(e => e.DeletedAt == null);
        
        builder.Property(e => e.DeletedAt)
            .IsRequired(false);
        
        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);
        
        builder.Property(e => e.CreatedAt)
            .IsRequired();
        
        ConfigureEntity(builder);
    }
    
    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}