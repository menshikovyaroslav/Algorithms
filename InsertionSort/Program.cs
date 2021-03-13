using System;
using Methods;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10] { 3, 5, 8, 0, 1, 9, 7, 2, 4, 6 };

            for (int i = 1; i < array.Length; i++)
            {
                var j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    array.Swap3(j, j - 1);
                    j--;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.ReadKey();
        }
    }
}
