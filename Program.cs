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
            double a = 0.1;
            double b = 1;
            double lim = 0.0001;
            double h = 0.05;
            int i = 0;
            double x = a;
            double y;
            double s = 0;

            while (true)
            {
                double elm = Math.Pow(x, 2 * i) / fact(2 * i);
                if (elm < lim)
                {
                    y = (Math.Pow(Math.E, x) + Math.Pow(Math.E, -x)) / 2;
                    break;
                }
                else
                {
                    s += elm;
                }
                x += h;
                i++;
            }

            Console.WriteLine(s);
            Console.WriteLine(y);
        }
            
    }
}
