
using System;
class HelloWorld
{
    static double[] CreateArray1(int len)
    {
        double[] arr = new double[len];
        for (int i = 0; i < len; i++)
        {
            Console.Write("[" + i + "] ");
            arr[i] = Double.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        return arr;
    }
    static void PrintArray1(double[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
    static double[,] CreateArray2(int leni, int lenj)
    {
        double[,] arr = new double[leni, lenj];
        for (int i = 0; i < leni; i++)
        {
            for (int j = 0; j < lenj; j++)
            {
                Console.Write("[" + i + "," + j + "] ");
                arr[i, j] = Double.Parse(Console.ReadLine());

            }
            Console.WriteLine();
        }
        Console.WriteLine();

        return arr;
    }
    static void PrintArray2(double[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    static int MaxIndex(double[] arr)
    {
        int im = 0;
        double max = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                im = i;
            }
        }
        return im;
    }
    static double Sr(double[] arr, int im)
    {
        double sum = 0;
        for (int i = im + 1; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return Math.Round(sum / (arr.Length - im - 1), 2);

    }
    static double[] RemoveElm(double[] arr, int index)
    {
        double[] new_arr = new double[arr.Length - 1];
        for (int i = 0; i < index; i++)
        {
            new_arr[i] = arr[i];
        }
        for (int i = index; i < new_arr.Length; i++)
        {
            new_arr[i] = arr[i + 1];
        }
        return new_arr;
    }

    static double[,] RemoveColumn(double[,] arr, int index)
    {
        double[,] new_arr = new double[arr.GetLength(0), arr.GetLength(1) - 1];
        for (int j = 0; j < index; j++)
        {
            for (int i = 0; i < new_arr.GetLength(0); i++)
            {
                new_arr[i, j] = arr[i, j];
            }
        }
        for (int j = index; j < new_arr.GetLength(1); j++)
        {
            for (int i = 0; i < new_arr.GetLength(0); i++)
            {
                new_arr[i, j] = arr[i, j + 1];
            }
        }
        return new_arr;
    }
    static double[,] CheckColumns(double[,] arr)
    {
        double p = 1;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                p *= arr[i, j];
            }
            if (p != 0)
            {
                arr = RemoveColumn(arr, j);
                j--;
            }
            p = 1;

        }
        return arr;
    }

    static double[] SortFrom(double[] arr, int index)
    {
        index += 1;
        double t;
        for (int i = index; i < arr.Length; i++)
        {
            for (int j = index; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    t = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = t;
                }
            }
        }
        return arr;
    }

    static double[,] SortLine(double[,] arr, int index)
    {
        double t;
        for (int i = 0; i < arr.GetLength(1); i++)
        {
            for (int j = 0; j < arr.GetLength(1) - 1; j++)
            {
                if (arr[index, j] > arr[index, j + 1])
                {
                    t = arr[index, j];
                    arr[index, j] = arr[index, j + 1];
                    arr[index, j + 1] = t;
                }
            }

        }
        return arr;
    }

    static void Switch(double[] arr, int i1, int i2)
    {
        double t = arr[i1];
        arr[i1] = arr[i2];
        arr[i2] = t;

    }
    static int CountNegatives(double[,] arr, int i)
    {
        int count = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] < 0) count++;
        }
        return count;
    }
    static int MaxNegativesLine(double[,] arr)
    {
        int imax = 0;
        double max = -1;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            if (CountNegatives(arr, i) > max)
            {
                max = CountNegatives(arr, i);
                imax = i;
            }
        }
        return imax;
    }

    static void Main()
    {
        #region 3_4-modified
        int n = Int32.Parse(Console.ReadLine());
        while (n < 1)
        {
            Console.WriteLine("Try again bro");
            n = Int32.Parse(Console.ReadLine());
        }
        double[,] a = new double[n, n];
        double[] b = new double[n * n];
        int index = 0;
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine("[" + i + "," + j + "]");
                a[i, j] = Double.Parse(Console.ReadLine());
                b[index] = a[i, j];
                index++;
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 1; i < n * n; i++)
        {
            if (b[i] < b[i - 1])
            {
                Switch(b, i, i - 1);
                for (int j = i - 1; j > 0; j--)
                {
                    if (b[j] < b[j - 1]) Switch(b, j, j - 1);
                    else break;
                }
            }
        }
        index = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                a[i, j] = b[index];
                index++;
                Console.Write(a[i, j] + " ");
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
        #endregion

        #region 2
        //double s;
        //int ia, ib;
        //Console.WriteLine("A:");
        //double[] a = CreateArray1(9);
        //Console.WriteLine("B:");
        //double[] b = CreateArray1(7);
        //ia = MaxIndex(a);
        //ib = MaxIndex(b);
        //if (a.Length - ia >= b.Length - ib) s = Sr(a, ia);
        //else s = Sr(b, ib);
        //a[ia] = s;
        //b[ib] = s;
        //Console.WriteLine("A:");
        //PrintArray1(a);
        //Console.WriteLine("B:");
        //PrintArray1(b);
        #endregion

        #region 8
        //Console.WriteLine("A:");
        //double[] a = CreateArray1(9);
        //Console.WriteLine("B:");
        //double[] b = CreateArray1(7);
        //a = SortFrom(a, MaxIndex(a));
        //b = SortFrom(b, MaxIndex(b));
        //Console.WriteLine("A:");
        //PrintArray1(a);
        //Console.WriteLine("B:");
        //PrintArray1(b);
        #endregion

        #region 14
        //Console.Write("n: ");
        //int n = Int32.Parse(Console.ReadLine());
        //Console.Write("m: ");
        //int m = Int32.Parse(Console.ReadLine());
        //while (n < 1 || m < 1)
        //{
        //    Console.WriteLine("Try again bro");
        //    Console.Write("n: ");
        //    n = Int32.Parse(Console.ReadLine());
        //    Console.Write("m: ");
        //    m = Int32.Parse(Console.ReadLine());
        //}
        //double[,] a = CreateArray2(n, m);
        //for (int i = 0; i < a.GetLength(0); i++)
        //{
        //    a = SortLine(a, i);
        //}
        //PrintArray2(a);
        #endregion

        #region 20
        //Console.WriteLine("A:");
        //Console.Write("n: ");
        //int n1 = int.Parse(Console.ReadLine());
        //Console.Write("m: ");
        //int m1 = int.Parse(Console.ReadLine());
        //while (n1 < 1 || m1 < 1)
        //{
        //    Console.WriteLine("Так неинтересно!");
        //    Console.Write("n: ");
        //    n1 = int.Parse(Console.ReadLine());
        //    Console.Write("m: ");
        //    m1 = int.Parse(Console.ReadLine());
        //}
        //double[,] a = CreateArray2(n1, m1);
        //Console.WriteLine("B:");
        //Console.Write("n: ");
        //int n2 = int.Parse(Console.ReadLine());
        //Console.Write("m: ");
        //int m2 = int.Parse(Console.ReadLine());
        //while (n2 < 1 || m2 < 1)
        //{
        //    Console.WriteLine("Так неинтересно!");
        //    Console.Write("n: ");
        //    n2 = int.Parse(Console.ReadLine());
        //    Console.Write("m: ");
        //    m2 = int.Parse(Console.ReadLine());
        //}
        //double[,] b = CreateArray2(n2, m2);
        //a = CheckColumns(a);
        //b = CheckColumns(b);
        //Console.WriteLine("A:");
        //PrintArray2(a);
        //Console.WriteLine("B:");
        //PrintArray2(b);
        #endregion

        #region 26
        //Console.Write("n: ");
        //int n = int.Parse(Console.ReadLine());
        //Console.Write("m: ");
        //int m = int.Parse(Console.ReadLine());
        //while (n < 1 || m < 1)
        //{
        //    Console.WriteLine("Nope)");
        //    Console.Write("n: ");
        //    n = int.Parse(Console.ReadLine());
        //    Console.Write("m: ");
        //    m = int.Parse(Console.ReadLine());
        //}
        //Console.WriteLine("A:");
        //double[,] a = CreateArray2(n, m);
        //Console.WriteLine("B:");
        //double[,] b = CreateArray2(n, m);
        //double t;
        //int im1 = MaxNegativesLine(a), im2 = MaxNegativesLine(b);
        //for (int j = 0; j < m; j++)
        //{
        //    t = a[im1, j];
        //    a[im1, j] = b[im2, j];
        //    b[im2, j] = t;
        //}
        //Console.WriteLine("A:");
        //PrintArray2(a);
        //Console.WriteLine("B:");
        //PrintArray2(b);
        #endregion

        Console.ReadKey();
    }
}


