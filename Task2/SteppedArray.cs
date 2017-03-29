using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Interface which is used to compare two arrays.
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// This method compare two arrays.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns></returns>
        bool Compare(int[] arr1, int[] arr2);
    }

    /// <summary>
    /// This class works with stepped arrays.
    /// </summary>
    public static class SteppedArray
    {
        /// <summary>
        /// Method sorts stepped array using Bubble method.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        public static void BubbleSort(int[][] arr, IComparer criterion)
        {
            ArgExcecption(arr);
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (criterion.Compare(arr[i], arr[j])) 
                        Replace(ref arr[i], ref arr[j]);
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