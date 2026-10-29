using System;
using Labs.Common.Journal;
using Labs.Common.Terminal;
using Labs.TermDeposit.Accrual;
using Labs.TermDeposit.Input;
using Labs.TermDeposit.Pricing;
using Labs.TermDeposit.Presentation;

namespace Labs.TermDeposit
{
    /// <summary>Корень композиции приложения «Банковская задача».</summary>
    internal static class Program
    {
        private const int ExitOk = 0;
        private const int ExitInputClosed = 1;
        private const int ExitFailure = 2;

        private static int Main()
        {
            IEventJournal journal = new FileEventJournal("term-deposit");

            try
            {
                var session = new DepositSession(
                    new DepositConsoleView(),
                    new DepositRequestCollector(new SystemTerminalDialog(), new FixedRateCatalogue(), journal),
                    new MonthlyCapitalizationEngine(journal),
                    journal);

                session.Run();
                return ExitOk;
            }
            catch (InputStreamClosedException ex)
            {
                journal.Warn(ex.Message);
                return ExitInputClosed;
            }
            catch (Exception ex)
            {
                journal.Error("Необработанный сбой приложения.", ex);
                Console.Error.WriteLine("Произошла непредвиденная ошибка. Подробности записаны в журнал.");
                return ExitFailure;
            }
        }
    }
}
