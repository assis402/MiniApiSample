using Microsoft.EntityFrameworkCore;

namespace MiniApiSample.Data;

public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options) { }

    public DbSet<Event> Tarefas => Set<Event>();
}
