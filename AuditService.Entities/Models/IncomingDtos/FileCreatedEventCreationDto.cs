namespace AuditService.Entities.Models.IncomingDtos;

public class FileCreatedEventCreationDto : AuditEventCreationDto
{
    public FileCreatedEventCreationDto()
    {
        EventType = "FileCreated";
    }
}