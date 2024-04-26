using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    abstract class Task
    {
        protected string text;
        protected string Text
        {
            get { return text; }
            private set { text = value; }
        }
        public Task(string text)
        {
            this.text = text;
        }
        protected virtual void ParseText()
        {

        }
    }
    class Task1 : Task
    {
        protected char letter;
        public char Letter
        {
            get { return letter; }
            protected  set { letter = value; }
        }
        public Task1(string text) : base(text)
        {

        }
        protected override void ParseText()
        {
            text = text.ToLower();
            string rusDict = "абвгдеёжзиклмнопрстуфхцчшщъыьэюя";
            string engDict = "abcdefghijklmnopqrstuvwxyz";
            int[] rusCounter = new int[33];
            int[] engCounter = new int[26];
            int letterCount = 0;
            foreach (char c in text)
            {
                if (rusDict.Contains(c))
                {
                    rusCounter[c - 'а']++;
                }
                else if (engDict.Contains(c))
                {
                    engCounter[c - 'a']++;
                }
            }
            for (int i = 0; i < rusCounter.Length; i++)
            {
                if (rusCounter[i] > letterCount)
                {
                    letterCount = rusCounter[i];
                    letter = Convert.ToChar(i + 'а');
                }
                if (i < 26 && engCounter[i] > letterCount)
                {
                    letterCount = engCounter[i];
                    letter = Convert.ToChar(i + 'a');
                }
            }
        }
        public override string ToString()
        {
            ParseText();
            return letter.ToString();
        }
    }
    class Task2 : Task
    {
        public Task2(string text) : base(text)
        {

        }
        protected override void ParseText()
        {
            string lower = "абвгдеёжзиклмнопрстуфхцчшщъыьэюя";
            string upper = lower.ToUpper();
            for (int i = 0; i < text.Length; i++)
            {
                if (lower.Contains(text[i]))
                {
                    if (text[i] - 'а' < 24)
                    {
                        text = text.Remove(i, 1).Insert(i, Convert.ToChar(text[i] + 9).ToString());
                    }
                    else
                    {
                        text = text.Remove(i, 1).Insert(i, Convert.ToChar(text[i] - 23).ToString());
                    }
                }
                else if (upper.Contains(text[i]))
                {
                    if (text[i] - 'А' < 24)
                    {
                        text = text.Remove(i, 1).Insert(i, Convert.ToChar(text[i] + 9).ToString());
                    }
                    else
                    {
                        text = text.Remove(i, 1).Insert(i, Convert.ToChar(text[i] - 23).ToString());
                    }
                }
            }
        }
        public override string ToString()
        {
            ParseText();
            return text;
        }
    }
    class JsonIO
    {
        public static void Write<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, obj);
            }
        }
        public static T Read<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(fs);
            }
            return default(T);
        }
    }
    class Program
    {
        static void Main()
        {
            string text = "Введите текст для теста";
            Task[] tasks = {
            new Task1(text),
            new Task2(text)
            };
            Console.WriteLine(tasks[0]);
            Console.WriteLine(tasks[1]);

            string path = @"C:\Users\m2311203\Desktop";
            string folderName = "Control work";
            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName1 = "cw-2_task-1.json";
            string fileName2 = "cw_2_task-2.json";

            fileName1 = Path.Combine(path, fileName1);
            fileName2 = Path.Combine(path, fileName2);
            if (!File.Exists(fileName1))
            {
                JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
            }
            else
            {
                var t1 = JsonIO.Read<Task2>(fileName1);
                Console.WriteLine(t1);
            }
            if (!File.Exists(fileName2))
            {
                JsonIO.Write<Task2>(tasks[1] as Task2, fileName2);
            }
            else
            {
                var t2 = JsonIO.Read<Task2>(fileName2);
                Console.WriteLine(t2);
            }
            Console.ReadKey();
        }
    }
}
