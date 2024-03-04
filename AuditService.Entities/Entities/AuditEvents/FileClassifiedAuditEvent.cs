using System.ComponentModel.DataAnnotations;

namespace AuditService.Entities.Entities.AuditEvents;

public class FileClassifiedAuditEvent : AuditEvent
{
    [Required] public string OldClassificationTier { get; set; }
    [Required] public string NewClassificationTier { get; set; }
    [Required] public bool SuccessfulClassification { get; set; }
    [Required] public string CurrentClassification { get; set; }
    public override string EventType => "FileClassified";
}