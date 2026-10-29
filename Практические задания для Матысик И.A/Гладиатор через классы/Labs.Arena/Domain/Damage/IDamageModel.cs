namespace Labs.Arena.Domain.Damage
{
    /// <summary>
    /// Стратегия расчёта последствий удара. Позволяет вводить новые правила боя
    /// без изменения класса <see cref="Combatant"/>.
    /// </summary>
    public interface IDamageModel
    {
        StrikeResult Resolve(double force, double armor, double health);
    }
}
