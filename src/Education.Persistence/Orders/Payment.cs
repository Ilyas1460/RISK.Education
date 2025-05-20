using Education.Persistence.Abstractions;

namespace Education.Persistence.Orders;

public class Payment : BaseEntity
{
    public int? OrderId { get; set; }

    public double Amount { get; set; }

    public string? CallbackResponse { get; set; }

    public virtual Order? Order { get; set; }
}
