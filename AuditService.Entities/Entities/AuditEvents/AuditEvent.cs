using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuditService.Entities.Discriminators;
using AuditService.Entities.Models;
using AuditService.Entities.Models.IncomingDtos;
using AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;

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

public class FileDownloadedAuditEvent : AuditEvent
{
    public override string EventType => "FileDownloaded";
}

public class FileDownloadedAuditEventCreationDto : AuditEventCreationDto
{
    public FileDownloadedAuditEventCreationDto()
    {
        EventType = "FileDownloaded";
    }
}

public class FileDownloadedAuditEventDto : AuditEventDto
{
    public override string EventType => "FileDownloaded";
}