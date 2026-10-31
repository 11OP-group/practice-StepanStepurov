using System;
using System.Globalization;
using System.Text;

namespace Labs.TermDeposit
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo culture = new CultureInfo("ru-RU");
            double sum;
            int days;
            double annualRate;

            while (true)
            {
                try
                {
                    Console.Write("Введите сумму вклада: ");
                    sum = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                    Console.Write("Введите срок вклада: ");
                    days = Convert.ToInt32(Console.ReadLine());

                    if (days == 91) annualRate = 11.5;
                    else if (days == 181) annualRate = 11.75;
                    else if (days == 365) annualRate = 12.5;
                    else
                    {
                        Console.WriteLine("Недопустимый срок вклада!");
                        continue;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введены не числа! Повторите ввод.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введено слишком большое число. Повторите ввод.");
                }
            }

            double monthRate = Math.Round(annualRate / 12, 3);
            double totalInterest = 0;
            Console.WriteLine("\nВаш процент составляет {0}%", annualRate);
            Console.WriteLine("Ставка в месяц: {0}%", monthRate);

            for (int month = 1; month <= days / 30; month++)
            {
                double interest = sum * (monthRate / 100);
                sum = Math.Round(sum + interest, 2);
                totalInterest += interest;
                Console.WriteLine("{0}) Сумма на вкладе: {1} |{2}|", month,
                    sum.ToString("C", culture), interest.ToString("C", culture));
            }

            Console.WriteLine("Итоговая сумма на вкладе: {0} |{1}|", sum.ToString("C", culture),
                Math.Round(totalInterest, 2).ToString("C", culture));
            Console.Write("Нажмите <Enter> для выхода...");
            Console.ReadLine();
        }
    }
}
