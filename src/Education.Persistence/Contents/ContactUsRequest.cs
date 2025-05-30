using Education.Persistence.Abstractions;

namespace Education.Persistence.Contents;

public class ContactUsRequest : BaseEntity
{
    public string? FullName { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string? Message { get; private set; }
}
