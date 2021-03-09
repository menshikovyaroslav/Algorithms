using System;

namespace ReverseNum
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 123;
            var result = 0;

            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
