using System;

namespace Methods
{
    public static class ArrayExtensions
    {
        public static void Swap2(this int[] array, int i1, int i2)
        {
            array[i1] *= array[i2];
            array[i2] = array[i1] / array[i2];
            array[i1] /= array[i2];
        }

        public static bool Swap3(this int[] array, int i1, int i2)
        {
            var temp = array[i1];
            array[i1] = array[i2];
            array[i2] = temp;

            return true;
        }
    }
}
