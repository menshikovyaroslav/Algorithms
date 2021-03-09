using Methods;
using System;

namespace Bubble
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10] { 3, 5, 8, 0, 1, 9, 7, 2, 4, 6 };

            while (true)
            {
                bool wasSwaps = false;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < array[i - 1])
                    {
                        array.Swap3(i, i - 1);
                        wasSwaps = true;
                    }
                }

                if (!wasSwaps) break;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.ReadKey();
        }
    }
}
