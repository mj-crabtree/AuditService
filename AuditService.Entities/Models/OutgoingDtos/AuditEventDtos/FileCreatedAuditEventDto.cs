namespace AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;

public class FileCreatedAuditEventDto : AuditEventDto
{
    public override string EventType => "FileCreated";
}