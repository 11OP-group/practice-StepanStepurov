using System;

namespace Labs.Arena.Input
{
    /// <summary>Базовая ошибка ввода показателей; несёт сообщение, адресованное пользователю.</summary>
    public abstract class VitalsInputException : Exception
    {
        protected VitalsInputException(string userMessage, Exception cause = null)
            : base(userMessage, cause)
        {
            UserMessage = userMessage;
        }

        public string UserMessage { get; }
    }

    /// <summary>Строка не содержит двух корректных чисел.</summary>
    public sealed class MalformedVitalsException : VitalsInputException
    {
        public MalformedVitalsException(Exception cause = null)
            : base("Неправильный формат ввода!", cause)
        {
        }
    }

    /// <summary>Одно из чисел отрицательно.</summary>
    public sealed class NegativeVitalsException : VitalsInputException
    {
        public NegativeVitalsException()
            : base("Числа не могут быть отрицательными!")
        {
        }
    }
}
