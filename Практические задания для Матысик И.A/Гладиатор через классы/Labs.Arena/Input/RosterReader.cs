using System;
using Labs.Common.Journal;
using Labs.Common.Terminal;

namespace Labs.Arena.Input
{
    /// <summary>
    /// Запрашивает показатели обоих бойцов; при любой ошибке повторяет диалог с самого начала.
    /// </summary>
    public sealed class RosterReader
    {
        private readonly ITerminalDialog _dialog;
        private readonly IEventJournal _journal;

        public RosterReader(ITerminalDialog dialog, IEventJournal journal)
        {
            _dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public VitalsPair ReadPair()
        {
            while (true)
            {
                try
                {
                    FighterVitals first = VitalsParser.Parse(
                        _dialog.Ask("Уровень здоровья и брони первого (через пробел): "));
                    FighterVitals second = VitalsParser.Parse(
                        _dialog.Ask("Уровень здоровья и брони второго (через пробел): "));

                    return new VitalsPair(first, second);
                }
                catch (VitalsInputException ex)
                {
                    _journal.Warn("Отклонён ввод показателей: " + ex.GetType().Name);
                    _dialog.Notify(ex.UserMessage);
                }
            }
        }
    }
}
