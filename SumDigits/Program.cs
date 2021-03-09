using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 123;
            var result = 0;

            while (num > 0)
            {
                result += num % 10;
                num /= 10;
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
