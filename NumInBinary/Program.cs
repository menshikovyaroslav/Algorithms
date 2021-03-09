using System;

namespace NumInBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 23;
            var result = "";

            while (num > 0)
            {
                result += num % 2;
                num /= 2;
            }

            for (int i = result.Length - 1; i >= 0; i--)
            {
                Console.Write($"{result[i]}");
            }

            Console.ReadKey();
        }
    }
}
