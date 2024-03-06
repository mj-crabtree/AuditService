using AuditService.Entities.Entities.AuditEvents;
using AuditService.Entities.Models;
using AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;

namespace AuditService.Services.EventServices;

public interface IAuditEventService
{
    AuditEvent CreateNewEvent(IMappableEventDto newEventDto);
    AuditEventDto GetEventDto(AuditEvent auditEvent);
    List<AuditEventDto> GetEventDto(IEnumerable<AuditEvent> auditEvents);
}