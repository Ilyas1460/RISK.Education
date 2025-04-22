using Education.Application;
using Education.Infrastructure;

WebApplicationBuilder? builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

WebApplication? app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
