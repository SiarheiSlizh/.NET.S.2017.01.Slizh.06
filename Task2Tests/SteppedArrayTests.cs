using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace Task2Tests
{
    [TestFixture]
    public class SteppedArrayTests
    {
        private int[][] arrData;

        private int[][] ArrData
        {
            get
            {
                arrData = new int[][] 
                {
                    new int[] { 4, 7, -15, 2 },
                    new int[] { -12, 5, -2, 4 },
                    new int[] { 32, 11, -6, 4 },
                    new int[] { 23, -17, 5, 2, -5, 11 },
                    new int[] {-10, 32, 22, -19, 7, 5, 2 , -9}
                };
                return arrData;
            }
        }

        [TestCase(null)]
        public void SteppedArray_ArgumentException(int[][] arr)
        {
            Assert.Throws<ArgumentException>(() => SteppedArray.BubbleSortOrderByMaxElemInRowAsc(arr));
        }
    }
}
