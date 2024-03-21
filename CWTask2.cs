//variant 3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Disciple
    {
        protected string surname;
        protected int age;
        protected int[,] grades;
        protected double averageGrade;
        protected bool hasRedDiploma;
        public string Surname { get { return surname; } }
        public void HasRedDiploma()
        {
            if(hasRedDiploma) Console.WriteLine("краснодипломник");
        }
        public Disciple(string surname, int age, int[,] grades)
        {
            this.surname = surname;
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
        public virtual void PrintInfo(string text = "")
        {
            if (hasRedDiploma) text = "краснодипломник";
            Console.WriteLine("{0}, {1} лет, средний балл {2}; {3}", surname, age, averageGrade, text);
            Console.WriteLine();
        }
    }
    class Pupil : Disciple
    {
        private int classNubber;
        private string spec;
        public Pupil(string surname, int age, int[,] grades, int classNumber, string spec) : base(surname, age, grades)
        {
            this.classNubber = classNumber;
            this.spec = spec;
        }
        public override void PrintInfo(string text = "")
        {
            if (hasRedDiploma) text = "краснодипломник";
            Console.WriteLine("{0}, {1} лет, {2} класс, специализация: {3}, средний балл {4}; {5}", surname, age, classNubber, spec, averageGrade, text);
            Console.WriteLine();
        }
    }
    class Student : Disciple
    {
        private int groupNumber;
        private int studNumber;
        public Student(string surname, int age, int[,] grades, int groupNumber, int studNumber) : base(surname, age, grades)
        {
            this.groupNumber = groupNumber;
            this.studNumber = studNumber;
        }
        public override void PrintInfo(string text = "")
        {
            if (hasRedDiploma) text = "краснодипломник";
            Console.WriteLine("{0}, {1} лет, {2} группа, студбилет: {3}, средний балл {4}; {5}", surname, age, groupNumber, studNumber, averageGrade, text);
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Disciple[] pupils = new Disciple[5];
            int[,] grades = new int[3, 5];
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
                pupils[k] = new Pupil(surnames[k], random.Next(10, 21), grades, random.Next(1, 11), surnames[k] + k);
            }
            Sort(pupils);
            PrintAllDisciples(pupils);
            Disciple[] students = new Disciple[5];
            grades = new int[3, 5];
            surnames = new string[] { "Whiskey", "Foxtrot", "Echo", "Delta", "Bravo" };
            for (int k = 0; k < 5; k++)
            {
                for (int i = 0; i < grades.GetLength(0); i++)
                {
                    for (int j = 0; j < grades.GetLength(1); j++)
                    {
                        grades[i, j] = random.Next(2, 6);
                    }
                }
                pupils[k] = new Pupil(surnames[k], random.Next(10, 21), grades, random.Next(1, 11), surnames[k] + k);
            }
            Sort(pupils);
            PrintAllDisciples(pupils);
            Console.ReadKey();
        }
        static void PrintAllDisciples(Disciple[] disciples)
        {
            foreach (var disciple in disciples)
            {
                disciple.PrintInfo();
            }
        }
        static void Sort(Disciple[] disciples)
        {
            Disciple crnt;
            for (int i = 1; i < disciples.Length; i++)
            {
                crnt = disciples[i];
                for (int j = i - 1; j >= 0;)
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
        }
    }
}
