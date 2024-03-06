using AuditService.Entities.Models;

namespace AuditService.Services.EventServices;

public interface IEventMappingService<TEntity, TDto>
{
    TEntity MapDtoToEntity(IMappableEventDto sourceDto);
    TDto MapEntityToDto(IMappableEventEntity sourceEntity);
}