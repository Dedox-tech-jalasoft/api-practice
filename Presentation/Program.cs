var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRestApiExtensions();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseRestApiExtensions();

app.Run();
