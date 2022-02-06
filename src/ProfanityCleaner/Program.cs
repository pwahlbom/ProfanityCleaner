using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfanityCleaner
{
    public static class StringExtensions
    {
        public static string Replace(this string originalString, string oldValue, string newValue, StringComparison comparisonType)
        {
            int startIndex = 0;
            while (true)
            {
                startIndex = originalString.IndexOf(oldValue, startIndex, comparisonType);
                if (startIndex == -1)
                    break;

                originalString = originalString.Substring(0, startIndex) + newValue + originalString.Substring(startIndex + oldValue.Length);

                startIndex += newValue.Length;
            }

            return originalString;
        }

    }

    class ProfanityCatalog
    {
        public Dictionary<string, string> Profanity { get; set; }

        public ProfanityCatalog()
        {
            Profanity = new Dictionary<string, string>();

            Profanity.Add("darn", "d**n");
            Profanity.Add("gosh", "g**h");
            Profanity.Add("yuck", "y**k");
        }

        public string Lookup(string Word)
        {
            return Profanity[Word];
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var myVar = new ProfanityCatalog();
            //Console.WriteLine(myVar.Lookup("gosh"));
            //Console.ReadLine();

            Console.WriteLine("Give me a profanity riddled sentence to clean : ");
            var strSentence = Console.ReadLine();
            var strCleanedSentence = strSentence;

            foreach (var value in myVar.Profanity.Keys)
            {
                //strCleanedSentence = strCleanedSentence.Replace(value,myVar.Profanity[value]);
                strCleanedSentence = StringExtensions.Replace(strCleanedSentence, value, myVar.Profanity[value], StringComparison.CurrentCultureIgnoreCase);
            }

            Console.WriteLine();
            Console.WriteLine("Here it is cleaned : ");
            Console.WriteLine(strCleanedSentence);
            Console.ReadLine();

        }
    }
}
