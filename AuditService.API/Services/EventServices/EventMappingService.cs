using System.Runtime.CompilerServices;
using AuditService.Entities.Entities.AuditEvents;
using AuditService.Entities.Models;
using AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;
using AutoMapper;

namespace AuditService.Services.EventServices;

public class EventMappingService : IEventMappingService<AuditEvent, AuditEventDto>
{
    private readonly IMapper _mapper;

    public EventMappingService(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public AuditEvent MapDtoToEntity(IMappableEventDto sourceDto)
    {
        if (sourceDto == null)
        {
            throw new ArgumentNullException(nameof(sourceDto));
        }

        return sourceDto.EventType.ToLower() switch
        {
            "filecreated" => _mapper.Map<FileCreatedAuditEvent>(sourceDto),
            "fileclassified" => _mapper.Map<FileClassifiedAuditEvent>(sourceDto),
            _ => throw new SwitchExpressionException($"Unknown event type: {sourceDto.EventType}")
        };
    }

    public AuditEventDto MapEntityToDto(IMappableEventEntity sourceEntity)
    {
        if (sourceEntity == null)
        {
            throw new ArgumentNullException(nameof(sourceEntity));
        }

        return sourceEntity switch
        {
            FileCreatedAuditEvent fileCreatedEvent => _mapper.Map<FileCreatedAuditEventDto>(fileCreatedEvent),
            FileClassifiedAuditEvent fileClassifiedEvent => _mapper.Map<FileClassifiedAuditEventDto>(
                fileClassifiedEvent),
            _ => throw new SwitchExpressionException($"Unknown event type: {sourceEntity.GetType().Name}")
        };
    }
}