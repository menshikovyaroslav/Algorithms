using System;

namespace SearchStringInString
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "wor";
            var s2 = "hellwor wodld";

            int i, j;

            var m = s1.Length;
            var n = s2.Length;

            for (i = 0; i < n - m; i++)
            {
                j = 0;
                while (j < m && s2[i + j] == s1[j])
                    j++;
                if (j == m) break;
            }
        }
    }
}
