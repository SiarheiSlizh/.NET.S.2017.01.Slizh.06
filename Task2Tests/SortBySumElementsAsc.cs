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
    class SortBySumElementsAsc : IComparer
    {
        /// <summary>
        /// Method compares two arrays by sum elements in order by descending.
        /// </summary>
        /// <param name="arr1">Array of elements.</param>
        /// <param name="arr2">Array of elements.</param>
        /// <returns>True if sum elements of arr1 is bigger than arr2 else false.</returns>
        public bool Compare(int[] arr1, int[] arr2)
        {
            if (arr1.Sum() > arr2.Sum())
                return true;
            else return false;
        }
    }
}
