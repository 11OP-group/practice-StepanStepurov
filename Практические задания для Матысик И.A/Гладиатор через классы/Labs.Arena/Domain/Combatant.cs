using System;
using Labs.Arena.Domain.Damage;

namespace Labs.Arena.Domain
{
    /// <summary>
    /// Агрегат бойца: хранит состояние и делегирует расчёт повреждений стратегии <see cref="IDamageModel"/>.
    /// Изменение состояния возможно только через методы агрегата.
    /// </summary>
    public sealed class Combatant
    {
        private readonly IDamageModel _damageModel;

        public Combatant(string name, double health, double armor, int strength, IDamageModel damageModel)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя бойца не может быть пустым.", nameof(name));
            }

            if (health < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(health), "Здоровье не может быть отрицательным.");
            }

            if (armor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(armor), "Броня не может быть отрицательной.");
            }

            Name = name;
            Health = health;
            Armor = armor;
            Strength = strength;
            _damageModel = damageModel ?? throw new ArgumentNullException(nameof(damageModel));
        }

        public string Name { get; }

        public double Health { get; private set; }

        public double Armor { get; private set; }

        public int Strength { get; }

        public int StrikesLanded { get; private set; }

        /// <summary>Боец погиб от удара, превысившего остаток здоровья.</summary>
        public bool HasFallen { get; private set; }

        public bool CanFight => Health > 0;

        /// <summary>Принимает удар заданной силы и обновляет состояние бойца.</summary>
        public StrikeResult Absorb(double force)
        {
            StrikeResult result = _damageModel.Resolve(force, Armor, Health);

            Armor = result.Armor;
            Health = result.Health;
            HasFallen = HasFallen || result.IsFatal;

            return result;
        }

        public void RecordLandedStrike() => StrikesLanded++;
    }
}
