using System;

namespace lab
{
    struct Student
    {
        private string _name;
        private string _surname;
        private int[] _grades;
        private double _average;
        private bool _banned;
        public double Average { get { return _average; } }
        public bool Banned { get { return _banned; } }


        public Student(string name, string surname, int[] grades)
        {
            _name = name;
            _surname = surname;
            _average = 0;
            _banned = false;
            for (int i = 0; i < 3; i++)
            {
                _average += grades[i];
                if (grades[i] == 2) _banned = true;
            }
            _average = Math.Round(_average / 3, 2);
            _grades = grades;
        }

        public void PrintResult(string text = "Некорректная информация")
        {
            if (_name != null && _surname != null)
            {
                text = _surname + " " + _name + " " + _average;
            }
            Console.WriteLine(text);
        }

    }
    class Lab
    {
        struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _res1;
            private double _res2;
            private double _best_res;
            public double BestResult { get { return _best_res; } }
            public Sportsman(string name, string surname, double res1, double res2)
            {
                _name = name;
                _surname = surname;
                _res1 = res1;
                _res2 = res2;
                if (_res1 > _res2) _best_res = _res1;
                else _best_res = _res2;
            }
            public void PrintResult(string text = "Информация некорректна")
            {
                if (_name != null && _surname != null && _best_res > 0)
                {
                    text = _surname + " " + _name + "    " + _best_res;
                }
                Console.WriteLine(text);
            }
        }
        struct Team
        {
            private string _name;
            private int _totalScore;
            private int _delta;
            public string Name { get { return _name; } }
            public int Score { get { return _totalScore; } set {_totalScore = value; } } 
            public int Delta { get { return _delta; } set { _delta = value; } }

            public Team(string name)
            {
                _name = name;
                _totalScore = 0;
                _delta = 0;
            }

            public void Print()
            {
                Console.WriteLine(_name + ", " + _totalScore + " очков");
            }

        }

        static int CheckGrade(int grade)
        {
            while (grade > 5 || grade < 2)
            {
                Console.WriteLine("Некорректное значение");
                grade = int.Parse(Console.ReadLine());
            }
            return grade;
        }
        static void Main()
        {
            #region 1.4
            //Console.Write("Введите количество участников: ");
            //int number = int.Parse(Console.ReadLine());
            //Sportsman[] sportsmen = new Sportsman[number];
            //string name, surname;
            //double res1, res2;
            //for(int i = 0; i < number; i++)
            //{
            //    Console.WriteLine("Участник " + (i + 1));
            //    Console.Write("Фамилия: ");
            //    surname = Console.ReadLine();
            //    Console.Write("Имя: ");
            //    name = Console.ReadLine();
            //    Console.Write("Результат 1 попытки: ");
            //    res1 = double.Parse(Console.ReadLine());
            //    Console.Write("Результат 2 попытки: ");
            //    res2 = double.Parse(Console.ReadLine());
            //    Console.WriteLine();
            //    sportsmen[i] = new Sportsman(name, surname, res1, res2);
            //}

            //Sportsman tmp;
            //for (int i = 1; i < number; i++)
            //{
            //    for (int j = i; j > 0 && sportsmen[j].BestResult > sportsmen[j - 1].BestResult; j--)
            //    {
            //        tmp = sportsmen[j];
            //        sportsmen[j] = sportsmen[j - 1];
            //        sportsmen[j - 1] = tmp;
            //    }
            //}

            //for(int i = 0; i < number; i++)
            //{
            //    Console.Write(i + 1 + " место    ");
            //    sportsmen[i].PrintResult();
            //}
            #endregion

            #region 2.2
            //Console.Write("Введите количество учеников: ");
            //int number = int.Parse(Console.ReadLine());
            //Student[] students = new Student[number];
            //string name, surname;
            //int[] grades = new int[3];
            //Console.WriteLine();
            //for (int i = 0; i < number; i++)
            //{
            //    Console.Write("Фамилия: ");
            //    surname = Console.ReadLine();
            //    Console.Write("Имя: ");
            //    name = Console.ReadLine();
            //    Console.Write("Оценка по математике: ");
            //    grades[0] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.Write("Оценка по физике: ");
            //    grades[1] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.Write("Оценка по русскому языку: ");
            //    grades[2] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.WriteLine();
            //    students[i] = new Student(name, surname, grades);
            //}

            //Student tmp;
            //for (int i = 1; i < number; i++)
            //{
            //    for (int j = i; j > 0 && students[j].Average > students[j - 1].Average; j--)
            //    {
            //        tmp = students[j];
            //        students[j] = students[j - 1];
            //        students[j - 1] = tmp;
            //    }
            //}

            //for (int i = 0; i < number; i++)
            //{
            //    if (students[i].Banned == false) students[i].PrintResult();
            //}
            #endregion

            #region 3.5
            //Team[] teams = new Team[4];
            //for (int i = 0; i < 4; i++)
            //{
            //    teams[i] = new Team("Команда " + (i + 1));
            //}
            //Random random = new Random();
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = i+1; j < 4; j++)
            //    {
            //        int score1 = random.Next(0, 5);
            //        int score2 = random.Next(0, 5);
            //        Console.WriteLine(teams[i].Name + " - " + teams[j].Name + " " + score1 + ":" + score2);
            //        int delta = Math.Abs(score1 - score2);
            //        if (score1 > score2)
            //        {
            //            teams[i].Score += 3;
            //            teams[i].Delta += delta;
            //            teams[j].Delta -= delta;
            //        }
            //        else if (score1 < score2)
            //        {
            //            teams[j].Score += 3;
            //            teams[j].Delta += delta;
            //            teams[i].Delta -= delta;
            //        }
            //        else
            //        {
            //            teams[i].Score += 1;
            //            teams[j].Score += 1;
            //        }
            //    }
            //}
            //Team tmp;
            //for (int i = 1; i < 4; i++)
            //{
            //    for (int j = i; j > 0 && ((teams[j].Score > teams[j - 1].Score) || (teams[j].Score == teams[j - 1].Score && teams[j].Delta > teams[j - 1].Delta)); j--)
            //    {
            //        tmp = teams[j];
            //        teams[j] = teams[j - 1];
            //        teams[j - 1] = tmp;
            //    }
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.Write((i+1) + " место - ");
            //    teams[i].Print();
            //}
            #endregion

            Console.ReadKey();
        }
    }
}


