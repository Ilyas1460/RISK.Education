namespace Education.Persistence.Models;

public partial class Price
{
    public int Id { get; set; }

    public int? CourseId { get; set; }

    public double OriginalPrice { get; set; }

    public double Discount { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Course? Course { get; set; }
}
