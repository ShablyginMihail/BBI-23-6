using System;
using System.Text.Json;
using System.Collections.Generic;
using ProtoBuf;
using Lab9_3.Serializers;
using System.Xml.Serialization;
using System.Drawing;

namespace lab
{
    [ProtoContract]
    [Serializable]
    [ProtoInclude(1, typeof(Student))]
    public class Human //2
    {
        [XmlAttribute]
        protected string _name;
        [XmlAttribute]
        protected string _surname;
        [XmlAttribute]
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
    [ProtoInclude(1, typeof(ManTeam))]
    [ProtoInclude(2, typeof(WomanTeam))]
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
        protected string _league;
        [ProtoMember(15)]
        public string League
        {
            get => _league;
            set => _league = value ?? string.Empty;
        }
        public ManTeam() : base() { }
        public ManTeam(string name, string league) : base(name)
        {
            _name = "Man " + name;
            _league = league;
        }
    }

    [ProtoContract]
    [Serializable]
    public class WomanTeam : Team
    {
        protected string _color;
        [ProtoMember(16)]
        public string Colour
        {
            get => _color;
            set => _color = value ?? string.Empty;
        }
        public WomanTeam() : base() { }
        public WomanTeam(string name, string color) : base(name)
        {
            _name = "Woman " + name;
            _color = color;
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
            //string folder = "Teams";
            //path = Path.Combine(path, folder);
            //if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            #region 1.4
            //Sportsman[] sportsmen = new Sportsman[]
            //{
            //    new Sportsman("Central", "Cee", 2, 3),
            //    new Sportsman("Igor", "Letov", 3, 4),
            //    new Sportsman("Kirill", "Bledny", 5, 6),
            //    new Sportsman("Robert", "Voskresenskii", 7, 8),
            //    new Sportsman("Slava", "Marlow", 9, 0)
            //};

            //string folder_1 = "Sportsmen";
            //string path_1 = Path.Combine(path, folder_1);
            //if (!Directory.Exists(path_1)) Directory.CreateDirectory(path_1);
            //string[] files_1 = new string[]
            //{
            //    "sportsmen.json",
            //    "sportsmen.xml",
            //    "sportsmen.bin"
            //};
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
            Team[] teams = new Team[8];
            ManTeam[] man_teams = new ManTeam[4];
            string[] leagues =
            {
                "3rd", "2nd", "1st", "Premiere"
            };
            WomanTeam[] woman_teams = new WomanTeam[4];
            string[] colors =
            {
                "red", "green", "blue", "white"
            };
            Random random = new Random();
            int score1, score2;
            for (int i = 0; i < 4; i++)
            {
                man_teams[i] = new ManTeam("Team " + (i + 1), leagues[i]);
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
                woman_teams[i] = new WomanTeam("Team " + (i + 1), colors[i]);
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

            string folder_3 = "ManTeams";
            string folder_4 = "WomanTeams";
            string path_3 = Path.Combine(path, folder_3);
            string path_4 = Path.Combine(path, folder_4);
            if (!Directory.Exists(path_3)) Directory.CreateDirectory(path_3);
            if (!Directory.Exists(path_4)) Directory.CreateDirectory(path_4);
            string[] files_3_1 = new string[]
            {
                "manteams.json",
                "manteams.xml",
                "manteams.bin"
            };
            string[] files_3_2 = new string[]
            {
                "womanteams.json",
                "womanteams.xml",
                "womanteams.bin"
            };
            #endregion



            for (int i = 0; i < serializers.Length; i++)
            {
                serializers[i].Write<ManTeam[]>(man_teams, Path.Combine(path_3, files_3_1[i]));
                serializers[i].Write<WomanTeam[]>(woman_teams, Path.Combine(path_4, files_3_2[i]));
                //serializers[i].Write(students, Path.Combine(path_2, files_2[i]));
                //serializers[i].Write(teams, Path.Combine(path_3, files_3[i]));

            }
            for (int i = 0; i < serializers.Length; i++)
            {
                man_teams = serializers[i].Read<ManTeam[]>(Path.Combine(path_3, files_3_1[i]));
                foreach (Team team in man_teams)
                {
                    team.Print();
                }
                woman_teams = serializers[i].Read<WomanTeam[]>(Path.Combine(path_4, files_3_2[i]));
                foreach (Team team in woman_teams)
                {
                    team.Print();
                }
                //students = serializers[i].Read<Student[]>(Path.Combine(path_2, files_2[i]));
                //teams = serializers[i].Read<Team[]>(Path.Combine(path_3, files_3[i]));
            }

            Console.ReadKey();
        }

    }
}

