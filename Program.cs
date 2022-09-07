
using Microsoft.EntityFrameworkCore;
using MiniApiSample.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqliteConnectionString")
          ?? "Data Source=events.db";

builder.Services.AddSqlite<EventDbContext>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await EnsureDBExists(app.Services, app.Logger);

app.MapGet("/", () => "Hello World!");

app.MapSwagger();
app.UseSwaggerUI();

app.Run();

async Task EnsureDBExists(IServiceProvider services, ILogger logger)
{
    using var db = services.CreateScope().ServiceProvider.GetRequiredService<EventDbContext>();
    await db.Database.EnsureCreatedAsync();
    await db.Database.MigrateAsync();
}