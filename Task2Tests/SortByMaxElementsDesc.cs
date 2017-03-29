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
    class SortByMaxElementsDesc: IComparer
    {
        /// <summary>
        /// Method compares two arrays by max elements in order by descending.
        /// </summary>
        /// <param name="arr1">Array of elements.</param>
        /// <param name="arr2">Array of elements.</param>
        /// <returns>True if max element in arr1 is less than in arr2 else false.</returns>
        public bool Compare(int[] arr1, int[] arr2)
        {
            if (arr1.Max() < arr2.Max())
                return true;
            else return false;
        }
    }
}
