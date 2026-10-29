namespace Labs.ArmorStrike.Domain
{
    /// <summary>
    /// Неизменяемый снимок состояния бойца. После удара здоровье и броня могут
    /// выйти в отрицательную область, поэтому инварианты неотрицательности здесь не навязываются.
    /// </summary>
    public sealed class Fighter
    {
        public Fighter(double health, double armor)
        {
            Health = health;
            Armor = armor;
        }

        public double Health { get; }

        public double Armor { get; }
    }
}
