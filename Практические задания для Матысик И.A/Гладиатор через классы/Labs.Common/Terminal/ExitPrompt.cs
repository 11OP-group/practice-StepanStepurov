using System;

namespace Labs.Common.Terminal
{
    /// <summary>
    /// Удерживает окно консоли до подтверждения пользователем клавишей Enter.
    /// </summary>
    public static class ExitPrompt
    {
        public const string DefaultMessage = "Нажмите <Enter> для выхода...";

        public static void AwaitEnter(string message = DefaultMessage)
        {
            Console.Write(message);

            if (Console.IsInputRedirected)
            {
                return;
            }

            ConsoleKey pressed;
            do
            {
                pressed = Console.ReadKey(true).Key;
            }
            while (pressed != ConsoleKey.Enter);
        }
    }
}
