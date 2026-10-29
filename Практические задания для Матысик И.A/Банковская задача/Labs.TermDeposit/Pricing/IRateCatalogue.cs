using Labs.TermDeposit.Domain;

namespace Labs.TermDeposit.Pricing
{
    /// <summary>Источник годовых ставок по срокам размещения.</summary>
    public interface IRateCatalogue
    {
        /// <exception cref="UnsupportedTermException">Срок отсутствует в тарифной сетке.</exception>
        double ResolveAnnualRate(int termInDays);
    }
}
