using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Orders;

public class OrderDetail : BaseEntity
{
    public int? OrderId { get; set; }

    public int? CourseId { get; set; }

    public int CourseAccessType { get; set; }

    public double? Price { get; set; }

    public int? SubscriptionPlanId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Order? Order { get; set; }

    public virtual SubscriptionPlan? SubscriptionPlan { get; set; }
}
