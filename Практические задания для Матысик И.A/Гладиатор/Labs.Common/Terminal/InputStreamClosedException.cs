using System;

namespace Labs.Common.Terminal
{
    /// <summary>
    /// Поток стандартного ввода закрыт (достигнут конец ввода), дальнейший диалог невозможен.
    /// </summary>
    public sealed class InputStreamClosedException : InvalidOperationException
    {
        public InputStreamClosedException()
            : base("Поток ввода закрыт: получить ответ пользователя невозможно.")
        {
        }
    }
}
