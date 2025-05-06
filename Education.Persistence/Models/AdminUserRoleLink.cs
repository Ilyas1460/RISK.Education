namespace Education.Persistence.Models;

public partial class AdminUserRoleLink
{
    public int Id { get; set; }

    public int AdminUserId { get; set; }

    public int? CourseId { get; set; }

    public int AdminRole { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual AdminUser AdminUser { get; set; } = null!;

    public virtual Course? Course { get; set; }
}
