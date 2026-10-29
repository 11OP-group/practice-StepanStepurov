using System;
using System.Collections.Generic;
using Labs.Arena.Combat;
using Labs.Arena.Domain;

namespace Labs.Arena.Presentation
{
    /// <summary>Консольное представление поединка и наблюдатель его событий.</summary>
    public sealed class ConsoleDuelView : IDuelObserver
    {
        private const int FrameWidth = 60;
        private const char FrameGlyph = '—';

        private readonly Dictionary<Combatant, string> _tints = new Dictionary<Combatant, string>();

        public void AssignTint(Combatant combatant, string ansiTint) => _tints[combatant] = ansiTint;

        public void ShowBanner(string text)
        {
            string rule = new string(FrameGlyph, FrameWidth);
            int leftPadding = (FrameWidth - text.Length) / 2;

            Console.WriteLine(rule);
            Console.WriteLine(text.PadLeft(leftPadding + text.Length));
            Console.WriteLine(rule);
        }

        public void AnnounceStrength(Combatant combatant)
        {
            Console.WriteLine($"Гладиатор {Tinted(combatant, combatant.Name)} имеет {combatant.Strength} силы...");
        }

        public void StrikeDelivered(Combatant attacker, Combatant target)
        {
            Console.WriteLine($"{attacker.Name} наносит удар...");
        }

        public void CombatantFell(Combatant fallen)
        {
            Console.WriteLine($"{fallen.Name} погиб!");
        }

        public void StatusReported(Combatant combatant)
        {
            Console.WriteLine(
                $"У {Tinted(combatant, GenitiveOf(combatant.Name))} осталось {combatant.Health}HP и {combatant.Armor} брони");
        }

        public void RoundCompleted()
        {
            Console.WriteLine(new string(FrameGlyph, FrameWidth));
        }

        public void AnnounceOutcome(DuelOutcome outcome)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (outcome.IsDraw)
            {
                Console.WriteLine("У нас ничья!");
            }
            else
            {
                Console.WriteLine($"Победил {outcome.Winner.Name}, нанеся {outcome.Winner.StrikesLanded} ударов!");
            }

            Console.ResetColor();
        }

        private string Tinted(Combatant combatant, string text)
        {
            string tint;
            return _tints.TryGetValue(combatant, out tint) ? tint + text + AnsiPalette.Reset : text;
        }

        // Упрощённое образование родительного падежа, достаточное для имён «Давид» и «Голиаф».
        private static string GenitiveOf(string name) => name + "а";
    }
}
