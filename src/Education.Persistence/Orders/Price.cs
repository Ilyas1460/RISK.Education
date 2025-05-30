using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Orders;

public class Price : BaseEntity
{
    public int? CourseId { get; private set; }

    public double OriginalPrice { get; private set; }

    public double Discount { get; private set; }

    public virtual Course? Course { get; private set; }
}
