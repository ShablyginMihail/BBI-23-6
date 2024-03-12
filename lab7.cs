using System;

namespace lab7
{
    class Human //2
    {
        protected string _name;
        protected string _surname;
        protected string _lastname;
        public Human (string name, string surname, string lastname)
        {
            _name = name;
            _surname = surname;
            _lastname = lastname;
        }
    }
    class Student: Human
    {
        private double _average = 0;
        private int _id;
        private bool _banned = false;
        public double Average { get { return _average; } }
        public bool Banned { get { return _banned; } }

        public Student(string name, string surname, string lastname, int id, int[] grades) : base(name, surname, lastname)
        {
            _id = id;
            for (int i = 0; i < 3; i++)
            {
                _average += grades[i];
                if (grades[i] == 2) _banned = true;
            }
            _average = Math.Round(_average / 3, 2);
        }

        public void PrintResult(string text = "Некорректная информация")
        {
            if (_name != null && _surname != null && _lastname != null)
            {
                text = _surname + " " + _name + " " + _lastname + " [" + _id + "] " + _average;
            }
            Console.WriteLine(text);
        }

    } 
    class Lab
    {
        class Sportsman //1
        {
            private string _name;
            private string _surname;
            private double _res1;
            private double _res2;
            private double _best_res;
            private bool _disqualified = false;
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
            public void Disqualify() => _disqualified = true;
            public void PrintResult(string text = "Информация некорректна")
            {
                if (_name != null && _surname != null && _best_res > 0)
                {
                    text = _surname + " " + _name + "    " + _best_res;
                }
                if (!_disqualified) Console.WriteLine(text);
            }
        } 
        class Team //3
        {
            protected string _name;
            protected int _totalScore = 0;
            protected int _delta = 0;
            public string Name { get { return _name; } }
            public int Score { get { return _totalScore; } set { _totalScore = value; } }
            public int Delta { get { return _delta; } set { _delta = value; } }

            public Team(string name)
            {
                _name = name;
            }
            public void Print() => Console.WriteLine("{0}, {1} очков", _name, _totalScore);

            public void Win(int delta)
            {
                _totalScore += 3;
                _delta += delta;
            }
            public  void Lose(int delta)
            {
                _delta -= delta;
            }
            public void Draw()
            {
                _totalScore += 1;
            }

        }
        class ManTeam: Team
        {
            public ManTeam(string name) : base(name)
            {
                _name = name + " мужская";
            }
        }
        class WomanTeam : Team
        {
            public WomanTeam(string name) : base(name)
            {
                _name = name + " женская";
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
        static void Match(ref Team team1, ref Team team2, int score1, int score2)
        {
            Console.WriteLine(team1.Name + " - " + team2.Name + " " + score1 + ":" + score2);
            int delta = Math.Abs(score1 - score2);
            if (score1 > score2)
            {
                team1.Win(delta);
                team2.Lose(delta);
            }
            else if (score1 < score2)
            {
                team2.Win(delta);
                team1.Lose(delta);
            }
            else
            {
                team1.Draw();
                team2.Draw();
            }
        }
        static void SortTeams(Team[] teams)
        {
            Team tmp;
            for (int i = 1; i < teams.Length; i++)
            {
                for (int j = i; j > 0 && ((teams[j].Score > teams[j - 1].Score) || (teams[j].Score == teams[j - 1].Score && teams[j].Delta > teams[j - 1].Delta)); j--)
                {
                    tmp = teams[j];
                    teams[j] = teams[j - 1];
                    teams[j - 1] = tmp;
                }
            }
        }

        static void Main()
        {
            #region 1.4
            //Console.Write("Введите количество участников: ");
            //int number = int.Parse(Console.ReadLine());
            //Sportsman[] sportsmen = new Sportsman[number];
            //string name, surname;
            //double res1, res2;
            //for (int i = 0; i < number; i++)
            //{
            //    Console.WriteLine("Участник " + (i + 1));
            //    Console.Write("Фамилия: ");
            //    surname = Console.ReadLine();
            //    Console.Write("Имя: ");
            //    name = Console.ReadLine();
            //    Console.Write("Результат первой попытки: ");
            //    res1 = double.Parse(Console.ReadLine());
            //    Console.Write("Результат второй попытки: ");
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
            //sportsmen[number - 1].Disqualify();

            //for (int i = 0; i < number; i++)
            //{
            //    sportsmen[i].PrintResult();
            //}
            #endregion

            #region 2.2
            //Console.Write("Введите количество учеников: ");
            //int number = int.Parse(Console.ReadLine());
            //Student[] students = new Student[number];
            //string name, surname, lastname;
            //int id;
            //int[] grades = new int[3];
            //Console.WriteLine();
            //for (int i = 0; i < number; i++)
            //{
            //    Console.WriteLine(i + 1);
            //    Console.Write("Фамилия: ");
            //    surname = Console.ReadLine();
            //    Console.Write("Имя: ");
            //    name = Console.ReadLine();
            //    Console.Write("Отчество: ");
            //    lastname = Console.ReadLine();
            //    Console.Write("ID: ");
            //    id = int.Parse(Console.ReadLine());
            //    Console.Write("Оценка по математике: ");
            //    grades[0] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.Write("Оценка по физике: ");
            //    grades[1] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.Write("Оценка по русскому языку: ");
            //    grades[2] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.WriteLine();
            //    students[i] = new Student(name, surname, lastname, id, grades);
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
            Team[] teams = new Team[8];
            Team[] man_teams = new Team[4];
            Team[] woman_teams = new Team[4];
            Random random = new Random();
            int score1, score2;
            for (int i = 0; i < 4; i++)
            {
                man_teams[i] = new ManTeam("Команда " + (i + 1));
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    score1 = random.Next(0, 6);
                    score2 = random.Next(0, 6);

                    Match(ref man_teams[i], ref man_teams[j], score1, score2);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                woman_teams[i] = new WomanTeam("Команда " + (i + 1));
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    score1 = random.Next(0, 6);
                    score2 = random.Next(0, 6);

                    Match(ref woman_teams[i], ref woman_teams[j], score1, score2);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                teams[i] = man_teams[i];
            }
            for (int i = 0; i < 4; i++)
            {
                teams[i + 4] = woman_teams[i];
            }
            SortTeams(teams);
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.Write((i + 1) + " место - ");
                teams[i].Print();
            }
            #endregion

            Console.ReadKey();
        }

    }
}