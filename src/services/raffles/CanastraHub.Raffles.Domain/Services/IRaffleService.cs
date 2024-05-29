using CanastraHub.Raffles.Domain.Entities;

namespace CanastraHub.Raffles.Domain.Services;
public interface IRaffleService
{
    IList<Quota> CreateQuotas(Raffle raffle, Participant participant, int quantity, HashSet<int> usedNumbers);
}
