using System;

namespace lab7
{
    class Human //2
    {
        protected string _name;
        protected string _surname;
        protected string _lastname;
        public Human (string _name, string sur_name, string last_name)
        {
            _name = _name;
            _surname = sur_name;
            _lastname = last_name;
        }
    }
    class Student: Human
    {
        private double _average = 0;
        private int _id;
        private bool _banned = false;
        private static int nextId = 0;
        public double Average { get { return _average; } }
        public bool Banned { get { return _banned; } }

        public Student(string _name, string sur_name, string last_name, int[] grades) : base(_name, sur_name, last_name)
        {
            _id = ++nextId;
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
            private string __name;
            private string _sur_name;
            private double _res1;
            private double _res2;
            private double _best_res;
            private bool _disqualified = false;
            public double BestResult { get { return _best_res; } }
            public Sportsman(string _name, string sur_name, double res1, double res2)
            {
                __name = _name;
                _sur_name = sur_name;
                _res1 = res1;
                _res2 = res2;
                if (_res1 > _res2) _best_res = _res1;
                else _best_res = _res2;
            }
            public void Disqualify() => _disqualified = true;
            public void PrintResult(string text = "Информация некорректна")
            {
                if (__name != null && _sur_name != null && _best_res > 0)
                {
                    text = _sur_name + " " + __name + "    " + _best_res;
                }
                if (!_disqualified) Console.WriteLine(text);
            }
        }
        class Team //3
        {
            protected string _name;
            protected int _totalScore = 0;
            protected int _delta = 0;

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
            public void Lose(int delta)
            {
                _delta -= delta;
            }
            public void Draw()
            {
                _totalScore += 1;
            }
            public static void Match(Team team1, Team team2, int score1, int score2)
            {
                Console.WriteLine(team1._name + " - " + team2._name + " " + score1 + ":" + score2);
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
            static int Findpvt(Team[] teams, int minIndex, int maxIndex)
            {
                int pvt = minIndex;
                Team tmp;
                for (int i = minIndex; i < maxIndex; i++)
                {
                    if (teams[i]._totalScore > teams[maxIndex]._totalScore)
                    {
                        tmp = teams[pvt];
                        teams[pvt] = teams[i];
                        teams[i] = tmp;
                        pvt++;
                    }
                }
                tmp = teams[pvt];
                teams[pvt] = teams[maxIndex];
                teams[maxIndex] = tmp;
                return pvt;
            }
            public static void QuickSort(Team[] teams, int minIndex, int maxIndex)
            {
                if (minIndex >= maxIndex)
                {
                    return;
                }
                int pvt = Findpvt(teams, minIndex, maxIndex);
                QuickSort(teams, minIndex, pvt - 1);
                QuickSort(teams, pvt + 1, maxIndex);
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
        

        static void Main()
        {
            #region 1.4
            //Console.Write("Введите количество участников: ");
            //int number = int.Parse(Console.ReadLine());
            //Sportsman[] sportsmen = new Sportsman[number];
            //string _name, sur_name;
            //double res1, res2;
            //for (int i = 0; i < number; i++)
            //{
            //    Console.WriteLine("Участник " + (i + 1));
            //    Console.Write("Фамилия: ");
            //    sur_name = Console.ReadLine();
            //    Console.Write("Имя: ");
            //    _name = Console.ReadLine();
            //    Console.Write("Результат первой попытки: ");
            //    res1 = double.Parse(Console.ReadLine());
            //    Console.Write("Результат второй попытки: ");
            //    res2 = double.Parse(Console.ReadLine());
            //    Console.WriteLine();
            //    sportsmen[i] = new Sportsman(_name, sur_name, res1, res2);
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
            //string _name, sur_name, last_name;
            //int[] grades = new int[3];
            //Console.WriteLine();
            //for (int i = 0; i < number; i++)
            //{
            //    Console.WriteLine(i + 1);
            //    Console.Write("Фамилия: ");
            //    sur_name = Console.ReadLine();
            //    Console.Write("Имя: ");
            //    _name = Console.ReadLine();
            //    Console.Write("Отчество: ");
            //    last_name = Console.ReadLine();
            //    Console.Write("Оценка по математике: ");
            //    grades[0] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.Write("Оценка по физике: ");
            //    grades[1] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.Write("Оценка по русскому языку: ");
            //    grades[2] = CheckGrade(int.Parse(Console.ReadLine()));
            //    Console.WriteLine();
            //    students[i] = new Student(_name, sur_name, last_name, grades);
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
                    Team.Match(man_teams[i], man_teams[j], score1, score2);
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

                    Team.Match(woman_teams[i], woman_teams[j], score1, score2);
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
            Team.QuickSort(teams, 0, teams.Length - 1);
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