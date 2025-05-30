using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Orders;

public class Order : BaseEntity
{
    public int? UserId { get; private set; }

    public int Status { get; private set; }

    public string OrderNumber { get; private set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; private set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; private set; } = new List<Payment>();

    public virtual User? User { get; private set; }
}
