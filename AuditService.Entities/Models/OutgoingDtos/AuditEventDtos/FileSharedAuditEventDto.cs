namespace AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;

public class FileSharedAuditEventDto : AuditEventDto
{
    public override string EventType => "FileShared";
    public Guid RecipientId { get; set; }
    public Guid ConversationId { get; set; }
}