using Education.Persistence.Abstractions;

namespace Education.Persistence.Orders;

public class Payment : BaseEntity
{
    public int? OrderId { get; private set; }

    public double Amount { get; private set; }

    public string? CallbackResponse { get; private set; }

    public virtual Order? Order { get; private set; }
}
