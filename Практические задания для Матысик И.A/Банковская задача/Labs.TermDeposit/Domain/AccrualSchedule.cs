using System;
using System.Collections.Generic;

namespace Labs.TermDeposit.Domain
{
    /// <summary>Полный график капитализации вклада и его итоговые показатели.</summary>
    public sealed class AccrualSchedule
    {
        public AccrualSchedule(
            double annualRatePercent,
            double periodRatePercent,
            IReadOnlyList<AccrualStep> steps,
            double closingBalance,
            double totalInterest)
        {
            AnnualRatePercent = annualRatePercent;
            PeriodRatePercent = periodRatePercent;
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
            ClosingBalance = closingBalance;
            TotalInterest = totalInterest;
        }

        public double AnnualRatePercent { get; }

        /// <summary>Ставка за один расчётный период (месяц), округлённая до трёх знаков.</summary>
        public double PeriodRatePercent { get; }

        public IReadOnlyList<AccrualStep> Steps { get; }

        public double ClosingBalance { get; }

        /// <summary>Суммарные проценты за весь срок, округлённые до копеек.</summary>
        public double TotalInterest { get; }
    }
}
