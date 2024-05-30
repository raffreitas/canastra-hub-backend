using CanastraHub.Core.DomainObjects;
using CanastraHub.Core.Exceptions;

namespace CanastraHub.Raffles.Domain.Entities;
public class Raffle : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal QuotaUnitPrice { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive => StartDate <= DateTime.UtcNow && EndDate >= DateTime.UtcNow;

    private readonly IList<Participant> _participants = [];
    public IReadOnlyCollection<Participant> Participants => _participants.AsReadOnly();

    private readonly IList<Quota> _quotas = [];
    public IReadOnlyCollection<Quota> Quotas => _quotas.AsReadOnly();

    public Raffle(string title, string description, decimal quotaUnitPrice, DateTime startDate, DateTime endDate)
    {
        Title = title;
        Description = description;
        QuotaUnitPrice = quotaUnitPrice;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void AddParticipant(Participant participant)
    {
        if (!IsActive)
            throw new DomainException("Esta rifa já esta finalizada.");

        if (_participants.Any(p => p.Document == participant.Document))
            throw new DomainException("Este participante já está cadastrado.");

        _participants.Add(participant);

    }

    public void AddQuota(Quota quota)
    {
        if (!IsActive)
            throw new DomainException("Esta rifa ainda não foi finalizada.");

        _quotas.Add(quota);
    }
}
