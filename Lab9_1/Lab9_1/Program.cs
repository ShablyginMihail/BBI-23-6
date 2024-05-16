using System;
using System.Text.Json;
using System.Collections.Generic;
using ProtoBuf;
using Lab9_1.Serializers;

namespace lab
{
    [ProtoContract]
    [Serializable]
    [ProtoInclude(1, typeof(Student))]
    public class Human //2
    {
        protected string _name;
        protected string _surname;
        protected string _lastname;
        [ProtoMember(2)]
        public string Name
        {
            get => _name;
            set => _name = value ?? string.Empty;
        }
        [ProtoMember(3)]
        public string Surame
        {
            get => _surname;
            set => _surname = value ?? string.Empty;
        }
        [ProtoMember(4)]
        public string Lastname
        {
            get => _lastname;
            set => _lastname = value ?? string.Empty;
        }
        public Human() { }
        public Human(string name, string surname, string lastname)
        {
            _name = name;
            _surname = surname;
            _lastname = lastname;
        }
    }

    [ProtoContract]
    [Serializable]
    public class Student : Human
    {
        private double _average = 0;
        private int _id;
        private bool _banned = false;
        private static int nextId = 0;
        [ProtoMember(5)]
        public double Average
        {
            get => _average;
            set => _average = value;
        }
        [ProtoMember(6)]
        public bool Banned
        {
            get => _banned;
            set => _banned = value;
        }
        [ProtoMember(7)]
        public int ID
        {
            get => _id;
            set => _id = value;
        }
        public Student() : base() { }
        public Student(string _name, string surname, string lastname, int[] grades) : base(_name, surname, lastname)
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

    [ProtoContract]
    [Serializable]
    public class Sportsman //1
    {
        private string _name;
        private string _surname;
        private double _res1;
        private double _res2;
        private double _best_res;
        private bool _disqualified = false;
        [ProtoMember(8)]
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        [ProtoMember(9)]
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        [ProtoMember(10)]
        public double BestResult
        {
            get => _best_res;
            set => _best_res = value;
        }
        public Sportsman() { }
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

    [ProtoContract]
    [Serializable]
    [ProtoInclude(11, typeof(ManTeam))]
    [ProtoInclude(12, typeof(WomanTeam))]
    public class Team //3
    {
        protected string _name;
        protected int _totalScore = 0;
        protected int _delta = 0;
        [ProtoMember(13)]
        public string Name
        {
            get => _name;
            set => _name = value ?? string.Empty;
        }
        [ProtoMember(14)]
        public int TotalScore
        {
            get => _totalScore;
            set => _totalScore = value;
        }
        public Team() { }
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
            //Console.WriteLine(team1._name + " - " + team2._name + " " + score1 + ":" + score2);
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
        public static int CheckGrade(int grade)
        {
            while (grade > 5 || grade < 2)
            {
                Console.WriteLine("Некорректное значение");
                grade = int.Parse(Console.ReadLine());
            }
            return grade;
        }
    }

    [ProtoContract]
    [Serializable]
    public class ManTeam : Team
    {
        public ManTeam() : base() { }
        public ManTeam(string name) : base(name)
        {
            _name = "Man " + name;
        }
    }

    [ProtoContract]
    [Serializable]
    public class WomanTeam : Team
    {
        public WomanTeam() : base() { }
        public WomanTeam(string name) : base(name)
        {
            _name = "Woman " + name;
        }

    }

    public class Lab
    {
        static void Main()
        {
            ISer[] serializers = new ISer[]
            {
                new MySerializeJson(),
                new MySerializeXML(),
                new MySerializeBin()
            };
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            #region 1.4
            Sportsman[] sportsmen = new Sportsman[]
            {
                new Sportsman("Central", "Cee", 2, 3),
                new Sportsman("Igor", "Letov", 3, 4),
                new Sportsman("Kirill", "Bledny", 5, 6),
                new Sportsman("Robert", "Voskresenskii", 7, 8),
                new Sportsman("Slava", "Marlow", 9, 0)
            };

            string folder_1 = "Sportsmen";
            string path_1 = Path.Combine(path, folder_1);
            if (!Directory.Exists(path_1)) Directory.CreateDirectory(path_1);
            string[] files_1 = new string[]
            {
                "sportsmen.json",
                "sportsmen.xml",
                "sportsmen.bin"
            };
            #endregion

            #region 2.2

            //Student[] students = new Student[]
            //{
            //    new Student("Bushido", "Zho", "Vodila", new int[] {5, 1, 2}),
            //    new Student("Yuri", "Chetverg", "_", new int[] {1, 0, 4}),
            //    new Student("Big", "Baby", "Tape", new int[] {5, 4, 3}),
            //    new Student("Friendly", "Thug", "52NGG", new int[] {0, 5, 2})
            //};

            //string folder_2 = "Students";
            //string path_2 = Path.Combine(path, folder_2);
            //if (!Directory.Exists(path_2)) Directory.CreateDirectory(path_2);
            //string[] files_2 = new string[]
            //{
            //    "students.json",
            //    "students.xml",
            //    "students.bin"
            //};
            #endregion

            #region 3.5
            //Team[] teams = new Team[8];
            //Team[] man_teams = new Team[4];
            //Team[] woman_teams = new Team[4];
            //Random random = new Random();
            //int score1, score2;
            //for (int i = 0; i < 4; i++)
            //{
            //    man_teams[i] = new ManTeam("Team " + (i + 1));
            //}

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = i + 1; j < 4; j++)
            //    {
            //        score1 = random.Next(0, 6);
            //        score2 = random.Next(0, 6);
            //        Team.Match(man_teams[i], man_teams[j], score1, score2);
            //    }
            //}
            //Console.WriteLine();
            //for (int i = 0; i < 4; i++)
            //{
            //    woman_teams[i] = new WomanTeam("Team " + (i + 1));
            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = i + 1; j < 4; j++)
            //    {
            //        score1 = random.Next(0, 6);
            //        score2 = random.Next(0, 6);

            //        Team.Match(woman_teams[i], woman_teams[j], score1, score2);
            //    }
            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    teams[i] = man_teams[i];
            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    teams[i + 4] = woman_teams[i];
            //}
            //Team.QuickSort(teams, 0, teams.Length - 1);

            //string folder_3 = "Teams";
            //string path_3 = Path.Combine(path, folder_3);
            //if (!Directory.Exists(path_3)) Directory.CreateDirectory(path_3);
            //string[] files_3 = new string[]
            //{
            //    "teams.json",
            //    "teams.xml",
            //    "teams.bin"
            //};
            #endregion



            for (int i = 0; i < serializers.Length; i++)
            {
                serializers[i].Write(sportsmen, Path.Combine(path_1, files_1[i]));
                //serializers[i].Write(students, Path.Combine(path_2, files_2[i]));
                //serializers[i].Write(teams, Path.Combine(path_3, files_3[i]));

            }
            for (int i = 0; i < serializers.Length; i++)
            {
                sportsmen = serializers[i].Read<Sportsman[]>(Path.Combine(path_1, files_1[i]));
                foreach (Sportsman sportsman in sportsmen)
                {
                    sportsman.PrintResult();
                }
                //students = serializers[i].Read<Student[]>(Path.Combine(path_2, files_2[i]));
                //teams = serializers[i].Read<Team[]>(Path.Combine(path_3, files_3[i]));
            }
            
            Console.ReadKey();
        }

    }
}

