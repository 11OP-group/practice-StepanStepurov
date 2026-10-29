using System;

namespace Labs.ArmorStrike.Input
{
    /// <summary>Базовая ошибка ввода; несёт сообщение, адресованное пользователю.</summary>
    public abstract class VitalsInputException : Exception
    {
        protected VitalsInputException(string userMessage, Exception cause = null)
            : base(userMessage, cause)
        {
            UserMessage = userMessage;
        }

        public string UserMessage { get; }
    }

    /// <summary>Токен не является числом в текущей культуре (в том числе из-за неверного разделителя).</summary>
    public sealed class UnsupportedSeparatorException : VitalsInputException
    {
        public UnsupportedSeparatorException(Exception cause)
            : base("Введён не тот разделитель!", cause)
        {
        }
    }

    /// <summary>Ожидаемое число отсутствует или выходит за допустимый диапазон.</summary>
    public sealed class NotNumericException : VitalsInputException
    {
        public NotNumericException(Exception cause = null)
            : base("Введены не числа!", cause)
        {
        }
    }

    /// <summary>Здоровье или броня отрицательны.</summary>
    public sealed class NegativeVitalsException : VitalsInputException
    {
        public NegativeVitalsException()
            : base("Числа не могут быть отрицательными!")
        {
        }
    }
}
