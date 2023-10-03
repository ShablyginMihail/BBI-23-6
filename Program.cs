using System;

namespace ConsoleApp3
{
    class L3N7
    {
        static void Main(string[] args)
        {
            double a = 0.1;
            double b = 1;
            double lim = 0.0001;
            double h = 0.05;
            double y;
            double s = 0;

            for (double x = a; x <= b; x += h)
            {
                int i = 0;
                while (true)
                {
                    double elm;
                    double pow = 1, fact = 1;
                    for (int c = 1; c <= 2 * i; c++)
                    {
                        pow *= x;
                        fact *= c;
                    }
                    elm = pow / fact;
                    if (elm < lim)
                    {
                        break;
                    }
                    else
                    {
                        s += elm;
                    }
                    i++;
                }
                y = (Math.Pow(Math.E, x) + Math.Pow(Math.E, -x)) / 2;
                Console.WriteLine(s);
                Console.WriteLine(y);
                Console.WriteLine();
                x += h;
                s = 0;
            }

        }
            
    }
}
