using AuditService.DbContexts;
using AuditService.Entities.Entities;
using AuditService.Entities.Entities.AuditEvents;
using AuditService.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Services.Repositories;

public class EventRepository : IEventRepository
{
    private readonly AuditDbContext _context;

    public EventRepository(AuditDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    ///     Adds an audit event to the database.
    /// </summary>
    /// <param name="auditEvent">The audit event to be added.</param>
    public void AddAuditEvent(AuditEvent auditEvent)
    {
        if (auditEvent == null)
        {
            throw new ArgumentNullException(nameof(auditEvent));
        }
        
        auditEvent.Id = Guid.NewGuid();
        _context.AuditEvents.Add(auditEvent);
    }

    /// <summary>
    ///     Retrieves an audit event from the database based on the event ID.
    /// </summary>
    /// <param name="eventId">The ID of the audit event to retrieve.</param>
    /// <returns>The audit event with the specified ID.</returns>
    public async Task<AuditEvent> GetAuditEventAsync(Guid eventId)
    {
        if (eventId == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(eventId));
        }

        return await _context.AuditEvents.FirstOrDefaultAsync(ae => ae.Id == eventId);
    }

    /// <summary>
    ///     Retrieves all audit events from the database.
    /// </summary>
    /// <returns>A collection of audit events.</returns>
    /// <remarks>
    ///     This method retrieves all audit events from the database in descending order based on their timestamp.
    /// </remarks>
    public async Task<ICollection<AuditEvent>> GetAuditEventsAsync()
    {
        return await _context.AuditEvents.OrderByDescending(ae => ae.TimeStamp).ToListAsync();
    }

    /// <summary>
    ///     Retrieves a collection of audit events from the database based on the provided resource parameters.
    /// </summary>
    /// <param name="eventsResourceParameters">The resource parameters used for filtering the audit events collection.</param>
    /// <returns>A collection of <see cref="AuditEvent" /> objects that match the provided resource parameters.</returns>
    public async Task<ICollection<AuditEvent>> GetAuditEventsAsync(
        AuditEventsResourceParameters eventsResourceParameters)
    {
        if (string.IsNullOrWhiteSpace(eventsResourceParameters.FileId)
            && string.IsNullOrWhiteSpace(eventsResourceParameters.UserId)
            && string.IsNullOrWhiteSpace(eventsResourceParameters.SearchQuery))
        {
            return await GetAuditEventsAsync();
        }

        var collection = _context.AuditEvents as IQueryable<AuditEvent>;

        if (!string.IsNullOrWhiteSpace(eventsResourceParameters.FileId))
        {
            if (Guid.TryParse(eventsResourceParameters.FileId, out var fileId))
            {
                collection = collection.Where(ae => ae.TrackedFileId == fileId);
            }
            else
            {
                throw new ArgumentException(nameof(eventsResourceParameters.FileId));
            }
        }

        if (!string.IsNullOrWhiteSpace(eventsResourceParameters.UserId))
        {
            if (Guid.TryParse(eventsResourceParameters.UserId, out var userId))
            {
                collection = collection.Where(ae => ae.TrackedUserId == userId);
            }
            else
            {
                throw new ArgumentException(nameof(eventsResourceParameters.UserId));
            }
        }

        return await collection.ToListAsync();
    }

    /// <summary>
    ///     Saves changes made in the context to the underlying database.
    /// </summary>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result is a boolean value indicating whether the save
    ///     operation was successful or not.
    /// </returns>
    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}