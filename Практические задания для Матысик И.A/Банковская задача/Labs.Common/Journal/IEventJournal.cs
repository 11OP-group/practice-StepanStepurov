using System;

namespace Labs.Common.Journal
{
    /// <summary>
    /// Контракт диагностического журнала приложения. Журнал предназначен для
    /// технической телеметрии и не смешивается с пользовательским выводом.
    /// </summary>
    public interface IEventJournal
    {
        void Debug(string message);

        void Info(string message);

        void Warn(string message);

        void Error(string message, Exception cause = null);
    }
}
