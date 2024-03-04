using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditService.Entities.Entities.AuditEvents;

public class FileSharedAuditEvent : AuditEvent
{
    [Required] public TrackedUser Recipient { get; set; }
    [Required] public Guid RecipientId { get; set; }
    [NotMapped] public override string EventType => "FileShared";
}