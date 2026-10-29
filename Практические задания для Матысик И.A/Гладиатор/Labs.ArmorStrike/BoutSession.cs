using System;
using Labs.ArmorStrike.Domain;
using Labs.ArmorStrike.Input;
using Labs.ArmorStrike.Presentation;
using Labs.ArmorStrike.Rules;
using Labs.Common.Terminal;

namespace Labs.ArmorStrike
{
    /// <summary>Сценарий приложения: ввод → единичный обмен ударами → вывод протокола.</summary>
    public sealed class BoutSession
    {
        private readonly FighterPairReader _reader;
        private readonly BoutEngine _engine;
        private readonly ConsoleBoutView _view;

        public BoutSession(FighterPairReader reader, BoutEngine engine, ConsoleBoutView view)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Run()
        {
            Tuple<Fighter, Fighter> pair = _reader.Read();
            BoutReport report = _engine.Run(pair.Item1, pair.Item2);

            _view.Show(report);
            ExitPrompt.AwaitEnter();
        }
    }
}
