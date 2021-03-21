using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<object>();

            list.Add(5);
            list.Add("7");
            list.Add(2);

            list[2] = "x";

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();   
        }
    }

    public class MyList<T> : IEnumerable
    {
        T[] array;

        public MyList()
        {
            array = new T[0];
        }

        public T this[int index]
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
            return new MyEnumerator<T>(array);
        }

        public void Add(T element)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = element;
        }
    }

    public class MyEnumerator<T> : IEnumerator<T>
    {
        T[] array;
        int position = -1;

        public MyEnumerator(T[] arr)
        {
            array = arr;
        }

        public T Current
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
