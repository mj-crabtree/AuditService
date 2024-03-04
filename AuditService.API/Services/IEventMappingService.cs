using AuditService.Entities.Models;

namespace AuditService.Services;

public interface IEventMappingService<TEntity, TDto>
{
    TEntity MapDtoToEntity(IMappableEventDto sourceDto);
    TDto MapEntityToDto(IMappableEventEntity sourceEntity);
}