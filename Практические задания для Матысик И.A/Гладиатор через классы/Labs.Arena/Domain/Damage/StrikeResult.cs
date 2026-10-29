namespace Labs.Arena.Domain.Damage
{
    /// <summary>Состояние цели после принятого удара.</summary>
    public readonly struct StrikeResult
    {
        public StrikeResult(double armor, double health, bool isFatal)
        {
            Armor = armor;
            Health = health;
            IsFatal = isFatal;
        }

        public double Armor { get; }

        public double Health { get; }

        /// <summary>Удар превысил запас здоровья цели.</summary>
        public bool IsFatal { get; }
    }
}
