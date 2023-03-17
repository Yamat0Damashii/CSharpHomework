using System.Text.RegularExpressions;


namespace Homework3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите строку для 1 задания");
            string s1=Console.ReadLine();
            string[] ans1 = RusNumArr(s1);
            foreach (var x in ans1) 
                Console.WriteLine(x+" ");
            Console.WriteLine("Введите строку для 2 задания");
            string s2 = Console.ReadLine();
            Console.WriteLine(StarChange(s2));
            Console.WriteLine("Примеры валидируемых строк в 3 задании");
            foreach (var x in  YaTebyaPoAypiVIchesly("0.0.0.0 252.180.199.200 169.228.64.100"))
                Console.WriteLine(x+" ");
            Console.WriteLine("Введите строку для 4 задания");
            string s4=Console.ReadLine();
            Console.WriteLine(WordsSplit(s4));
            Console.WriteLine("Введите строку для 5 задания");
            string s5=Console.ReadLine();
            PrintInfoLength(s5);

        }
        /// <summary>
        /// Находит все номера машин в строке и возвращает массив из них
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string[] RusNumArr(string s) => Regex.Matches(s, @"\b[АВЕКМНОРСТУХ]{1}[0-9]{3}[АВЕКМНОРСТУХ]{2}[0-9]{1,3} ").Select(x=>x.ToString()).ToArray();
        /// <summary>
        /// Текст обрамлённый в звёздочки обрамляет тэгом <em></em>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string StarChange(string s) => Regex.Replace(s, @"((?<!\*[*])([\w\s]+)([*](?!\*)))", @"<em>$2</em>");
        /// <summary>
        /// Находит IP-адресс
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string YaTebyaPoAypiVIchesly(string s) => Regex.Match(s, @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b").ToString();
        /// <summary>
        /// Разделяет слова, начинающиеся с больших букв пробелами
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string WordsSplit(string s) => Regex.Replace(s, @"(\w(?=[A-Z]))", @"$1 ");
        
        static void PrintInfoLength(string s)
        {
            foreach (Match x in Regex.Matches(s, @"(?<name>(?<=\@\w+(?=\=))=(?<info>\(.*?\))"))
                Console.WriteLine($"{x.Groups["name"]} => {x.Groups["info"].Length}");
        }
    }
}