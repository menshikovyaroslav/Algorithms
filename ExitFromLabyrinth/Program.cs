using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExitFromLabyrinth
{
    class Program
    {
        static Queue<Field> queue = new Queue<Field>();
        static void Main(string[] args)
        {
            int[,] map = new int[7, 7];
            map[4, 3] = -1;
            map[4, 4] = -1;
            map[4, 2] = -1;
            map[1, 3] = 1;
            for (int i = 0; i < 7; i++)
            {
                map[0, i] = -1;
                map[i, 0] = -1;
                map[i, 6] = -1;
                map[6, i] = -1;
            }

            queue.Enqueue(new Field(1, 3, 1));

            while (queue.Count > 0)
            {
                var field = queue.Dequeue();
                if (map[field.I - 1, field.J] == 0) queue.Enqueue(new Field(field.I - 1, field.J, field.V + 1));
                if (map[field.I, field.J + 1] == 0) queue.Enqueue(new Field(field.I, field.J + 1, field.V + 1));
                if (map[field.I + 1, field.J] == 0) queue.Enqueue(new Field(field.I + 1, field.J, field.V + 1));
                if (map[field.I, field.J - 1] == 0) queue.Enqueue(new Field(field.I, field.J - 1, field.V + 1));

                if (map[field.I, field.J] == 0) map[field.I, field.J] = field.V;
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"{map[i, j]}\t");
                }
                Console.WriteLine();
            }

            var list = new List<Field>();

            queue.Enqueue(new Field(5, 1, 7));
            while (true)
            {
                var field = queue.Dequeue();

                list.Add(field);

                if (field.V == 1) break;

                if (map[field.I - 1, field.J] == field.V - 1)
                {
                    queue.Enqueue(new Field(field.I - 1, field.J, field.V - 1));
                    continue;
                }

                if (map[field.I, field.J + 1] == field.V - 1)
                {
                    queue.Enqueue(new Field(field.I, field.J + 1, field.V - 1));
                    continue;
                }

                if (map[field.I + 1, field.J] == field.V - 1)
                {
                    queue.Enqueue(new Field(field.I + 1, field.J, field.V - 1));
                    continue;
                }

                if (map[field.I, field.J - 1] == field.V - 1)
                {
                    queue.Enqueue(new Field(field.I, field.J - 1, field.V - 1));
                    continue;
                }

            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var field = list.SingleOrDefault(el => el.I == i && el.J == j);
                    if (field == null) Console.ResetColor();
                    else Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write($"{map[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    public class Field
    {
        private int _i;
        private int _j;
        private int _v;

        public int I
        {
            get { return _i; }
            set { _i = value; }
        }

        public int J
        {
            get { return _j; }
            set { _j = value; }
        }

        public int V
        {
            get { return _v; }
            set { _v = value; }
        }

        public Field(int i, int j, int v)
        {
            I = i;
            J = j;
            V = v;
        }
    }
}
