using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SteppedArrayViceVersa
    {
        /// <summary>
        /// Method sorts stepped array using Bubble method.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        /// <param name="criterion">object that implements the interface IComparer.</param>
        public static void BubbleSort(int[][] arr, IComparer criterion)
        {
            ArgExcecption(arr);
            BubbleSort(arr, criterion.Compare);   
        }

        /// <summary>
        /// Method sorts stepped array using Bubble method.
        /// </summary>
        /// <param name="arr">Stepped array.</param>
        /// <param name="criterion">Delegate that accepts method with corresponding parameters.</param>
        private static void BubbleSort(int[][] arr, Func<int[], int[], bool> criterion)
        {
            ArgExcecption(arr);
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (criterion(arr[i], arr[j]))
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