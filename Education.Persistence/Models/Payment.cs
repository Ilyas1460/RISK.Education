namespace Education.Persistence.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public double Amount { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? CallbackResponse { get; set; }

    public virtual Order? Order { get; set; }
}
