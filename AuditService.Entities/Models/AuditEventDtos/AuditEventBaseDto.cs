namespace AuditService.Entities.Models.AuditEventDtos;

public abstract class AuditEventBaseDto
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public TrackedUserDto UserDto { get; set; }
    public TrackedFileDto FileDto { get; set; }
}