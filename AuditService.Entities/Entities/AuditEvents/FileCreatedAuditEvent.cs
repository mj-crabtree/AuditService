namespace AuditService.Entities.Entities.AuditEvents;

public class FileCreatedAuditEvent : AuditEvent
{
    public override string EventType => "FileCreated";
}