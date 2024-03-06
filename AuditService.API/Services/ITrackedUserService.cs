using AuditService.DbContexts;
using AuditService.Entities.Entities;

namespace AuditService.Services;

public interface ITrackedUserService
{
    bool UserExists(Guid userId);
    TrackedUser GetOrCreateUser(Guid userId);
}

public class TrackedUserService : ITrackedUserService
{
    private readonly AuditDbContext _context;

    public TrackedUserService(AuditDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool UserExists(Guid userId)
    {
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        return _context.TrackedUsers.Any(u => u.Id == userId);
    }

    public TrackedUser GetOrCreateUser(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        var user = _context.TrackedUsers.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            user = new TrackedUser { Id = userId };
            _context.TrackedUsers.Add(user);
        }

        return user;
    }
}