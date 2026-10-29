using System;
using Labs.ArmorStrike.Domain;

namespace Labs.ArmorStrike.Presentation
{
    /// <summary>Консольное отображение протокола поединка.</summary>
    public sealed class ConsoleBoutView
    {
        public void Show(BoutReport report)
        {
            Console.WriteLine();
            ShowStrike(report.FirstStrike);
            ShowStrike(report.SecondStrike);
            Console.WriteLine(DescribeVerdict(report.Verdict));
        }

        private static void ShowStrike(StrikeReport strike)
        {
            Console.WriteLine("Удар: {0}", strike.Attack);
            Console.WriteLine("Здоровье после удара у {0}: {1}", strike.Slot.Genitive, strike.After.Health);
            Console.WriteLine("Остаток брони {0}: {1}", strike.Slot.Genitive, strike.After.Armor);
        }

        private static string DescribeVerdict(Verdict verdict)
        {
            switch (verdict)
            {
                case Verdict.FirstHealthier:
                    return "Первый боец более здоровый! Он победил.";
                case Verdict.SecondHealthier:
                    return "Второй боец более здоровый! Он победил.";
                case Verdict.Tie:
                    return "Что-то случилось... Тут ничья!";
                default:
                    throw new ArgumentOutOfRangeException(nameof(verdict), verdict, "Неизвестный вердикт.");
            }
        }
    }
}
