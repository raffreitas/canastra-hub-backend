using CanastraHub.Core.DomainObjects;

namespace CanastraHub.Events.Domain.Entities;
public class Participant : Entity
{
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public Participant(string name, string document, string phone, string email)
    {
        Name = name;
        Document = document;
        Phone = phone;
        Email = email;
    }
}
