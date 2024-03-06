using AuditService.Entities.Models.IncomingDtos;
using AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;
using AuditService.ResourceParameters;
using AuditService.Services.EventServices;
using AuditService.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuditService.Controllers;

[ApiController]
[Route("/api/events")]
public class EventController : ControllerBase
{
    private readonly IAuditEventService _auditEventService;
    private readonly IEventRepository _repository;

    public EventController(IEventRepository repository, IAuditEventService auditEventService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _auditEventService = auditEventService ?? throw new ArgumentNullException(nameof(auditEventService));
    }

    [HttpGet]
    [Route("{id}", Name = "GetEvent")]
    public async Task<ActionResult<AuditEventDto>> GetEvent(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }

        var eventFromRepo = await _repository.GetAuditEventAsync(id);
        var eventToReturn = _auditEventService.GetEventDto(eventFromRepo);
        return Ok(eventToReturn);
    }

    [HttpGet(Name = "GetEvents")]
    public async Task<ActionResult<List<AuditEventDto>>> GetEvents(
        [FromQuery] AuditEventsResourceParameters? parameters)
    {
        var eventsFromRepo = await _repository.GetAuditEventsAsync(parameters);
        var eventsToReturn = _auditEventService.GetEventDto(eventsFromRepo);
        return Ok(eventsToReturn);
    }

    [HttpPost(Name = "CreateEvent")]
    public async Task<ActionResult<AuditEventDto>> CreateEvent(AuditEventCreationDto eventDto)
    {
        var newEvent = _auditEventService.CreateNewEvent(eventDto);
        _repository.AddAuditEvent(newEvent);
        await _repository.SaveAsync();
        var eventToReturn = _auditEventService.GetEventDto(newEvent);
        return CreatedAtRoute("GetEvent", new { id = newEvent.Id }, eventToReturn);
    }
}