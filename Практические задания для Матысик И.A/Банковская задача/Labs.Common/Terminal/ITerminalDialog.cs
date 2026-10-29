namespace Labs.Common.Terminal
{
    /// <summary>
    /// Минимальный диалоговый канал «вопрос — ответ» с пользователем.
    /// </summary>
    public interface ITerminalDialog
    {
        /// <summary>Выводит приглашение и возвращает введённую строку.</summary>
        /// <exception cref="InputStreamClosedException">Ввод закрыт.</exception>
        string Ask(string prompt);

        /// <summary>Выводит информационное сообщение или сообщение об ошибке ввода.</summary>
        void Notify(string message);
    }
}
