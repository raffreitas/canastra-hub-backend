using CanastraHub.Core.DomainObjects;

namespace CanastraHub.Events.Domain.Entities;
public class Event : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid OrganizerId { get; private set; }
    public decimal Price { get; private set; }

    private readonly List<Registration> _registrations = [];
    public IReadOnlyCollection<Registration> Registrations => _registrations.AsReadOnly();

    private readonly List<Participant> _participants = [];
    public IReadOnlyCollection<Participant> Participants => _participants.AsReadOnly();

    public Event(string title, string description, DateTime startDate, DateTime endDate, Guid organizerId, decimal price)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        OrganizerId = organizerId;
        Price = price;
    }
}
