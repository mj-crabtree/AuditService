using AuditService.Entities.Entities.AuditEvents;
using AuditService.Entities.Models;
using AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;

namespace AuditService.Services.EventServices;

public class AuditEventService : IAuditEventService
{
    private readonly IAuditEventBuilder _auditEventBuilder;
    private readonly IEventMappingService<AuditEvent, AuditEventDto> _eventMappingService;
    private readonly ITrackedFileService _trackedFileService;
    private readonly ITrackedUserService _trackedUserService;

    public AuditEventService(ITrackedFileService trackedFileService, ITrackedUserService trackedUserService,
        IAuditEventBuilder auditEventBuilder, IEventMappingService<AuditEvent, AuditEventDto> eventMappingService)
    {
        _trackedFileService = trackedFileService ?? throw new ArgumentNullException(nameof(trackedFileService));
        _trackedUserService = trackedUserService ?? throw new ArgumentNullException(nameof(trackedUserService));
        _auditEventBuilder = auditEventBuilder ?? throw new ArgumentNullException(nameof(auditEventBuilder));
        _eventMappingService = eventMappingService ?? throw new ArgumentNullException(nameof(eventMappingService));
    }

    public AuditEvent CreateNewEvent(IMappableEventDto newEventDto)
    {
        if (newEventDto == null)
        {
            throw new ArgumentNullException(nameof(newEventDto));
        }

        var entity = _eventMappingService.MapDtoToEntity(newEventDto);
        var preparedEvent = BuildAuditEvent(entity);
        return preparedEvent;
    }

    public AuditEventDto GetEventDto(AuditEvent auditEvent)
    {
        if (auditEvent == null)
        {
            throw new ArgumentNullException(nameof(auditEvent));
        }

        var dtoToReturn = _eventMappingService.MapEntityToDto(auditEvent);
        return dtoToReturn;
    }

    public List<AuditEventDto> GetEventDto(IEnumerable<AuditEvent> auditEvents)
    {
        return auditEvents.Select(_eventMappingService.MapEntityToDto).ToList();
    }

    private AuditEvent BuildAuditEvent(AuditEvent auditEvent)
    {
        // we're going to use this when we're creating a new auditEvent to be persisted to the database
        if (auditEvent == null)
        {
            throw new ArgumentNullException(nameof(auditEvent));
        }

        var file = _trackedFileService.GetOrCreateFile(auditEvent.TrackedFileId);
        var user = _trackedUserService.GetOrCreateUser(auditEvent.TrackedUserId);

        // we're not _building_ as much as we are *fleshing out*
        var eventToReturn = _auditEventBuilder
            .WithEvent(auditEvent)
            .WithTrackedFile(file)
            .WithTrackedUser(user)
            .Build();

        return eventToReturn;
    }
}