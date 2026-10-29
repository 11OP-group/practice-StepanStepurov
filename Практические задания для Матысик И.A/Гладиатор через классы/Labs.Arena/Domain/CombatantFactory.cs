using System;
using Labs.Arena.Domain.Damage;
using Labs.Common.Randomness;

namespace Labs.Arena.Domain
{
    /// <summary>
    /// Фабрика бойцов: определяет силу удара как базовое значение плюс случайный разброс.
    /// </summary>
    public sealed class CombatantFactory
    {
        public const int BaseStrength = 50;
        public const int MinStrengthSpread = -5;
        public const int MaxStrengthSpreadExclusive = 15;

        private readonly IRandomSource _random;
        private readonly IDamageModel _damageModel;

        public CombatantFactory(IRandomSource random, IDamageModel damageModel)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _damageModel = damageModel ?? throw new ArgumentNullException(nameof(damageModel));
        }

        public Combatant Recruit(string name, double health, double armor)
        {
            int strength = BaseStrength + _random.NextInt(MinStrengthSpread, MaxStrengthSpreadExclusive);
            return new Combatant(name, health, armor, strength, _damageModel);
        }
    }
}
