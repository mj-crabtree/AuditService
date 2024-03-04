using AuditService.Entities.Entities;
using AuditService.Entities.Entities.AuditEvents;
using Microsoft.EntityFrameworkCore;

namespace AuditService.DbContexts;

public class AuditDbContext : DbContext
{
    public AuditDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AuditEvent> AuditEvents { get; set; }
    public DbSet<TrackedUser> TrackedUsers { get; set; }
    public DbSet<TrackedFile> TrackedFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditEvent>()
            .HasDiscriminator<string>("event_type")
            .HasValue<FileCreatedAuditEvent>("file_created")
            .HasValue<FileSharedAuditEvent>("file_shared")
            .HasValue<FileClassifiedAuditEvent>("file_classified");
    }
}