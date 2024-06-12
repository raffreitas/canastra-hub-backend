using CanastraHub.Core.DomainObjects;
using CanastraHub.Events.Domain.Enums;

namespace CanastraHub.Events.Domain.Entities;
public class Payment : Entity
{
    public Guid EventId { get; private set; }
    public Guid ParticipantId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public Guid? TransactionId { get; private set; }

    public Payment(Guid eventId, Guid participantId, decimal amount)
    {
        EventId = eventId;
        ParticipantId = participantId;
        Amount = amount;
        Status = PaymentStatus.Pending;
    }
}
