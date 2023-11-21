
using System;
class HelloWorld
{
    static void Main()
    {
        #region 1_2
        double[,] a = new double[5, 7];
        double sum = 0, elm;
        int cnt = 0;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                elm = Double.Parse(Console.ReadLine());
                a[i, j] = elm;
                if (elm > 0)
                {
                    sum += elm;
                    cnt++;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine(sum / cnt);
        #endregion

        #region 1_6
        double[,] a = new double[4, 7];
        int[] b = new int[4];
        double min, elm;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            min = Math.Pow(10, 100);
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                elm = Double.Parse(Console.ReadLine());
                a[i, j] = elm;
                if (elm < min)
                {
                    min = elm;
                    b[i] = j;
                }
            }
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            Console.WriteLine(b[i] + " ");
        }
        #endregion

        #region 1_10
        double[,] a = new double[4, 3];
        int index = -1;
        double max = -1 * Math.Pow(10, 100), t;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
            }
            if (a[i, 2] > max)
            {
                max = a[i, 2];
                index = i;
            }
        }
        for (int j = 0; j < a.GetLength(1); j++)
        {
            t = a[index, j];
            a[index, j] = a[3, j];
            a[3, j] = t;
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion


        #region 1_14
        double[,] a = new double[4, 3];
        double[] b = new double[4];
        int index = -1;
        int cnt;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
        for (int j = 0; j < a.GetLength(1); j++)
        {
            cnt = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (a[i, j] < 0) cnt++;
            }
            b[j] = cnt;
            Console.Write(b[j] + " ");
        }
        #endregion

        #region 1_18
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        double[,] d = new double[n, m];
        double max, t;
        int j1, j2;
        bool flag;
        for (int i = 0; i < d.GetLength(0); i++)
        {
            max = -1;
            j1 = -1;
            j2 = -1;
            flag = true;
            for (int j = 0; j < d.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                d[i, j] = Double.Parse(Console.ReadLine());
                if (d[i, j] < 0)
                {
                    flag = false;
                    j2 = j;
                }
                if (d[i, j] > max & flag == true)
                {
                    max = d[i, j];
                    j1 = j;
                }
            }
            if (j1 != -1 & j2 != -1)
            {
                t = d[i, j1];
                d[i, j1] = d[i, j2];
                d[i, j2] = t;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < d.GetLength(0); i++)
        {
            for (int j = 0; j < d.GetLength(1); j++)
            {
                Console.Write(d[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 1_22
        double[,] z = new double[6, 8];
        double max = -1 * Math.Pow(10, 100), sum = 0;
        int im = -1, jm = -1, cnt = 0;
        for (int i = 0; i < z.GetLength(0); i++)
        {
            for (int j = 0; j < z.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                z[i, j] = Double.Parse(Console.ReadLine());
                if (z[i, j] > 0)
                {
                    sum += z[i, j];
                    cnt++;
                }
                if (z[i, j] > max)
                {
                    max = z[i, j];
                    im = i;
                    jm = j;
                }
            }
            Console.WriteLine();
        }
        z[im, jm] = sum / cnt;
        Console.WriteLine();
        for (int i = 0; i < z.GetLength(0); i++)
        {
            for (int j = 0; j < z.GetLength(1); j++)
            {
                Console.Write(z[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 1_26
        double[,] a = new double[3, 7];
        double[] b = new double[7];
        double max = -1 * Math.Pow(10, 100);
        int im = -1, cnt = 0;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("a[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
            }
            if (a[i, 5] > max)
            {
                max = a[i, 5];
                im = i;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(1); i++)
        {
            Console.WriteLine("b[" + i + "]");
            b[i] = Double.Parse(Console.ReadLine());
            a[im, i] = b[i];
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 1_30
        double[,] b = new double[5, 5];
        double max = -1 * Math.Pow(10, 100), t;
        int i1 = -1, i2 = -1;
        bool flag = true;
        for (int i = 0; i < b.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                b[i, j] = Double.Parse(Console.ReadLine());
            }
            if (b[i, i] > max)
            {
                max = b[i, i];
                i1 = i;
            }
            if (b[i, 2] < 0 & flag == true)
            {
                i2 = i;
                flag = false;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int j = 0; j < b.GetLength(1); j++)
        {
            t = b[i1, j];
            b[i1, j] = b[i2, j];
            b[i2, j] = t;
        }
        for (int i = 0; i < b.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                Console.Write(b[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 2_1
        double[,] a = new double[5, 7];
        double max;
        int jm = -1;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                max = -1 * Math.Pow(10, 100);
                Console.WriteLine("[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
                if (a[i, j] > max)
                {
                    max = a[i, j];
                    jm = j;
                }
            }
            switch (jm)
            {
                case 0:
                    a[i, 1] *= 2;
                    break;
                case 6:
                    a[i, jm - 1] *= 2;
                    break;
                default:
                    if (a[i, jm - 1] <= a[i, jm + 1]) a[i, jm - 1] *= 2;
                    else a[i, jm + 1] *= 2;
                    break;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 2_5
        double[,] a = new double[7, 5];
        double max;
        double sum = 0;
        int im = -1;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }

        for (int j = 0; j < a.GetLength(1); j++)
        {
            im = 0;
            max = a[0, j];
            sum = (a[0, j] + a[a.GetLength(0) - 1, j]) / 2;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (a[i, j] > max)
                {
                    im = i;
                    max = a[i, j];
                }
            }
            if (a[im, j] < sum) a[im, j] = sum;
            else a[im, j] = im + 1;
        }

        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion


        #region 2_9
        double[,] a = new double[6, 7];
        double t;
        int im = -1;
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < (a.GetLength(1) - 1) / 2; j++)
            {
                t = a[i, j];
                a[i, j] = a[i, a.GetLength(1) - j - 1];
                a[i, a.GetLength(1) - j - 1] = t;
            }
        }
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 3_3
        int n = Int32.Parse(Console.ReadLine());
        if (n > 0)
        {
            double[,] a = new double[n, n];
            double[] b = new double[2 * n - 1];
            double sum = 0;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("[" + i + "," + j + "]");
                    a[i, j] = Double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int index = 0;
            for (int i = n - 1; i > -1; i--)
            {
                for (int j = 0; j < n - i; j++)
                {
                    sum += a[i + j, j];
                }
                b[index] = sum;
                index++;
                sum = 0;
            }
            for (int j = 1; j < n; j++)
            {
                for (int i = 0; i < n - j; i++)
                {
                    sum += a[i, j + i];
                }
                b[index] = sum;
                index++;
                sum = 0;
            }
            for (int i = 0; i < 2 * n - 1; i++)
            {
                Console.Write(b[i] + " ");
            }
        }
        #endregion

        #region 3_4
        int n = Int32.Parse(Console.ReadLine());
        if (n > 0)
        {
            double[,] a = new double[n, n];
            double sum = 0;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("[" + i + "," + j + "]");
                    a[i, j] = Double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = n - 1; i > n / 2 - 1; i--)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    a[i, j] = 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        Console.ReadKey();

    }
}
