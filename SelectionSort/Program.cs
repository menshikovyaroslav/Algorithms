using System;
using Methods;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10] { 3, 5, 8, 0, 1, 9, 7, 2, 4, 6 };

            for (int i = 0; i < array.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min]) min = j;
                }
                array.Swap3(min, i);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.ReadKey();
        }
    }
}
