using System;

namespace Labs.ArmorStrike.Domain
{
    /// <summary>Протокол одного удара: сила, позиция цели и её состояние после удара.</summary>
    public sealed class StrikeReport
    {
        public StrikeReport(FighterSlot slot, double attack, Fighter after)
        {
            Slot = slot ?? throw new ArgumentNullException(nameof(slot));
            Attack = attack;
            After = after ?? throw new ArgumentNullException(nameof(after));
        }

        public FighterSlot Slot { get; }

        public double Attack { get; }

        public Fighter After { get; }
    }
}
