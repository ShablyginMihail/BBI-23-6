using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
			#region 1.1
			int s = 0;
			for (int i = 2; i <= 35; i += 3)
			{
				s += i;
			}
			Console.WriteLine(s);
			#endregion

			#region 1.2
			double sum = 0;
			for (double i = 1; i <= 10; i += 1)
				sum += (1 / i);
			Console.WriteLine(sum);
			#endregion

			#region 1.3
			sum = 0;
			for (double i = 1; i <= 113; i += 2)
			{
				sum += (i + 1) / (i + 2);
			}
			Console.WriteLine(sum);
			#endregion

			#region 1.4
			sum = 0;
			int x = 10;
			for (int i = 0; i <= 8; i += 1)
			{
				sum += Math.Cos((i + 1) * x) / Math.Pow(x, 0);
			}
			Console.WriteLine(sum);
			#endregion
		}
	}

}
