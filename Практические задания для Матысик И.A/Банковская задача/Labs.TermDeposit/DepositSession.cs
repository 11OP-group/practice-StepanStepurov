using System;
using Labs.Common.Journal;
using Labs.Common.Terminal;
using Labs.TermDeposit.Accrual;
using Labs.TermDeposit.Domain;
using Labs.TermDeposit.Input;
using Labs.TermDeposit.Presentation;

namespace Labs.TermDeposit
{
    /// <summary>Сценарий приложения: ввод → расчёт → отображение → ожидание выхода.</summary>
    public sealed class DepositSession
    {
        private readonly DepositConsoleView _view;
        private readonly DepositRequestCollector _collector;
        private readonly MonthlyCapitalizationEngine _engine;
        private readonly IEventJournal _journal;

        public DepositSession(
            DepositConsoleView view,
            DepositRequestCollector collector,
            MonthlyCapitalizationEngine engine,
            IEventJournal journal)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _collector = collector ?? throw new ArgumentNullException(nameof(collector));
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public void Run()
        {
            _view.ApplyTheme();

            QuotedDeposit quote = _collector.Collect();
            AccrualSchedule schedule = _engine.Build(
                quote.Request.Principal, quote.AnnualRatePercent, quote.Request.TermInDays);

            _view.ShowRates(schedule);
            foreach (AccrualStep step in schedule.Steps)
            {
                _view.ShowStep(step);
            }

            _view.ShowClosing(schedule);
            _journal.Info("Расчёт завершён, итоговая сумма: " + schedule.ClosingBalance);

            ExitPrompt.AwaitEnter();
        }
    }
}
