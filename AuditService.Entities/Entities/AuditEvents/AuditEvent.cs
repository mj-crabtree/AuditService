using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuditService.Entities.Discriminators;
using AuditService.Entities.Models;

namespace AuditService.Entities.Entities.AuditEvents;

public abstract class AuditEvent : IEventDiscriminator, IMappableEventEntity
{
    [Key] public Guid Id { get; set; }
    [Required] public DateTime TimeStamp { get; set; }
    [Required] [ForeignKey("TrackedFile")] public Guid TrackedFileId { get; set; }
    [Required] [ForeignKey("TrackedUser")] public Guid TrackedUserId { get; set; }
    [Required] public TrackedFile TrackedFile { get; set; }
    [Required] public TrackedUser TrackedUser { get; set; }
    [NotMapped] public virtual string EventType { get; } = string.Empty;
}