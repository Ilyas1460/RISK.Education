using Education.Persistence.Abstractions;
using Education.Persistence.Users;

namespace Education.Persistence.Orders;

public class Order : BaseEntity
{
    public int? UserId { get; set; }

    public int Status { get; set; }

    public string OrderNumber { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }
}
