using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoteManagerServices.Entities;

namespace NoteManagerServices.AppDbContext;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Note>? Notes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}