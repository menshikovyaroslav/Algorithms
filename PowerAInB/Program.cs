using System;

namespace PowerAInB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A");
            var aStr = Console.ReadLine();
            var a = int.Parse(aStr);

            Console.WriteLine("Enter B");
            var bStr = Console.ReadLine();
            var b = int.Parse(bStr);

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
