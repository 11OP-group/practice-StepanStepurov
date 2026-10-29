using System;
using Labs.Arena.Combat;
using Labs.Arena.Domain;
using Labs.Arena.Domain.Damage;
using Labs.Arena.Input;
using Labs.Arena.Presentation;
using Labs.Common.Journal;
using Labs.Common.Randomness;
using Labs.Common.Terminal;
using Labs.Common.Timing;

namespace Labs.Arena
{
    /// <summary>Корень композиции приложения «Гладиатор» (вариант с классами).</summary>
    internal static class Program
    {
        private const int ExitOk = 0;
        private const int ExitInputClosed = 1;
        private const int ExitFailure = 2;

        private static int Main()
        {
            IEventJournal journal = new FileEventJournal("arena");

            try
            {
                var pacer = new ThreadPacer();
                var view = new ConsoleDuelView();

                var session = new ArenaSession(
                    new RosterReader(new SystemTerminalDialog(), journal),
                    new CombatantFactory(new SystemRandomSource(), new ArmorAbsorptionDamageModel()),
                    new DuelEngine(view, pacer, journal),
                    view,
                    pacer,
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
