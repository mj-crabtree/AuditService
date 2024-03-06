using System.ComponentModel.DataAnnotations;
using AuditService.Entities.Discriminators;

namespace AuditService.Entities.Models.IncomingDtos;

public abstract class AuditEventCreationDto : IEventDiscriminator, IMappableEventDto
{
    public DateTime EventTimeStamp { get; protected init; } = DateTime.Now;
    [Required] public DateTime OperationTimeStamp { get; set; }
    [Required] public Guid TrackedFileId { get; set; }
    [Required] public Guid TrackedUserId { get; set; }
    public string EventType { get; protected init; } = string.Empty;
}