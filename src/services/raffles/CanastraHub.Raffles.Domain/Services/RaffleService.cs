using CanastraHub.Raffles.Domain.Entities;
using CanastraHub.Raffles.Domain.Utils;

namespace CanastraHub.Raffles.Domain.Services;
public class RaffleService : IRaffleService
{
    private readonly QuotaNumberGenerator _quotaNumberGenerator;

    public RaffleService(QuotaNumberGenerator quotaNumberGenerator)
    {
        _quotaNumberGenerator = quotaNumberGenerator;
    }

    public IList<Quota> CreateQuotas(Raffle raffle, Participant participant, int quantity, HashSet<int> usedNumbers)
    {
        decimal unitPrice = quantity >= 50 ? raffle.QuotaUnitPrice * 0.25m : raffle.QuotaUnitPrice;

        var quotas = new List<Quota>();

        for (var i = 0; i < quantity; i++)
        {
            var number = _quotaNumberGenerator.GetNextQuotaNumber(usedNumbers);
            var quota = new Quota(number, unitPrice, raffle.Id, participant.Id);
            quotas.Add(quota);
        }

        return quotas;
    }
}
