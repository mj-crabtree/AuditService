namespace AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;

public abstract class AuditEventDto : IMappableEventDto
{
    public Guid Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public Guid TrackedFileId { get; set; }
    public Guid TrackedUserId { get; set; }
    public virtual string EventType => string.Empty;
}