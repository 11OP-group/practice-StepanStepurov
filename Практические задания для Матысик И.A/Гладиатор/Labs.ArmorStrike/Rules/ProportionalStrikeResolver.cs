using System;
using Labs.ArmorStrike.Domain;

namespace Labs.ArmorStrike.Rules
{
    /// <summary>
    /// Применяет удар: урон по здоровью пропорционален броне (процент от силы удара,
    /// равный значению брони), а сама броня уменьшается на полную силу удара.
    /// </summary>
    public sealed class ProportionalStrikeResolver
    {
        private const double ArmorPercentBase = 100.0;
        private const int HealthDigits = 2;

        public Fighter Apply(Fighter target, double attack)
        {
            double healthLoss = attack * (target.Armor / ArmorPercentBase);
            double health = Math.Round(target.Health - healthLoss, HealthDigits);
            double armor = target.Armor - attack;

            return new Fighter(health, armor);
        }
    }
}
