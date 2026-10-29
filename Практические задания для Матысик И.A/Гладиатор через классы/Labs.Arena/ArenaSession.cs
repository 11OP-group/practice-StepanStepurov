using System;
using Labs.Arena.Combat;
using Labs.Arena.Domain;
using Labs.Arena.Input;
using Labs.Arena.Presentation;
using Labs.Common.Journal;
using Labs.Common.Terminal;
using Labs.Common.Timing;

namespace Labs.Arena
{
    /// <summary>Сценарий приложения: набор бойцов → поединок → объявление итога.</summary>
    public sealed class ArenaSession
    {
        private const string ResponderName = "Давид";
        private const string StrikerName = "Голиаф";

        private static readonly TimeSpan OpeningPause = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan ClosingPause = TimeSpan.FromMilliseconds(1500);

        private readonly RosterReader _reader;
        private readonly CombatantFactory _factory;
        private readonly DuelEngine _engine;
        private readonly ConsoleDuelView _view;
        private readonly IPacer _pacer;
        private readonly IEventJournal _journal;

        public ArenaSession(
            RosterReader reader,
            CombatantFactory factory,
            DuelEngine engine,
            ConsoleDuelView view,
            IPacer pacer,
            IEventJournal journal)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _pacer = pacer ?? throw new ArgumentNullException(nameof(pacer));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public void Run()
        {
            _view.ShowBanner("ВЫХОД БОЙЦОВ");

            VitalsPair vitals = _reader.ReadPair();
            Combatant responder = _factory.Recruit(ResponderName, vitals.First.Health, vitals.First.Armor);
            Combatant striker = _factory.Recruit(StrikerName, vitals.Second.Health, vitals.Second.Armor);

            _view.AssignTint(responder, AnsiPalette.Green);
            _view.AssignTint(striker, AnsiPalette.Red);
            _view.AnnounceStrength(responder);
            _view.AnnounceStrength(striker);

            _journal.Info(string.Format(
                "Бойцы созданы: {0} (strength={1}), {2} (strength={3})",
                responder.Name, responder.Strength, striker.Name, striker.Strength));

            _view.ShowBanner("БОЙ НАЧИНАЕТСЯ!");
            _pacer.Wait(OpeningPause);

            DuelOutcome outcome = _engine.Run(responder, striker);

            _pacer.Wait(ClosingPause);
            _view.AnnounceOutcome(outcome);

            ExitPrompt.AwaitEnter();
        }
    }
}
