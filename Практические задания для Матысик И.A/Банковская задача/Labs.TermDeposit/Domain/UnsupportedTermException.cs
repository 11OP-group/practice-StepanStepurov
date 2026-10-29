using System;

namespace Labs.TermDeposit.Domain
{
    /// <summary>Для запрошенного срока в тарифной сетке банка нет продукта.</summary>
    public sealed class UnsupportedTermException : Exception
    {
        public UnsupportedTermException(int termInDays)
            : base("Тарифная сетка не содержит срока в " + termInDays + " дн.")
        {
            TermInDays = termInDays;
        }

        public int TermInDays { get; }
    }
}
