using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2Tests
{
    /// <summary>
    /// This class uses criterion for comparing two arrays.
    /// </summary>
    class SortByMaxElementsAsc : IComparer<int[]>
    {
        /// <summary>
        /// Method compares two arrays by max elements in order by ascending.
        /// </summary>
        /// <param name="arr1">Array of elements.</param>
        /// <param name="arr2">Array of elements.</param>
        /// <returns>1 if max element in arr1 is bigger than in arr2 else -1.</returns>
        int IComparer<int[]>.Compare(int[] arr1, int[] arr2)
        {
            if (arr1.Max() > arr2.Max())
                return 1;
            else return -1;
        }
    }
}
