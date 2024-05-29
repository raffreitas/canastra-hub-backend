namespace CanastraHub.Raffles.Domain.Utils;
public class QuotaNumberGenerator
{
    private readonly static Random _random = new();

    public string GetNextQuotaNumber(HashSet<int> usedNumbers)
    {
        int number;
        do
        {
            number = _random.Next(1, 10000);
        } while (usedNumbers.Contains(number));

        usedNumbers.Add(number);
        return number.ToString();
    }
}
