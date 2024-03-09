namespace AuditService.Entities.Models.IncomingDtos;

class FileAccessedAuditEventCreationDto : AuditEventCreationDto
{
    public FileAccessedAuditEventCreationDto()
    {
        EventType = "FileAccessed";
    }
}