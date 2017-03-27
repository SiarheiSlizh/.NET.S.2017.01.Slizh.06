using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// This class works with stepped arrays.
    /// </summary>
    public static class SteppedArray
    {
        /// <summary>
        /// Method sorts stepped array in order by sum of row's elements ascending.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        public static void BubbleSortOrderBySumRowsAsc(int[][] arr)
        {
            ArgExcecption(arr);
            for (int i = 1; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1; j++) 
                    if (arr[i].Sum() < arr[j].Sum())
                        Replace(ref arr[i], ref arr[j]);
        }

        /// <summary>
        /// Method sorts stepped array in order by sum of row's elements descending.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        public static void BubbleSortOrderBySumRowsDesc(int[][] arr)
        {
            ArgExcecption(arr);
            BubbleSortOrderBySumRowsAsc(arr);
            arr.Reverse();
        }

        /// <summary>
        /// Method sorts stepped array in order by max elemets in row ascending.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        public static void BubbleSortOrderByMaxElemInRowAsc(int[][] arr)
        {
            ArgExcecption(arr);
            for (int i = 1; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1; j++)
                    if (arr[i].Max() < arr[j].Max())
                        Replace(ref arr[i], ref arr[j]);
        }

        /// <summary>
        /// Method sorts stepped array in order by max elemets in row descending.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        public static void BubbleSortOrderByMaxElemInRowDesc(int[][] arr)
        {
            ArgExcecption(arr);
            BubbleSortOrderByMaxElemInRowAsc(arr);
            arr.Reverse();
        }

        /// <summary>
        /// Method sorts stepped array in order by min elemets in row ascending.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        public static void BubbleSortOrderByMinElemInRowAsc(int[][] arr)
        {
            ArgExcecption(arr);
            for (int i = 1; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1; j++)
                    if (arr[i].Min() < arr[j].Min())
                        Replace(ref arr[i], ref arr[j]);
        }

        /// <summary>
        /// Method sorts stepped array in order by max elemets in row descending.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        public static void BubbleSortOrderByMinElemInRowDesc(int[][] arr)
        {
            ArgExcecption(arr);
            BubbleSortOrderByMinElemInRowAsc(arr);
            arr.Reverse();
        }

        /// <summary>
        /// Method checks data on validity.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        private static void ArgExcecption(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentException();
            foreach (int[] subArr in arr)
                if (subArr == null)
                    throw new ArgumentException();
        }

        /// <summary>
        /// Method replaces two array's references.
        /// </summary>
        /// <param name="arr1">Dimensional array.</param>
        /// <param name="arr2">Dimensional array.</param>
        private static void Replace(ref int[] arr1, ref int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}