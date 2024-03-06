using AuditService.Entities.Entities;
using AuditService.Entities.Entities.AuditEvents;

namespace AuditService.Services.EventServices;

public interface IAuditEventBuilder
{
    AuditEventBuilder WithEvent(AuditEvent auditEvent);
    AuditEventBuilder WithTrackedFile(TrackedFile file);
    AuditEventBuilder WithTrackedUser(TrackedUser user);
    AuditEvent Build();
    void Reset();
}

public class AuditEventBuilder : IAuditEventBuilder
{
    private AuditEvent _auditEvent;

    public AuditEventBuilder WithEvent(AuditEvent auditEvent)
    {
        _auditEvent = auditEvent;
        return this;
    }

    public AuditEventBuilder WithTrackedFile(TrackedFile file)
    {
        _auditEvent.TrackedFile = file;
        return this;
    }

    public AuditEventBuilder WithTrackedUser(TrackedUser user)
    {
        _auditEvent.TrackedUser = user;
        return this;
    }

    public AuditEvent Build()
    {
        _auditEvent.Id = Guid.NewGuid();
        return _auditEvent;
    }

    public void Reset()
    {
    }
}