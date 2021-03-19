using System;
using System.Collections.Generic;
using System.Linq;

namespace CountDoubleChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Aaz9kldkaaaaaaaaaakd";
            var count = GetCountDoubleChar2(str);
            Console.WriteLine(count);
            Console.ReadKey();
        }

        static int GetCountDoubleChar(string str)
        {
            str = str.ToUpper();

            var dict = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                if (dict.ContainsKey(ch)) dict[ch]++;
                else dict[ch] = 1;
            }

            var count = dict.Where(el => el.Value > 1).Count();
            return count;
        }

        static int GetCountDoubleChar2(string str)
        {
            str = str.ToUpper();

            int[] arr = new int[91];

            int result = 0;

            // A = 65, Z = 90, 0 = 48, 9 = 57

            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                var code = (int)ch;
                arr[code]++;
            }

            foreach (var item in arr)
            {
                if (item > 1) result++;
            }

            return result;
        }
    }
}
