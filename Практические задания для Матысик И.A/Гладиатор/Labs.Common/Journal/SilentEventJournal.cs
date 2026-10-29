using System;

namespace Labs.Common.Journal
{
    /// <summary>
    /// Реализация-пустышка (Null Object) для модульных тестов и сценариев без журналирования.
    /// </summary>
    public sealed class SilentEventJournal : IEventJournal
    {
        public void Debug(string message) { }

        public void Info(string message) { }

        public void Warn(string message) { }

        public void Error(string message, Exception cause = null) { }
    }
}
