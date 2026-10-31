using System;
using System.Text;

namespace Labs.ArmorStrike
{
    internal class Program
    {
        private static double RandomAttack(Random random, double armor)
        {
            return Math.Round(random.NextDouble() * armor, 2);
        }

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            double health1, armor1, health2, armor2;
            while (true)
            {
                try
                {
                    Console.Write("Введите здоровье и броню первого бойца (через пробел): ");
                    string[] first = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    health1 = double.Parse(first[0]);
                    armor1 = double.Parse(first[1]);
                    Console.Write("Введите здоровье и броню второго бойца (через пробел): ");
                    string[] second = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    health2 = double.Parse(second[0]);
                    armor2 = double.Parse(second[1]);
                    if (health1 < 0 || armor1 < 0 || health2 < 0 || armor2 < 0)
                    {
                        Console.WriteLine("Числа не могут быть отрицательными!");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильный формат ввода! Повторите ввод.");
                }
            }

            Random random = new Random();
            Console.WriteLine();
            double attack = RandomAttack(random, armor1);
            Console.WriteLine("Удар по первому: {0}", attack);
            health1 = Math.Round(health1 - attack * (armor1 / 100.0), 2);
            armor1 -= attack;
            Console.WriteLine("Здоровье после удара у первого: {0}", health1);
            Console.WriteLine("Остаток брони первого: {0}", armor1);

            attack = RandomAttack(random, armor2);
            Console.WriteLine("Удар по второму: {0}", attack);
            health2 = Math.Round(health2 - attack * (armor2 / 100.0), 2);
            armor2 -= attack;
            Console.WriteLine("Здоровье после удара у второго: {0}", health2);
            Console.WriteLine("Остаток брони второго: {0}", armor2);

            if (health1 > health2) Console.WriteLine("Первый боец более здоровый! Он победил.");
            else if (health1 < health2) Console.WriteLine("Второй боец более здоровый! Он победил.");
            else Console.WriteLine("Что-то случилось... Тут ничья!");

            Console.Write("Нажмите <Enter> для выхода...");
            Console.ReadLine();
        }
    }
}
