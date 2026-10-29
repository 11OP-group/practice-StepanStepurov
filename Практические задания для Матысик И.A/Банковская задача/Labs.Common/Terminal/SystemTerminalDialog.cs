using System;

namespace Labs.Common.Terminal
{
    /// <summary>
    /// Реализация <see cref="ITerminalDialog"/> поверх <see cref="Console"/>.
    /// </summary>
    public sealed class SystemTerminalDialog : ITerminalDialog
    {
        public string Ask(string prompt)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine();

            if (answer == null)
            {
                throw new InputStreamClosedException();
            }

            return answer;
        }

        public void Notify(string message) => Console.WriteLine(message);
    }
}
