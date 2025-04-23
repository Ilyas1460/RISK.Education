namespace Education.Persistence.Abstractions;

public abstract class BaseEntity
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; protected set; } = null;

    public void MarkAsUpdated() => UpdatedAt = DateTime.UtcNow;

    public void MarkAsDeleted() => DeletedAt = DateTime.UtcNow;
}
