using CanastraHub.Core.DomainObjects;
using CanastraHub.Raffles.Domain.Enums;

namespace CanastraHub.Raffles.Domain.Entities;
public class Quota : Entity
{
    public string Number { get; private set; }
    public decimal Value { get; private set; }
    public Guid RaffleId { get; private set; }
    public Guid ParticipantId { get; private set; }
    public Guid OrderId { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }

    public Quota(string number, decimal value, Guid raffleId, Guid participantId)
    {
        Number = number;
        Value = value;
        RaffleId = raffleId;
        ParticipantId = participantId;
        PaymentStatus = PaymentStatus.Pending;
    }

    public void AssignToOrder(Guid orderId)
    {
        OrderId = orderId;
    }

    public void MarkAsPaid()
    {
        PaymentStatus = PaymentStatus.Paid;
    }

    public void MarkAsRefunded()
    {
        PaymentStatus = PaymentStatus.Refunded;
    }
}
