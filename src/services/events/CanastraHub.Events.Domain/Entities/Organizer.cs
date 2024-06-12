using CanastraHub.Core.DomainObjects;

namespace CanastraHub.Events.Domain.Entities;
public class Organizer : Entity
{
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public Organizer(string name, string document, string email, string phone)
    {
        Name = name;
        Email = email;
        Document = document;
        Phone = phone;
    }
}
