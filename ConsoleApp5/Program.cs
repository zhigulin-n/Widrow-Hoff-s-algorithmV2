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
            int[,] mass = { {1, 0, 0 } , { 2, 0, 3 }, { 2, 2, -1 }, { 0, -1, 2 } };
            int[] mass_y = { 1, 2, 3, 2 };
            double[] mass_a = { 0.5, 0.071, 0.1, 0.166 };
            double[] mass_cnt = new double[4];

            double w1 = 1;
            double w2 = 1;
            double w3 = 1;
            double S = 1;
            double sum = 1;
            int cnt = 0;
            double schetch = 0;
            int number = 0;

            while(sum > 0.3)
            {
                Console.WriteLine($"Итерация {cnt + 1}");
                Console.WriteLine($"w1 = {w1}, w2 = {w2}, w3 = {w3}, S = {S}");
                cnt++;

                double y1 = Math.Round(w1 * mass[0, 0] + w2 * mass[0, 1] + w3 * mass[0, 2] - S, 5);
                Console.WriteLine($"y1 = {w1} * {mass[0, 0]} + {w2} * {mass[0, 1]} + {w2} * {mass[0, 2]} - {S} = {y1}");
                double E1 = Math.Round(0.5 * Math.Pow(y1 - mass_y[0], 2), 5);
                Console.WriteLine($"E1 = 0.5 * ({y1} - {mass_y[0]})^2 = {E1}");

                double y2 = Math.Round(w1 * mass[1, 0] + w2 * mass[1, 1] + w3 * mass[1, 2] - S, 5);
                Console.WriteLine($"y2 = {w1} * {mass[1, 0]} + {w2} * {mass[1, 1]} + {w2} * {mass[1, 2]} - {S} = {y1}");
                double E2 = Math.Round(0.5 * Math.Pow(y2 - mass_y[1], 2), 5);
                Console.WriteLine($"E2 = 0.5 * ({y2} - {mass_y[1]})^2 = {E2}");

                double y3 = Math.Round(w1 * mass[2, 0] + w2 * mass[2, 1] + w3 * mass[2, 2] - S, 5);
                Console.WriteLine($"y3 = {w1} * {mass[2, 0]} + {w2} * {mass[2, 1]} + {w2} * {mass[2, 2]} - {S} = {y1}");
                double E3 = Math.Round(0.5 * Math.Pow(y3 - mass_y[2], 2), 5);
                Console.WriteLine($"E3 = 0.5 * ({y3} - {mass_y[2]})^2 = {E3}");

                double y4 = Math.Round(w1 * mass[3, 0] + w2 * mass[3, 1] + w3 * mass[3, 2] - S, 5);
                Console.WriteLine($"y4 = {w1} * {mass[3, 0]} + {w2} * {mass[3, 1]} + {w2} * {mass[3, 2]} - {S} = {y1}");
                double E4 = Math.Round(0.5 * Math.Pow(y4 - mass_y[3], 2), 5);
                Console.WriteLine($"E4 = 0.5 * ({y4} - {mass_y[3]})^2 = {E4}");


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
                    S = Math.Round(S + mass_a[1] * (y2 - mass_y[1]), 5);
                } else if(number == 2)
                {
                    w1 = Math.Round(w1 - mass_a[2] * (y3 - mass_y[2]) * mass[2, 0], 5);
                    w2 = Math.Round(w2 - mass_a[2] * (y3 - mass_y[2]) * mass[2, 1], 5);
                    w3 = Math.Round(w3 - mass_a[2] * (y3 - mass_y[2]) * mass[2, 2], 5);
                    S = Math.Round(S + mass_a[2] * (y3 - mass_y[2]), 5);
                } else if(number == 3)
                {
                    w1 = Math.Round(w1 - mass_a[3] * (y4 - mass_y[3]) * mass[3, 0], 5);
                    w2 = Math.Round(w2 - mass_a[3] * (y4 - mass_y[3]) * mass[3, 1], 5);
                    w3 = Math.Round(w3 - mass_a[3] * (y4 - mass_y[3]) * mass[3, 2], 5);
                    S = Math.Round(S + mass_a[3] * (y4 - mass_y[3]), 5);
                }
                sum = Math.Round(E1 + E2 + E3 + E4, 5);
                number = 0;
                Console.WriteLine($"E = {E1} + {E2} + {E3} + {E4} = {sum}");
                Console.WriteLine();
            }
            Console.WriteLine($"Затраченное время: {time.Elapsed}");
        }
    }


}
