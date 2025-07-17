using Education.Persistence.Abstractions;
using Education.Persistence.Courses;

namespace Education.Persistence.Orders;

public class Price : BaseEntity
{
    public int? CourseId { get; set; }

    public double OriginalPrice { get; set; }

    public double Discount { get; set; }

    public virtual Course? Course { get; set; }
}
