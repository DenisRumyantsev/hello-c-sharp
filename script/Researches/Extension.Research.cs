using System;

namespace Research
{
    public class Human
    {
        public string FirstName;
        public string LastName;
        public Human(string first, string last) { FirstName = first; LastName = last; }
    }

    static class Ext
    {
        public static int WordCount(this string str) => str.Split(
            new char[] { ' ', '.', ',', ':', ';', '?', '!' },
            StringSplitOptions.RemoveEmptyEntries
        ).Length;

        public static string FullName(this Human value) => $"{value.FirstName} {value.LastName}";
    }

    class ExtensionResearch
    {
        public static void Research()
        {
            string str = "Hello Extension Methods";
            int num = str.WordCount();
            Console.WriteLine($"String :: \"{str}\" - - - Words :: \"{num}\"");

            var man = new Human("Victor", "Marchenko");
            Console.WriteLine($"FullName :: {man.FullName()}");
        }
    }
}
