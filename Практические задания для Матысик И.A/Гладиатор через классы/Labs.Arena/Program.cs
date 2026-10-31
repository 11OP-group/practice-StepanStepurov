using System;
using System.Text;
using System.Threading;

namespace Labs.Arena
{
    // Класс хранит характеристики гладиатора и изменяет их после удара.
    public class Gladiator
    {
        public string Name { get; private set; }
        public double Health { get; private set; }
        public double Armor { get; private set; }
        public int Strength { get; private set; }
        public int Hits { get; private set; }
        public bool IsDead { get { return Health <= 0; } }

        public Gladiator(string name, double health, double armor, Random random)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Strength = 50 + random.Next(-5, 15);
        }

        public void TakeDamage(int force)
        {
            double armorDamage = force * 0.25;
            Armor = Armor - armorDamage >= 0 ? Math.Round(Armor - armorDamage, 1) : 0;
            double healthDamage = force - Armor;
            if (Health - healthDamage >= 0)
                Health = Math.Round(Health - healthDamage, 1);
            else
                Health = 0;
            if (IsDead) Console.WriteLine(Name + " погиб!");
        }

        public void RecordHit() { Hits++; }
    }

    internal class Program
    {
        private static void ShowTitle(string text)
        {
            Console.WriteLine(new string('—', 60));
            Console.WriteLine(text.PadLeft((60 + text.Length) / 2));
            Console.WriteLine(new string('—', 60));
        }

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            double h1, a1, h2, a2;
            while (true)
            {
                try
                {
                    Console.Write("Уровень здоровья и брони первого бойца (через пробел): ");
                    string[] first = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    h1 = double.Parse(first[0]); a1 = double.Parse(first[1]);
                    Console.Write("Уровень здоровья и брони второго бойца (через пробел): ");
                    string[] second = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    h2 = double.Parse(second[0]); a2 = double.Parse(second[1]);
                    if (h1 < 0 || a1 < 0 || h2 < 0 || a2 < 0)
                    {
                        Console.WriteLine("Числа не могут быть отрицательными!");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильный формат ввода!");
                }
            }

            Random random = new Random();
            Gladiator david = new Gladiator("Давид", h1, a1, random);
            Gladiator goliath = new Gladiator("Голиаф", h2, a2, random);
            ShowTitle("ВЫХОД БОЙЦОВ");
            Console.WriteLine("Гладиатор {0} имеет {1} силы...", david.Name, david.Strength);
            Console.WriteLine("Гладиатор {0} имеет {1} силы...", goliath.Name, goliath.Strength);
            ShowTitle("БОЙ НАЧИНАЕТСЯ!");
            Thread.Sleep(1000);

            // Второй гладиатор начинает бой, затем бойцы атакуют по очереди.
            while (!david.IsDead && !goliath.IsDead)
            {
                david.TakeDamage(goliath.Strength);
                goliath.RecordHit();
                if (david.IsDead) break;
                Console.WriteLine("У {0} осталось {1} HP и {2} брони", david.Name, david.Health, david.Armor);
                Thread.Sleep(1000);

                goliath.TakeDamage(david.Strength);
                david.RecordHit();
                if (goliath.IsDead) break;
                Console.WriteLine("У {0} осталось {1} HP и {2} брони", goliath.Name, goliath.Health, goliath.Armor);
                Console.WriteLine(new string('—', 60));
            }

            Thread.Sleep(1500);
            if (david.Health > goliath.Health)
                Console.WriteLine("Победил {0}, нанеся {1} ударов!", david.Name, david.Hits);
            else if (david.Health < goliath.Health)
                Console.WriteLine("Победил {0}, нанеся {1} ударов!", goliath.Name, goliath.Hits);
            else Console.WriteLine("У нас ничья!");

            Console.Write("Нажмите <Enter> для выхода...");
            Console.ReadLine();
        }
    }
}
