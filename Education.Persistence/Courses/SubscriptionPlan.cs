using Education.Persistence.Abstractions;
using Education.Persistence.Orders;

namespace Education.Persistence.Courses;

public class SubscriptionPlan : BaseEntity
{
    public string Name { get; set; }

    public int Duration { get; set; }

    public int DurationType { get; set; }

    public double BasePrice { get; set; }

    public double DiscountedPrice { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
