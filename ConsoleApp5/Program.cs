using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            int[,] mass = { {1, 1, 2 } , { 2, 1, 0 }, { 2, 0, 1 }, { 0, 2, 3 } };
            int[] mass_y = { 1, 2, 3, 2 };
            double[] mass_a = { 0.142, 0.166, 0.166, 0.07 };
            double[] mass_cnt = new double[4];

            double w1 = 1;
            double w2 = 1;
            double w3 = 1;
            double S = 1;
            double sum = 1;
            int cnt = 0;
            double schetch = 0;
            int number = 0;

            while(sum > 0.4)
            {
                Console.WriteLine($"Итерация {cnt + 1}");
                Console.WriteLine($"w1 = {w1}, w2 = {w2}, w3 = {w3}, S = {S}");
                cnt++;
                double y1 = Math.Round(w1 * mass[0, 0] + w2 * mass[0, 1] + w3 * mass[0, 2] - S, 5);
                double y2 = Math.Round(w1 * mass[1, 0] + w2 * mass[1, 1] + w3 * mass[1, 2] - S, 5);
                double y3 = Math.Round(w1 * mass[2, 0] + w2 * mass[2, 1] + w3 * mass[2, 2] - S, 5);
                double y4 = Math.Round(w1 * mass[3, 0] + w2 * mass[3, 1] + w3 * mass[3, 2] - S, 5);
                Console.WriteLine($"y1 = {y1}, y2 = {y2}, y3 = {y3}, y4 = {y4}");

                double E1 = Math.Round(0.5 * Math.Pow(y1 - mass_y[0], 2), 5);
                double E2 = Math.Round(0.5 * Math.Pow(y2 - mass_y[1], 2), 5);
                double E3 = Math.Round(0.5 * Math.Pow(y3 - mass_y[2], 2), 5);
                double E4 = Math.Round(0.5 * Math.Pow(y4 - mass_y[3], 2), 5);
                Console.WriteLine($"e1 = {E1}, e2 = {E2}, e3 = {E3}, e4 = {E4}");

                mass_cnt[0] = E1;
                mass_cnt[1] = E2;
                mass_cnt[2] = E3;
                mass_cnt[3] = E4;

                for (int i = 0; i < mass_cnt.Length; i++)
                {
                    if (mass_cnt[i] >= schetch)
                    {
                        schetch = mass_cnt[i];
                        number = i;
                    }
                }
                Console.WriteLine($"Max E = {schetch}");
                schetch = 0;

                if (number == 0)
                {
                    w1 = Math.Round(w1 - mass_a[0] * (y1 - mass_y[0]) * mass[0, 0], 5);
                    w2 = Math.Round(w2 - mass_a[0] * (y1 - mass_y[0]) * mass[0, 1], 5);
                    w3 = Math.Round(w3 - mass_a[0] * (y1 - mass_y[0]) * mass[0, 2], 5);
                    S = Math.Round(S + mass_a[0] * (y1 - mass_y[0]), 5);
                } else if(number == 1)
                {
                    w1 = Math.Round(w1 - mass_a[1] * (y2 - mass_y[1]) * mass[1, 0], 5);
                    w2 = Math.Round(w2 - mass_a[1] * (y2 - mass_y[1]) * mass[1, 1], 5);
                    w3 = Math.Round(w3 - mass_a[1] * (y2 - mass_y[1]) * mass[1, 2], 5);
                    S = Math.Round(S + mass_a[1] * (y1 - mass_y[0]), 5);
                } else if(number == 2)
                {
                    w1 = Math.Round(w1 - mass_a[2] * (y3 - mass_y[2]) * mass[2, 0], 5);
                    w2 = Math.Round(w2 - mass_a[2] * (y3 - mass_y[2]) * mass[2, 1], 5);
                    w3 = Math.Round(w3 - mass_a[2] * (y3 - mass_y[2]) * mass[2, 2], 5);
                    S = Math.Round(S + mass_a[2] * (y1 - mass_y[0]), 5);
                } else if(number == 3)
                {
                    w1 = Math.Round(w1 - mass_a[3] * (y4 - mass_y[3]) * mass[3, 0], 5);
                    w2 = Math.Round(w2 - mass_a[3] * (y4 - mass_y[3]) * mass[3, 1], 5);
                    w3 = Math.Round(w3 - mass_a[3] * (y4 - mass_y[3]) * mass[3, 2], 5);
                    S = Math.Round(S + mass_a[3] * (y1 - mass_y[0]), 5);
                }
                sum = Math.Round(E1 + E2 + E3 + E4, 5);
                Console.WriteLine($"Сумма Е = {sum}");
                Console.WriteLine();
            }
            Console.WriteLine($"Затраченное время: {time.Elapsed}");
        }

        



    }


}
