using System;

namespace Labs.TermDeposit.Domain
{
    /// <summary>Введённый текст не удалось интерпретировать как число.</summary>
    public sealed class MalformedNumberException : Exception
    {
        public MalformedNumberException(string rawText, Exception cause)
            : base("Текст «" + rawText + "» не является корректным числом.", cause)
        {
            RawText = rawText;
        }

        public string RawText { get; }
    }
}
