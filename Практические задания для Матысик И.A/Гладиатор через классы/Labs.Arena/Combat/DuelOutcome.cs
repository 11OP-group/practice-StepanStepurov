using Labs.Arena.Domain;

namespace Labs.Arena.Combat
{
    /// <summary>Итог поединка: победитель либо ничья.</summary>
    public sealed class DuelOutcome
    {
        public DuelOutcome(Combatant winner)
        {
            Winner = winner;
        }

        /// <summary>Победитель; <c>null</c>, если здоровье бойцов совпало.</summary>
        public Combatant Winner { get; }

        public bool IsDraw => Winner == null;
    }
}
