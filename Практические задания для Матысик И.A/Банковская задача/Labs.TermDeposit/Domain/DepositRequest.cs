namespace Labs.TermDeposit.Domain
{
    /// <summary>Неизменяемое описание запроса клиента на открытие вклада.</summary>
    public sealed class DepositRequest
    {
        public DepositRequest(double principal, int termInDays)
        {
            Principal = principal;
            TermInDays = termInDays;
        }

        /// <summary>Сумма первоначального взноса.</summary>
        public double Principal { get; }

        /// <summary>Срок размещения в днях.</summary>
        public int TermInDays { get; }
    }
}
