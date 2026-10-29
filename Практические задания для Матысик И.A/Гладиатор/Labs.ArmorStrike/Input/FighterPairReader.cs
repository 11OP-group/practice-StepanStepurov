using System;
using Labs.ArmorStrike.Domain;
using Labs.Common.Journal;
using Labs.Common.Terminal;

namespace Labs.ArmorStrike.Input
{
    /// <summary>
    /// Запрашивает показатели двух бойцов; при любой ошибке диалог повторяется с начала.
    /// </summary>
    public sealed class FighterPairReader
    {
        private readonly ITerminalDialog _dialog;
        private readonly IEventJournal _journal;

        public FighterPairReader(ITerminalDialog dialog, IEventJournal journal)
        {
            _dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public Tuple<Fighter, Fighter> Read()
        {
            while (true)
            {
                try
                {
                    Fighter first = FighterVitalsParser.Parse(
                        _dialog.Ask("Введите уровень здоровья и брони первого (через пробел): "));
                    Fighter second = FighterVitalsParser.Parse(
                        _dialog.Ask("Введите уровень здоровья и брони второго (через пробел): "));

                    return Tuple.Create(first, second);
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
