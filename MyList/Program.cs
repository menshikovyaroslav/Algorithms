using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList(5);

            list[3] = 10;

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();   
        }
    }

    public class MyList : IEnumerable
    {
        int[] array;

        public MyList(int size)
        {
            array = new int[size];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(array);
        }
    }

    public class MyEnumerator : IEnumerator<int>
    {
        int[] array;
        int position = -1;

        public MyEnumerator(int[] arr)
        {
            array = arr;
        }

        public int Current
        {
            get
            {
                if (position == -1 || position >= array.Length) throw new InvalidOperationException();
                return array[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (position < array.Length - 1)
            {
                position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
