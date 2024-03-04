using Microsoft.EntityFrameworkCore;

namespace AuditService.DbContexts;

public class AuditDbContext : DbContext
{
    public AuditDbContext(DbContextOptions options) : base(options)
    {
    }
}