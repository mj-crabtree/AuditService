using System.ComponentModel.DataAnnotations;

namespace AuditService.Entities.Models.IncomingDtos;

public class FileClassifiedEventCreationDto : AuditEventCreationDto
{
    public FileClassifiedEventCreationDto()
    {
        EventType = "FileClassified";
    }

    [Required] public string OldClassificationTier { get; set; }
    [Required] public string NewClassificationTier { get; set; }
    [Required] public bool SuccessfulClassification { get; set; }
    [Required] public string CurrentClassification { get; set; }
}