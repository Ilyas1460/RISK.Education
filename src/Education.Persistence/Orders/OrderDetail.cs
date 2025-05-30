using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Orders;

public class OrderDetail : BaseEntity
{
    public int? OrderId { get; private set; }

    public int? CourseId { get; private set; }

    public int CourseAccessType { get; private set; }

    public double? Price { get; private set; }

    public int? SubscriptionPlanId { get; private set; }

    public virtual Course? Course { get; private set; }

    public virtual Order? Order { get; private set; }

    public virtual SubscriptionPlan? SubscriptionPlan { get; private set; }
}
