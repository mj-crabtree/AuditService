namespace AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;

public class FileClassifiedAuditEventDto : AuditEventDto
{
    public string OldClassificationTier { get; set; }
    public string NewClassificationTier { get; set; }
    public bool SuccessfulClassification { get; set; }
    public string CurrentClassification { get; set; }
    public override string EventType => "FileClassified";
}