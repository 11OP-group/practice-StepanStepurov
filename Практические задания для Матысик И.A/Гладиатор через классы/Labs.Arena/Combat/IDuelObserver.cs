using Labs.Arena.Domain;

namespace Labs.Arena.Combat
{
    /// <summary>
    /// Наблюдатель хода поединка. Отделяет игровую механику от способа её отображения.
    /// </summary>
    public interface IDuelObserver
    {
        void StrikeDelivered(Combatant attacker, Combatant target);

        void CombatantFell(Combatant fallen);

        void StatusReported(Combatant combatant);

        void RoundCompleted();
    }
}
