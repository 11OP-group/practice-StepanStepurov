using System;
using Labs.Arena.Domain;
using Labs.Common.Journal;
using Labs.Common.Timing;

namespace Labs.Arena.Combat
{
    /// <summary>
    /// Двигатель поединка: раунды чередуются до тех пор, пока оба бойца способны сражаться.
    /// В каждом раунде первым бьёт <c>striker</c>, затем <c>responder</c>.
    /// </summary>
    public sealed class DuelEngine
    {
        public static readonly TimeSpan BlowInterval = TimeSpan.FromSeconds(1);

        private readonly IDuelObserver _observer;
        private readonly IPacer _pacer;
        private readonly IEventJournal _journal;

        public DuelEngine(IDuelObserver observer, IPacer pacer, IEventJournal journal)
        {
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));
            _pacer = pacer ?? throw new ArgumentNullException(nameof(pacer));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public DuelOutcome Run(Combatant responder, Combatant striker)
        {
            while (responder.CanFight && striker.CanFight)
            {
                if (ExchangeBlow(striker, responder))
                {
                    break;
                }

                _observer.StatusReported(responder);
                _pacer.Wait(BlowInterval);

                if (ExchangeBlow(responder, striker))
                {
                    break;
                }

                _observer.StatusReported(striker);
                _observer.RoundCompleted();
            }

            DuelOutcome outcome = Adjudicate(responder, striker);
            _journal.Info(outcome.IsDraw
                ? "Поединок завершён вничью."
                : "Поединок завершён, победитель: " + outcome.Winner.Name);

            return outcome;
        }

        private bool ExchangeBlow(Combatant attacker, Combatant target)
        {
            _observer.StrikeDelivered(attacker, target);

            target.Absorb(attacker.Strength);
            attacker.RecordLandedStrike();

            _journal.Debug(string.Format(
                "{0} -> {1}: force={2}, health={3}, armor={4}",
                attacker.Name, target.Name, attacker.Strength, target.Health, target.Armor));

            if (target.HasFallen)
            {
                _observer.CombatantFell(target);
            }

            return target.HasFallen;
        }

        private static DuelOutcome Adjudicate(Combatant left, Combatant right)
        {
            if (left.Health > right.Health)
            {
                return new DuelOutcome(left);
            }

            return left.Health < right.Health ? new DuelOutcome(right) : new DuelOutcome(null);
        }
    }
}
