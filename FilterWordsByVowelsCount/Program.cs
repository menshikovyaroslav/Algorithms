using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterWordsByVowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FilterByVowelsCount("fsooooooodfsdoio", "treiiodaa");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        static string FilterByVowelsCount(params string[] strings)
        {
            var chars = new List<char>("aeiouyAEIOUY");

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < strings.Length; i++)
            {
                var count = 0;
                foreach (var ch in strings[i])
                {
                    if (chars.Contains(ch)) count++;
                }
                dict[strings[i]] = count;
            }

            var result = String.Empty;

            var sorted = dict.OrderBy(s => s.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in sorted)
            {
                if (!string.IsNullOrEmpty(result)) result += " ";
                result += item.Key;
            }

            return result;
        }
    }
}
