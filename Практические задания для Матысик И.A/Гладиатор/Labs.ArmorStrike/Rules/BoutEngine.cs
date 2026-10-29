using System;
using Labs.ArmorStrike.Domain;
using Labs.Common.Journal;

namespace Labs.ArmorStrike.Rules
{
    /// <summary>
    /// Проводит единичный обмен: по каждому из двух бойцов наносится по одному удару,
    /// после чего сравнивается остаток здоровья.
    /// </summary>
    public sealed class BoutEngine
    {
        private readonly IStrikeRoller _roller;
        private readonly ProportionalStrikeResolver _resolver;
        private readonly IEventJournal _journal;

        public BoutEngine(IStrikeRoller roller, ProportionalStrikeResolver resolver, IEventJournal journal)
        {
            _roller = roller ?? throw new ArgumentNullException(nameof(roller));
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public BoutReport Run(Fighter first, Fighter second)
        {
            StrikeReport firstStrike = Strike(FighterSlot.First, first);
            StrikeReport secondStrike = Strike(FighterSlot.Second, second);
            Verdict verdict = Adjudicate(firstStrike.After.Health, secondStrike.After.Health);

            _journal.Info("Вердикт поединка: " + verdict);
            return new BoutReport(firstStrike, secondStrike, verdict);
        }

        private StrikeReport Strike(FighterSlot slot, Fighter target)
        {
            double attack = _roller.Roll(target.Armor);
            Fighter after = _resolver.Apply(target, attack);

            _journal.Debug(string.Format(
                "{0}: attack={1}, health={2}, armor={3}", slot.Genitive, attack, after.Health, after.Armor));

            return new StrikeReport(slot, attack, after);
        }

        private static Verdict Adjudicate(double firstHealth, double secondHealth)
        {
            if (firstHealth > secondHealth)
            {
                return Verdict.FirstHealthier;
            }

            return firstHealth < secondHealth ? Verdict.SecondHealthier : Verdict.Tie;
        }
    }
}
