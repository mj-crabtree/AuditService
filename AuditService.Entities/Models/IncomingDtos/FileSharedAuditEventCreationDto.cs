namespace AuditService.Entities.Models.IncomingDtos;

class FileSharedAuditEventCreationDto : AuditEventCreationDto
{
    public FileSharedAuditEventCreationDto()
    {
        EventType = "FileShared";
    }

    public Guid RecipientId { get; set; }
    public Guid ConversationId { get; set; }
}