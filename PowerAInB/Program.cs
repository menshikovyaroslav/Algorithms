using System;

namespace PowerAInB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A");
            var aStr = Console.ReadLine();
            int.TryParse(aStr, out var a);

            Console.WriteLine("Enter B");
            var bStr = Console.ReadLine();
            int.TryParse(bStr, out var b);

            var result = 1;

            while (b > 0)
            {
                result *= a;
                b--;
            }

            Console.WriteLine($"Result = {result}");
            Console.ReadKey();
        }
    }
}
