using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Common.Journal;
using Labs.TermDeposit.Domain;

namespace Labs.TermDeposit.Accrual
{
    /// <summary>
    /// Рассчитывает график ежемесячной капитализации по схеме сложных процентов.
    /// Расчётный период принят равным 30 дням; неполный период в конце срока не начисляется.
    /// </summary>
    public sealed class MonthlyCapitalizationEngine
    {
        public const int DaysPerAccrualPeriod = 30;
        private const int PeriodsPerYear = 12;
        private const int RateDigits = 3;
        private const int MoneyDigits = 2;

        private readonly IEventJournal _journal;

        public MonthlyCapitalizationEngine(IEventJournal journal)
        {
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public AccrualSchedule Build(double principal, double annualRatePercent, int termInDays)
        {
            if (termInDays < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(termInDays), "Срок не может быть отрицательным.");
            }

            double periodRate = ResolvePeriodRate(annualRatePercent);
            int periods = termInDays / DaysPerAccrualPeriod;

            List<AccrualStep> ledger = Enumerable.Range(1, periods).Aggregate(
                new List<AccrualStep>(periods),
                (steps, ordinal) =>
                {
                    double opening = steps.Count == 0 ? principal : steps[steps.Count - 1].Balance;
                    double interest = opening * (periodRate / 100);
                    double closing = Math.Round(opening + interest, MoneyDigits);

                    steps.Add(new AccrualStep(ordinal, interest, closing));
                    return steps;
                });

            double closingBalance = ledger.Count == 0 ? principal : ledger[ledger.Count - 1].Balance;
            double totalInterest = Math.Round(ledger.Sum(step => step.Interest), MoneyDigits);

            _journal.Debug(string.Format(
                "График построен: periods={0}, periodRate={1}, closing={2}, interest={3}",
                periods, periodRate, closingBalance, totalInterest));

            return new AccrualSchedule(annualRatePercent, periodRate, ledger, closingBalance, totalInterest);
        }

        private static double ResolvePeriodRate(double annualRatePercent)
        {
            // Округление «к чётному» (поведение Math.Round по умолчанию) сохранено намеренно.
            return Math.Round(annualRatePercent / PeriodsPerYear, RateDigits);
        }
    }
}
