using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class SteppedArray
    {
        public static void BubbleSortOrderBySumRowsAsc(int[][] arr)
        {
            ArgExcecption(arr);
            for (int i = 1; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1; j++) 
                    if (arr[i].Sum() < arr[j].Sum())
                    {
                        Replace(arr[i], arr[j]);
                    }
        }

        public static void BubbleSortOrderBySumRowsDesc(int[][] arr)
        {
            ArgExcecption(arr);
            BubbleSortOrderBySumRowsAsc(arr);
            arr.Reverse();
        }

        public static void BubbleSortOrderByMaxElemInRowAsc(int[][] arr)
        {
            ArgExcecption(arr);
            for (int i = 1; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1; j++)
                    if (arr[i].Max() < arr[j].Max())
                    {
                        Replace(arr[i], arr[j]);
                    }
        }

        public static void BubbleSortOrderByMaxElemInRowDesc(int[][] arr)
        {
            ArgExcecption(arr);
            BubbleSortOrderByMaxElemInRowAsc(arr);
            arr.Reverse();
        }


        public static void BubbleSortOrderByMinElemInRowAsc(int[][] arr)
        {
            ArgExcecption(arr);
            for (int i = 1; i < arr.Length; i++)
                for (int j = 0; j < arr.Length - 1; j++)
                    if (arr[i].Min() < arr[j].Min())
                    {
                        Replace(arr[i], arr[j]);
                    }
        }

        public static void BubbleSortOrderByMinElemInRowDesc(int[][] arr)
        {
            ArgExcecption(arr);
            BubbleSortOrderByMinElemInRowAsc(arr);
            arr.Reverse();
        }

        private static void ArgExcecption(int[][] arr)
        {
            if (arr == null)
                throw new ArgumentException();
        }

        private static void Replace(int[] arr1, int[] arr2)
        {
            int[] temp = arr1;
            arr1 = arr2;
            arr2 = temp;
        }
    }
}