using System;

namespace Labs.ArmorStrike.Domain
{
    /// <summary>Полный протокол поединка.</summary>
    public sealed class BoutReport
    {
        public BoutReport(StrikeReport firstStrike, StrikeReport secondStrike, Verdict verdict)
        {
            FirstStrike = firstStrike ?? throw new ArgumentNullException(nameof(firstStrike));
            SecondStrike = secondStrike ?? throw new ArgumentNullException(nameof(secondStrike));
            Verdict = verdict;
        }

        public StrikeReport FirstStrike { get; }

        public StrikeReport SecondStrike { get; }

        public Verdict Verdict { get; }
    }
}
