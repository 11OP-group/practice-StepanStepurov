namespace Labs.Arena.Input
{
    /// <summary>Введённые пользователем здоровье и броня одного бойца.</summary>
    public sealed class FighterVitals
    {
        public FighterVitals(double health, double armor)
        {
            Health = health;
            Armor = armor;
        }

        public double Health { get; }

        public double Armor { get; }
    }
}
