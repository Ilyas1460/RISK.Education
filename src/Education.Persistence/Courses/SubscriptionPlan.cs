using Education.Persistence.Abstractions;
using Education.Persistence.Orders;

namespace Education.Persistence.Courses;

public class SubscriptionPlan : BaseEntity
{
    public string Name { get; private set; }

    public int Duration { get; private set; }

    public int DurationType { get; private set; }

    public double BasePrice { get; private set; }

    public double DiscountedPrice { get; private set; }

    public int? CourseId { get; private set; }

    public virtual Course? Course { get; private set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; private set; } = new List<OrderDetail>();
}
