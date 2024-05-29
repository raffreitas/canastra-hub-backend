using CanastraHub.Core.DomainObjects;

namespace CanastraHub.Raffles.Domain.Entities;
public class Participant : Entity
{
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    public Participant(string name, string document, string email, string phoneNumber)
    {
        Name = name;
        Document = document;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
