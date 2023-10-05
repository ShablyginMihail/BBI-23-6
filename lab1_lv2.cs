using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static int fact(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; ++i)
            {
                f *= i;
            }
            return f;
        }


        static void Main(string[] args)
        {
            #region 1            double x = 0.5;
            double epsilon = 0.0001;
            double sum = 0;
            double term = 1;
            double n = 1;

            while (Math.Abs(term) >= epsilon)
            {
            sum += term;
            n++;
            term = Math.Cos(n * x) / (n * n);
            }

            Console.WriteLine("Сумма ряда: " + sum);
            #endregion
            #region 2            int L = 30000;
            int n = 1;
            int p = 1;

            while (p <= L)
            {
                n++;
                p *= n;
            }
            n--;
            Console.WriteLine("Наибольшее значение n: " + n)
            #endregion
            #region 3            int s = 0, n = 0, m;
            const int a = 2, h = 3, p = 41;
            while (s <= p)
            {
                m = a + n * h;
                s = s + m;
                n = n + 1;
            }
            n--;
            Console.WriteLine($"{n:d}");
            #endregion
            #region 4
            double sum = 0;
            double x = Double.Parse(Console.ReadLine());
            double pow = 1;
            while (true)
            {
                sum += pow;
                pow *= x * x;
                if (pow <= 0.0001)
                {
                    break;
                }
            }
            Console.WriteLine(sum);
            #endregion
            #region 5            double res = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());

            while (n >= m)
            {
                res += 1;
                n -= m;
            }
            Console.WriteLine($"частное: {res}");
            if (n < m)
            {
                if (n > 0)
                {
                    Console.WriteLine($"остаток:{n}");
                }
                if (n == 0)
                {
                    Console.WriteLine("остаток: 0");
                }
            #endregion
            #region 6            int n = 1;
            int time = 0;

            while (n != 105)
            {
                time++;


                n += n;


                if (n > 105)
                {
                    n = 105;
                }
            }

            Console.WriteLine("Время: " + time);
            Console.ReadKey();
            #endregion
            #region 7            double r = 10;
            double sum = 10;
            int kolvo = 1;
            for (kolvo = 1; sum < 100;)
            {
                r = r + r * 0.1;
                sum += r;
                kolvo += 1;
            }
            Console.WriteLine(kolvo);
            #endregion
            #region 8             double s = 10000;
            int d = 0;
            double r = 0.08;
            double s1 = s * 2;
            while (s < s1)
            {
                s += s * r;
                d++;
            }
            Console.WriteLine($"Сумма удвоится через {d} месяцев.");
            #endregion
