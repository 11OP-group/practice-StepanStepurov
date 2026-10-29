using System;
using Labs.ArmorStrike.Input;
using Labs.ArmorStrike.Presentation;
using Labs.ArmorStrike.Rules;
using Labs.Common.Journal;
using Labs.Common.Randomness;
using Labs.Common.Terminal;

namespace Labs.ArmorStrike
{
    /// <summary>Корень композиции приложения «Гладиатор» (вариант с единичным обменом ударами).</summary>
    internal static class Program
    {
        private const int ExitOk = 0;
        private const int ExitInputClosed = 1;
        private const int ExitFailure = 2;

        private static int Main()
        {
            IEventJournal journal = new FileEventJournal("armor-strike");

            try
            {
                var session = new BoutSession(
                    new FighterPairReader(new SystemTerminalDialog(), journal),
                    new BoutEngine(
                        new ArmorBoundStrikeRoller(new SystemRandomSource()),
                        new ProportionalStrikeResolver(),
                        journal),
                    new ConsoleBoutView());

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
