using System;
using System.Collections.Generic;
using System.Text.RegularExpressions; // высокий уровень (не рекомендую) класс Regex
abstract class Task
{
    protected string output = "";
    public Task(string text) { }
    protected abstract void ParseText(string text); // все разные
    protected virtual int Count() // если несколько одинаковых, а один выбивается
    {
        return -1;
    }
    protected double CountPersent(int number, int total) // все одинаковые
    {
        return Math.Round(number / (double)total * 100, 2);
    }
}

class Task_8 : Task
{
    public Task_8(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return output;
    }
    protected string CompleteLine(string line, int limit)
    {
        string[] wordsInLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int spacesNeeded = limit - line.Length;
        if (wordsInLine.Length > 1)
        {
            int spacesToAdd = spacesNeeded / (wordsInLine.Length - 1);
            int extraSpaces = spacesNeeded % (wordsInLine.Length - 1);
            for (int i = 0; i < wordsInLine.Length - 1; i++)
            {
                wordsInLine[i] += new string(' ', spacesToAdd);
                if (extraSpaces > 0)
                {
                    wordsInLine[i] += ' ';
                    extraSpaces--;
                }
            }
        }
        return string.Join(" ", wordsInLine);
    }
    protected override void ParseText(string text)
    {
        string[] words = text.Split();
        List<string> lines = new List<string>();
        string currentLine = "";
        foreach (string word in words)
        {
            if (currentLine.Length + word.Length > 50)
            {
                lines.Add(currentLine);
                currentLine = "";
            }
            currentLine += word + " ";
        }
        lines.Add(currentLine);
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].Length > 0)
            {
                output += CompleteLine(lines[i].Remove(lines[i].Length - 1), 50) + "\n";
            }
        }
    }
}
class Task_9 : Task
{
    private Dictionary<string, char> codeDict = new Dictionary<string, char>();
    public Dictionary<string, char> CodeDict
    {
        get { return codeDict; }
        protected set { codeDict = value; }
    }
    private string codedText;
    public string CodedText
    {
        get { return codedText; }
        protected set { codedText = value; }
    }
    public Task_9(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return output;
    }
    protected override void ParseText(string text)
    {
        codeDict = MakeCode(text);
        codedText = CodeText(text, codeDict);
        string codeTable = "";
        foreach (var pair in codeDict)
        {
            codeTable += pair.Key + " - " + pair.Value + "\n";
        }
        output = codedText + "\n" + codeTable;
    }
    private Dictionary<string, char> MakeCode(string text)
    {
        Dictionary<string, int> allPairs = new Dictionary<string, int>();
        Dictionary<string, char> frequentPairs = new Dictionary<string, char>();
        for (int i = 0; i < text.Length - 1; i++)
        {
            if (char.IsLetter(text[i]) && char.IsLetter(text[i + 1]))
            {
                if (!allPairs.ContainsKey(text.Substring(i, 2)))
                {
                    allPairs[text.Substring(i, 2)] = 0;
                }
                allPairs[text.Substring(i, 2)]++;
            }
        }
        char code = '÷';
        foreach (var pair in allPairs)
        {
            if (pair.Value > 1)
            {
                frequentPairs[pair.Key] = code++;
            }
        }
        return frequentPairs;
    }
    private string CodeText(string text, Dictionary<string, char> d)
    {
        foreach (var pair in d)
        {
            text = text.Replace(pair.Key, pair.Value.ToString());
        }
        return text;
    }
}
class Task_10 : Task
{
    private Dictionary<string, char> codeDict;
    public Task_10(string text, Dictionary<string, char> codeDict) : base(text)
    {
        this.codeDict = codeDict;
        ParseText(text);
    }
    public override string ToString()
    {
        return output;
    }
    protected override void ParseText(string text)
    {
        string[] keys = new string[codeDict.Count];
        int k = 0;
        foreach (var pair in codeDict)
        {
            keys[k++] = pair.Key;
        }
        Array.Reverse(keys);
        foreach (string key in keys)
        {

            text = text.Replace(codeDict[key].ToString(), key);
        }
        output = text;
    }
}
class Task_12 : Task
{
    private string input;
    public Task_12(string text, string input) : base(text)
    {
        this.input = input;
        ParseText(text);
    }
    public override string ToString()
    {
        return output;
    }
    protected override void ParseText(string text)
    {
        Dictionary<string, string> codepairs = GetCodes(input);
        foreach (var codepair in codepairs)
        {
            text = text.Replace(codepair.Key, codepair.Value);
        }
        output = text;
    }
    private Dictionary<string, string> GetCodes(string input)
    {
        Dictionary<string, string> codes = new Dictionary<string, string>();
        string[] lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string[] pair = line.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            codes[pair[0]] = pair[1];
        }
        return codes;
    }
}
class Task_13 : Task
{
    public Task_13(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return output;
    }
    protected override void ParseText(string text)
    {
        text = text.ToLower();
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', '"' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<char, double> count = new Dictionary<char, double>();
        foreach (string word in words)
        {
            char first = word[0];
            if (char.IsLetter(first))
            {
                if (!count.ContainsKey(first))
                {
                    count[first] = 0;
                }
                count[first]++;
            }
        }
        foreach (char c in count.Keys)
        {
            count[c] = CountPersent((int)count[c], words.Length);
            output += $"{c} - {count[c]}%\n";
        }
    }
}
class Task_15 : Task
{
    private double sum = 0;
    public Task_15(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return $"Сумма включенных в текст чисел - {sum}";
    }
    protected override void ParseText(string text)
    {
        string additionals = "-,";
        for (int i = 0; i < text.Length; i++)
        {
            string current = "";
            while (i < text.Length && (char.IsDigit(text[i]) || additionals.Contains(text[i]) && char.IsDigit(text[i + 1]) && !current.Contains(',')))
            {
                current += text[i];
                i++;
            }
            current = current.Replace(',', '.');
            if (current != "")
            {
                sum += double.Parse(current);
                //Console.WriteLine(sum);
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий, а также незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.";
        string text2 = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including Romeo and Juliet, Hamlet, Macbeth, and Othello, were written during the late 16th and early 17th centuries. Romeo and Juliet, a tragic tale of young love, was penned around 1595. Hamlet, one of his most celebrated tragedies, was written in the early 1600s, followed by Macbeth, a gripping drama exploring themes of ambition and power, around 1606. Othello, a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.";
        string text3 = "$g $5, $i $y $s $a ищешь свою дорогу\n" +
            "$g $5, $i $y $s $a ждёшь, когда рассеется ночь\n" +
            "$g $5, $i мир поделен на тыщи, а $y $n в ногу\n" +
            "$g $5, $i $y просто $n хочешь быть, как все, точь-в-точь...";
        string decodingTable = "$g - Дай\n" +
            "$5 - пять\n" +
            "$i - если\n" +
            "$y - ты\n" +
            "$s - все\n" +
            "$a - еще\n" +
            "$n - не\n";
        Console.WriteLine();
        string text4 = "f 5,2 aB -1 -1945";
        Task_8 task8 = new Task_8(text);
        Task_9 task9 = new Task_9(text2);
        Task_10 task10 = new Task_10(task9.CodedText, task9.CodeDict);
        Task_12 task12 = new Task_12(text3, decodingTable);
        Task_13 task13 = new Task_13(text);
        Task_15 task15 = new Task_15(text4);
        Console.WriteLine(task15);
        Console.ReadKey();
    }
}
