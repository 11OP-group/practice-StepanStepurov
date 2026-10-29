using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Labs.Common.Journal
{
    /// <summary>
    /// Потокобезопасный журнал с записью в суточный файл <c>logs/{channel}-{yyyyMMdd}.log</c>.
    /// Сбои файловой системы поглощаются: отказ журналирования не должен ронять приложение.
    /// </summary>
    public sealed class FileEventJournal : IEventJournal
    {
        private readonly object _gate = new object();
        private readonly string _channel;
        private readonly string _targetPath;

        /// <param name="channel">Имя канала (попадает в имя файла и в каждую запись).</param>
        /// <param name="directory">Каталог журналов; по умолчанию — <c>logs</c> рядом с исполняемым файлом.</param>
        public FileEventJournal(string channel, string directory = null)
        {
            if (string.IsNullOrWhiteSpace(channel))
            {
                throw new ArgumentException("Имя канала журнала не может быть пустым.", nameof(channel));
            }

            _channel = channel;
            string root = directory ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            _targetPath = Path.Combine(root, string.Format(CultureInfo.InvariantCulture, "{0}-{1:yyyyMMdd}.log", channel, DateTime.Now));
        }

        public void Debug(string message) => Append("DEBUG", message, null);

        public void Info(string message) => Append("INFO", message, null);

        public void Warn(string message) => Append("WARN", message, null);

        public void Error(string message, Exception cause = null) => Append("ERROR", message, cause);

        private void Append(string level, string message, Exception cause)
        {
            string record = string.Format(
                CultureInfo.InvariantCulture,
                "{0:yyyy-MM-dd HH:mm:ss.fff} [{1,-5}] [{2}] {3}",
                DateTime.Now, level, _channel, message);

            if (cause != null)
            {
                record += Environment.NewLine + cause;
            }

            try
            {
                lock (_gate)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_targetPath));
                    File.AppendAllText(_targetPath, record + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch (IOException)
            {
                // Намеренно подавляется: см. описание типа.
            }
            catch (UnauthorizedAccessException)
            {
                // Намеренно подавляется: см. описание типа.
            }
        }
    }
}
