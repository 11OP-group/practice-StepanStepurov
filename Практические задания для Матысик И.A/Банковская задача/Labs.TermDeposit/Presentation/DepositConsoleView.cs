using System;
using System.Globalization;
using System.Text;
using Labs.TermDeposit.Domain;

namespace Labs.TermDeposit.Presentation
{
    /// <summary>
    /// Консольное представление: цветовая схема, форматирование денежных сумм (ru-RU)
    /// и вывод результатов расчёта.
    /// </summary>
    public sealed class DepositConsoleView
    {
        private static readonly CultureInfo CurrencyCulture = new CultureInfo("ru-RU");

        public void ApplyTheme()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Банковская задача";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public void ShowRates(AccrualSchedule schedule)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ваш процент составляет {0}%", schedule.AnnualRatePercent);
            Console.WriteLine("Ставка в месяц: {0}%", schedule.PeriodRatePercent);
        }

        public void ShowStep(AccrualStep step)
        {
            Console.WriteLine(
                "{0}) Сумма на вкладе: {1} |{2}|",
                step.Ordinal, FormatMoney(step.Balance), FormatMoney(step.Interest));
        }

        public void ShowClosing(AccrualSchedule schedule)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "Итоговая сумма на вкладе: {0} |{1}|",
                FormatMoney(schedule.ClosingBalance), FormatMoney(schedule.TotalInterest));

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }

        private static string FormatMoney(double amount) => amount.ToString("C", CurrencyCulture);
    }
}
