using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
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
            #region 1
            int s = 0;
            for (int i = 2; i <= 35; i += 3)
            {
                s += i;
            }
            Console.WriteLine(s);
            #endregion

            #region 2
            double s2 = 0;
            for (int i = 1; i <= 10; i++)
            {
                s2 += 1 / i;
            }
            Console.WriteLine(s2);
            #endregion

            #region 3
            double s3 = 0;
            for (int i = 2; i <= 112; i += 2)
            {
                s3 += i / (i + 1);
            }
            Console.WriteLine(s3);
            #endregion

            #region 4
            double s4 = 0;
            int x = Int32.Parse(Console.ReadLine());
            for (int i = 1; i <= 9; i++)
            {
                s4 += Math.Cos(x * i) / Math.Pow(x, i - 1);
            }
            Console.WriteLine(s4);
            #endregion

            #region 5
            double s5 = 0;
            int p = Int32.Parse(Console.ReadLine()), h = Int32.Parse(Console.ReadLine());
            for (int i = 0; i <= 9; i++)
            {
                s5 += Math.Pow((p + h * i), 2);
            }
            Console.WriteLine(s5);
            #endregion

            #region 6
            double y;
            Console.WriteLine("x   y");
            for (double x2 = -4; x2 <= 4; x2 += 0.5)
            {
                y = 0.5 * x2 * x2 - 7 * x2;
                Console.WriteLine($"{x}   {y}");
            }
            #endregion


            #region 7
            double s6 = 1;
            for (int z = 1; z <= 6; z++)
            {
                s6 *= z;
            }
            Console.WriteLine(s6);
            #endregion


            #region 8
            double s7 = 0;
            int n = 1;
            for (int i = 1; i <= 6; i++)
            {
                s7 += fact(i);
            }
            Console.WriteLine(s7);
            #endregion


            #region 9
            double s8 = 0;
            for (int i = 1; i <= 6; i++)
            {
                s8 += (Math.Pow(-1, i) * Math.Pow(5, i)) / fact(i);
            }
            Console.WriteLine(s8);
            #endregion


            #region 10
            double s9 = 1;
            for (int i = 1; i <= 7; i++)
            {
                s9 *= 3;
            }
            Console.WriteLine(s9);
            #endregion


            #region 11  
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine(i);
            }

            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine(5);
            }
            #endregion


            #region 12
            double s10 = 0;
            int x3 = Int32.Parse(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                s10 += 1 / Math.Pow(x3, i);
            }
            Console.WriteLine(s10);
            #endregion


            #region 13
            Console.WriteLine("x     y");
            double y13 = 0;
            for (double x13 = -1.5; x13 < 1.6; x13 += 0.1)
            {
                if (x13 <= -1) y13 = 1;
                else if (x13 > -1 && x13 <= 1)
                {
                    if (x13 == 0) y13 = 0;
                    else y13 = -x13;
                }
                else if (x13 > 1) y13 = -1;

                Console.WriteLine($"{Math.Round(x13, 2)}    {Math.Round(y13, 2)}");
            }
            #endregion


            #region 14
            int a = 1, b = 1, c;
            Console.WriteLine(a);
            Console.WriteLine(b);
            for (int i = 1; i <= 6; i++)
            {
                c = a + b;
                Console.WriteLine(c);
                a = b; b = c;
            }
            #endregion

        }
    }
}
