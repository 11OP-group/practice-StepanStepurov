using System;

namespace Labs.TermDeposit.Domain
{
    /// <summary>Запрос клиента, дополненный годовой ставкой, применимой к выбранному сроку.</summary>
    public sealed class QuotedDeposit
    {
        public QuotedDeposit(DepositRequest request, double annualRatePercent)
        {
            Request = request ?? throw new ArgumentNullException(nameof(request));
            AnnualRatePercent = annualRatePercent;
        }

        public DepositRequest Request { get; }

        public double AnnualRatePercent { get; }
    }
}
