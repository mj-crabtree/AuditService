using AuditService.Entities.Entities.AuditEvents;
using AuditService.Entities.Models.IncomingDtos;
using AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;
using AutoMapper;

namespace AuditService.Profiles;

public class AuditEventProfile : Profile
{
    public AuditEventProfile()
    {
        CreateMap<FileCreatedEventCreationDto, FileCreatedAuditEvent>()
            .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(_ => DateTime.Now));
        CreateMap<FileClassifiedEventCreationDto, FileClassifiedAuditEvent>()
            .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(_ => DateTime.Now));;

        CreateMap<FileCreatedAuditEvent, FileCreatedAuditEventDto>();
        CreateMap<FileClassifiedAuditEvent, FileClassifiedAuditEventDto>();
    }
}