using CanastraHub.Core.Exceptions;
using CanastraHub.Raffles.Domain.Entities;

using FluentAssertions;

namespace CanastraHub.Raffles.Domain.Tests.Entities;

public class RaffleTests
{
    [Fact(DisplayName = "Raffle Is Open Add Participant Successfully")]
    [Trait("Category", "Raffle")]
    public void RaffleIsOpen_AddParticipant_ShouldAddParticipant()
    {
        // Arrange
        var raffle = new Raffle("Some Title", "Some Description", 2, DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(2));
        var participant = new Participant("Some name", "some document", "some.email@email.com", "+5599999999999");

        // Act
        raffle.AddParticipant(participant);

        // Assert
        raffle.Participants.Should().HaveCount(1);
    }

    [Fact(DisplayName = "Raffle Is Closed Add Participant Should Throw DomainException")]
    [Trait("Category", "Raffle")]
    public void RaffleIsClosed_AddParticipant_ShouldThrowDomainException()
    {
        // Arrange
        var raffle = new Raffle("Some Title", "Some Description", 2, DateTime.UtcNow.AddDays(-2), DateTime.UtcNow.AddDays(-1));
        var participant = new Participant("Some name", "some document", "some.email@email.com", "+5599999999999");

        // Act
        var act = () => raffle.AddParticipant(participant);

        // Assert
        act.Should().Throw<DomainException>().WithMessage("Esta rifa já esta finalizada.");
    }

    [Fact(DisplayName = "Add Participant Already Added Should Throw DomainException")]
    [Trait("Category", "Raffle")]
    public void ParticipantAlreadyAdded_AddParticipant_ShouldThrowDomainException()
    {
        // Arrange
        var raffle = new Raffle("Some Title", "Some Description", 2, DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(2));
        var participant1 = new Participant("Some name", "some document", "some.email@email.com", "+5599999999999");
        raffle.AddParticipant(participant1);

        var participant2 = new Participant("Some name", "some document", "some.email@email.com", "+5599999999999");

        // Act
        var act = () => raffle.AddParticipant(participant2);

        // Assert
        act.Should().Throw<DomainException>().WithMessage("Este participante já está cadastrado.");
    }
}