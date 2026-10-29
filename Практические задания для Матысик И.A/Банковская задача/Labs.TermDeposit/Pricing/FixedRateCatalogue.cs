using System.Collections.Generic;
using Labs.TermDeposit.Domain;

namespace Labs.TermDeposit.Pricing
{
    /// <summary>
    /// Статическая тарифная сетка: 91 день — 11.5 %, 181 день — 11.75 %, 365 дней — 12.5 % годовых.
    /// </summary>
    public sealed class FixedRateCatalogue : IRateCatalogue
    {
        private static readonly IReadOnlyDictionary<int, double> Tiers = new Dictionary<int, double>
        {
            { 91, 11.5 },
            { 181, 11.75 },
            { 365, 12.5 },
        };

        public double ResolveAnnualRate(int termInDays)
        {
            double rate;
            if (!Tiers.TryGetValue(termInDays, out rate))
            {
                throw new UnsupportedTermException(termInDays);
            }

            return rate;
        }
    }
}
