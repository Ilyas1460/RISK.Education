namespace Education.Persistence.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? CourseId { get; set; }

    public int CourseAccessType { get; set; }

    public double? Price { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? SubscriptionPlanId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Order? Order { get; set; }

    public virtual SubscriptionPlan? SubscriptionPlan { get; set; }
}
