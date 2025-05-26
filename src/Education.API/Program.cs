using Education.API.Extensions;
using Education.Application;
using Education.Infrastructure;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddExceptionHandling();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapControllers();

app.Run();

public partial class Program
{
}
