using System;

namespace Labs.Arena.Input
{
    /// <summary>
    /// Разбирает строку «здоровье броня» (разделитель — пробел).
    /// Здоровье округляется до двух знаков, броня сохраняется как введена.
    /// </summary>
    public static class VitalsParser
    {
        private const char Separator = ' ';
        private const int HealthDigits = 2;

        /// <exception cref="MalformedVitalsException">Нет двух чисел либо числа записаны неверно.</exception>
        /// <exception cref="NegativeVitalsException">Одно из чисел отрицательно.</exception>
        public static FighterVitals Parse(string line)
        {
            string[] tokens = line.Split(Separator);

            double health = ParseToken(tokens, 0);
            if (health < 0)
            {
                throw new NegativeVitalsException();
            }

            double armor = ParseToken(tokens, 1);
            if (armor < 0)
            {
                throw new NegativeVitalsException();
            }

            return new FighterVitals(Math.Round(health, HealthDigits), armor);
        }

        private static double ParseToken(string[] tokens, int index)
        {
            if (index >= tokens.Length)
            {
                throw new MalformedVitalsException();
            }

            try
            {
                return double.Parse(tokens[index]);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                throw new MalformedVitalsException(ex);
            }
        }
    }
}
