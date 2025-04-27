using Education.Application;
using Education.Infrastructure;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
