namespace AuditService.Entities.Discriminators;

public interface IEventDiscriminator
{
    string EventType { get; }
}