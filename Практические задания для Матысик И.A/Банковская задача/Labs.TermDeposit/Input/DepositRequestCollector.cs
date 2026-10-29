using System;
using Labs.Common.Journal;
using Labs.Common.Terminal;
using Labs.TermDeposit.Domain;
using Labs.TermDeposit.Pricing;

namespace Labs.TermDeposit.Input
{
    /// <summary>
    /// Интерактивно собирает параметры вклада, повторяя диалог до получения
    /// корректных числовых значений и поддерживаемого срока.
    /// </summary>
    public sealed class DepositRequestCollector
    {
        private const int MoneyDigits = 2;

        private readonly ITerminalDialog _dialog;
        private readonly IRateCatalogue _catalogue;
        private readonly IEventJournal _journal;

        public DepositRequestCollector(ITerminalDialog dialog, IRateCatalogue catalogue, IEventJournal journal)
        {
            _dialog = dialog ?? throw new ArgumentNullException(nameof(dialog));
            _catalogue = catalogue ?? throw new ArgumentNullException(nameof(catalogue));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        public QuotedDeposit Collect()
        {
            while (true)
            {
                try
                {
                    DepositRequest request = ReadRequest();
                    double annualRate = _catalogue.ResolveAnnualRate(request.TermInDays);

                    _journal.Info(string.Format(
                        "Запрос принят: principal={0}, term={1}, annualRate={2}",
                        request.Principal, request.TermInDays, annualRate));

                    return new QuotedDeposit(request, annualRate);
                }
                catch (MalformedNumberException ex)
                {
                    _journal.Warn("Некорректное число во вводе: " + ex.RawText);
                    _dialog.Notify("Введены не числа!");
                }
                catch (UnsupportedTermException ex)
                {
                    _journal.Warn("Срок вне тарифной сетки: " + ex.TermInDays);
                    _dialog.Notify("Недопустимый срок вклада!");
                }
            }
        }

        private DepositRequest ReadRequest()
        {
            double principal = Math.Round(ParseDecimal(_dialog.Ask("Введите сумму вклада: ")), MoneyDigits);
            int term = ParseInteger(_dialog.Ask("Введите срок вклада: "));
            return new DepositRequest(principal, term);
        }

        private static double ParseDecimal(string text)
        {
            try
            {
                return Convert.ToDouble(text);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                throw new MalformedNumberException(text, ex);
            }
        }

        private static int ParseInteger(string text)
        {
            try
            {
                return Convert.ToInt32(text);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                throw new MalformedNumberException(text, ex);
            }
        }
    }
}
