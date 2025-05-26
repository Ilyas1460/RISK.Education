using Education.Persistence.Abstractions;

namespace Education.Persistence.Contents;

public class ContactUsRequest : BaseEntity
{
    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Message { get; set; }
}
