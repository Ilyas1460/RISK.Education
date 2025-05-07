using Education.Persistence.Orders;

namespace Education.Persistence.Courses;

public class SubscriptionPlan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Duration { get; set; }

    public int DurationType { get; set; }

    public double BasePrice { get; set; }

    public double DiscountedPrice { get; set; }

    public int? CourseId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
