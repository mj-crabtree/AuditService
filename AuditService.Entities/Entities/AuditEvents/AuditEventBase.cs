using System.ComponentModel.DataAnnotations;

namespace AuditService.Entities.Entities.AuditEvents;

public abstract class AuditEventBase
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public DateTime Created { get; set; }
    [Required]
    public TrackedFile File { get; set; }
    [Required]
    public TrackedUser User { get; set; }
}