using System;
using Labs.ArmorStrike.Domain;

namespace Labs.ArmorStrike.Input
{
    /// <summary>
    /// Преобразует строку «здоровье броня» в <see cref="Fighter"/>.
    /// Здоровье округляется до двух знаков, броня сохраняется как введена.
    /// </summary>
    public static class FighterVitalsParser
    {
        private const char Separator = ' ';
        private const int HealthDigits = 2;

        public static Fighter Parse(string line)
        {
            string[] tokens = line.Split(Separator);

            double health = Math.Round(ParseToken(tokens, 0), HealthDigits);
            double armor = ParseToken(tokens, 1);

            if (health < 0 || armor < 0)
            {
                throw new NegativeVitalsException();
            }

            return new Fighter(health, armor);
        }

        private static double ParseToken(string[] tokens, int index)
        {
            if (index >= tokens.Length)
            {
                throw new NotNumericException();
            }

            try
            {
                return double.Parse(tokens[index]);
            }
            catch (FormatException ex)
            {
                throw new UnsupportedSeparatorException(ex);
            }
            catch (OverflowException ex)
            {
                throw new NotNumericException(ex);
            }
        }
    }
}
