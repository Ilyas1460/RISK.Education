using Microsoft.AspNetCore.Mvc;

namespace Education.IntegrationTests.Common.Response;

public class CustomProblemDetails : ValidationProblemDetails
{
    public string? TraceId { get; set; }
    public string? RequestId { get; set; }
}
