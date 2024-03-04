using AuditService.Entities.Entities.AuditEvents;
using AuditService.ResourceParameters;

namespace AuditService.Services.Repositories;

public interface IEventRepository
{
    void AddAuditEvent(AuditEvent auditEvent);
    Task<AuditEvent> GetAuditEventAsync(Guid eventId);
    Task<ICollection<AuditEvent>> GetAuditEventsAsync();
    Task<ICollection<AuditEvent>> GetAuditEventsAsync(AuditEventsResourceParameters parameters);
    Task<bool> SaveAsync();
}