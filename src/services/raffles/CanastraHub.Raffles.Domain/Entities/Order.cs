using CanastraHub.Core.DomainObjects;
using CanastraHub.Raffles.Domain.Enums;

namespace CanastraHub.Raffles.Domain.Entities;
public class Order : Entity, IAggregateRoot
{
    public Guid RaffleId { get; private set; }
    public Guid ParticipantId { get; private set; }
    public decimal TotalValue { get; private set; }
    public OrderStatus OrderStatus { get; private set; }

    private readonly IList<Quota> _quotas = [];
    public IReadOnlyCollection<Quota> Quotas => _quotas.AsReadOnly();

    public Order(Guid raffleId, Guid participantId)
    {
        RaffleId = raffleId;
        ParticipantId = participantId;
        OrderStatus = OrderStatus.Created;
    }

    private void CalculateTotal()
    {
        TotalValue = Quotas.Sum(q => q.Value);
    }

    public void AddQuota(Quota quota)
    {
        quota.AssignToOrder(Id);

        _quotas.Add(quota);

        CalculateTotal();
    }

    public void MarkAsPaid()
    {
        OrderStatus = OrderStatus.Paid;
        foreach (var quota in Quotas)
        {
            quota.MarkAsPaid();
        }
    }

    public void MarkAsRefunded()
    {
        OrderStatus = OrderStatus.Refunded;
        foreach (var quota in Quotas)
        {
            quota.MarkAsRefunded();
        }
    }
}
