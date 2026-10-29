namespace Labs.TermDeposit.Domain
{
    /// <summary>Результат одной капитализации (одного расчётного периода).</summary>
    public sealed class AccrualStep
    {
        public AccrualStep(int ordinal, double interest, double balance)
        {
            Ordinal = ordinal;
            Interest = interest;
            Balance = balance;
        }

        /// <summary>Порядковый номер периода, начиная с 1.</summary>
        public int Ordinal { get; }

        /// <summary>Начисленные за период проценты (без округления).</summary>
        public double Interest { get; }

        /// <summary>Остаток на вкладе после капитализации, округлённый до копеек.</summary>
        public double Balance { get; }
    }
}
