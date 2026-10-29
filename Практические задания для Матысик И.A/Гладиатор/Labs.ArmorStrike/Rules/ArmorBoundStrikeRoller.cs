using System;
using Labs.Common.Randomness;

namespace Labs.ArmorStrike.Rules
{
    /// <summary>
    /// Сила удара — случайное значение от нуля до величины брони цели,
    /// округлённое до двух знаков.
    /// </summary>
    public sealed class ArmorBoundStrikeRoller : IStrikeRoller
    {
        private const double Floor = 0;
        private const int AttackDigits = 2;

        private readonly IRandomSource _random;

        public ArmorBoundStrikeRoller(IRandomSource random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public double Roll(double armor)
        {
            double unit = _random.NextUnit();
            double scaled = unit * (armor - Floor);
            return Math.Round(scaled + Floor, AttackDigits);
        }
    }
}
