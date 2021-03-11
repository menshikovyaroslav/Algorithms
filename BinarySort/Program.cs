using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10] { 1, 3, 4, 7, 15, 25, 26, 27, 33, 50 };
            var search = 28;

            var l = 0;
            var r = array.Length - 1;
            var m = 0;

            while (l < r)
            {
                m = (l + r) / 2;
                if (array[m] == search) break;

                if (search < array[m]) r = m - 1;
                else l = m + 1;
            }
            if (array[m] == search) Console.WriteLine($"i = {m}");
            else Console.WriteLine($"Not found");


            Console.ReadKey();
        }


    }
}
