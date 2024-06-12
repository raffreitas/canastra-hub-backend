using CanastraHub.Core.DomainObjects;
using CanastraHub.Events.Domain.Enums;

namespace CanastraHub.Events.Domain.Entities;
public class Registration : Entity
{
    public Guid EventId { get; private set; }
    public Guid ParticipantId { get; private set; }
    public decimal Value { get; private set; }
    public RegistrationStatus Status { get; private set; }

    public Registration(Guid eventId, Guid participantId, decimal value)
    {
        EventId = eventId;
        ParticipantId = participantId;
        Value = value;
        Status = RegistrationStatus.Pending;
    }
}
