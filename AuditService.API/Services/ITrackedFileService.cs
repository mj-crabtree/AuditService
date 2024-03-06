using AuditService.DbContexts;
using AuditService.Entities.Entities;

namespace AuditService.Services;

public interface ITrackedFileService
{
    bool FileExists(Guid fileId);

    TrackedFile GetOrCreateFile(Guid fileId);
}

public class TrackedFileService : ITrackedFileService
{
    private readonly AuditDbContext _context;

    public TrackedFileService(AuditDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public bool FileExists(Guid fileId)
    {
        if (fileId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(fileId));
        }

        return _context.TrackedFiles.Any(f => f.Id == fileId);
    }

    public TrackedFile GetOrCreateFile(Guid fileId)
    {
        if (fileId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(fileId));
        }

        var file = _context.TrackedFiles.FirstOrDefault(f => f.Id == fileId);
        if (file == null)
        {
            file = new TrackedFile { Id = fileId };
            _context.TrackedFiles.Add(file);
        }

        return file;
    }
}