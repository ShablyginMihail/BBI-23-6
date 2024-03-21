using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Disciple
    {
        private string surname;
        private int age;
        private int[,] grades;
        private double averageGrade;
        private bool hasRedDiploma;
        public string Surname { get { return surname; } }
        public void HasRedDiploma()
        {
            if(hasRedDiploma) Console.WriteLine("краснодипломник");
        }
        public Disciple(string surnsame, int age, int[,] grades)
        {
            this.surname = surnsame;
            this.age = age;
            this.grades = grades;
            averageGrade = 0;
            for(int i = 0; i < grades.GetLength(0); i++)
            {
                for (int j = 0; j < grades.GetLength(1); j++)
                {
                    averageGrade += grades[i, j];
                }
            }
            averageGrade = Math.Round(averageGrade/grades.Length, 2);
            hasRedDiploma = false;
            if (averageGrade > 4.5) hasRedDiploma = true;
        }
        public void PrintInfo(string text = "")
        {
            if (hasRedDiploma) text = "краснодипломник";
            Console.WriteLine("{0}, {1} лет, средний балл {2}; {3}", surname, age, averageGrade, text);
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Disciple[] disciples = new Disciple[5];
            int[,] grades = new int[1, 5];
            string[] surnames = new string[] { "Alpha", "Charlie", "Echo", "Delta", "Bravo" };
            for (int k = 0; k < 5; k++)
            {
                for (int i = 0; i < grades.GetLength(0); i++)
                {
                    for (int j = 0; j < grades.GetLength(1); j++)
                    {
                        grades[i, j] = random.Next(2, 6);
                    }
                }
                disciples[k] = new Disciple(surnames[k], random.Next(10, 21), grades);
            }
            Disciple crnt;
            for(int i = 1; i < disciples.Length; i++)
            {
                crnt = disciples[i];
                for(int j = i - 1; j >= 0;)
                {
                    if (crnt.Surname.CompareTo(disciples[j].Surname) < 0)
                    {
                        disciples[j + 1] = disciples[j];
                        j--;
                        disciples[j + 1] = crnt;
                    }
                    else break;
                }
            }
            PrintAllDisciples(disciples);
            Console.ReadKey();
        }
        static void PrintAllDisciples(Disciple[] disciples)
        {
            foreach (var disciple in disciples)
            {
                disciple.PrintInfo();
            }
        }
    }
}
