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
            IComparer criterion = null;
            Assert.Throws<ArgumentException>(() => SteppedArray.BubbleSort(arr, criterion));
        }

        [Test]
        public void ArgException_ArgumentException()
        {
            int[][] actual = new int[][]
                {
                    new int[] { 3, 2, 1 },
                    null,
                    new int[] { 1 }
                };
            IComparer criterion = new SortBySumElementsAsc();
            Assert.Throws<ArgumentException>(() => SteppedArray.BubbleSort(actual, criterion));
        }

        [Test]
        public void BubbleSortOrderBySumRowsAsc_PositiveTests()
        {
            int[][] actual = ArrData;
            int[][] expected = new int[][]
                {
                    new int[] { -12, 5, -2, 4 },
                    new int[] { 4, 7, -15, 2 },
                    new int[] { 23, -17, 5, 2, -5, 11 },
                    new int[] {-10, 32, 22, -19, 7, 5, 2 , -9},
                    new int[] { 32, 11, -6, 4 }
                };
            IComparer criterion = new SortBySumElementsAsc();
            SteppedArray.BubbleSort(actual, criterion);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSortOrderBySumRowsDesc_PositiveTests()
        {
            int[][] actual = ArrData;
            int[][] expected = new int[][]
                {
                    new int[] { 32, 11, -6, 4 },
                    new int[] {-10, 32, 22, -19, 7, 5, 2 , -9},
                    new int[] { 23, -17, 5, 2, -5, 11 },
                    new int[] { 4, 7, -15, 2 },
                    new int[] { -12, 5, -2, 4 }
                };
            IComparer criterion = new SortBySumElementsDesc();
            SteppedArray.BubbleSort(actual, criterion);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSortOrderByMaxElemInRowAsc_PositiveTests()
        {
            int[][] actual = ArrData;
            int[][] expected = new int[][]
                {
                    new int[] { -12, 5, -2, 4 },
                    new int[] { 4, 7, -15, 2 },
                    new int[] { 23, -17, 5, 2, -5, 11 },
                    new int[] { 32, 11, -6, 4 },
                    new int[] {-10, 32, 22, -19, 7, 5, 2 , -9}
                };
            IComparer criterion = new SortByMaxElementsAsc();
            SteppedArray.BubbleSort(actual, criterion);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSortOrderByMaxElemInRowDesc_PositiveTests()
        {
            int[][] actual = ArrData;
            int[][] expected = new int[][]
                {
                    new int[] { 32, 11, -6, 4 },
                    new int[] {-10, 32, 22, -19, 7, 5, 2 , -9},
                    new int[] { 23, -17, 5, 2, -5, 11 },
                    new int[] { 4, 7, -15, 2 },
                    new int[] { -12, 5, -2, 4 }
                };
            IComparer criterion = new SortByMaxElementsDesc();
            SteppedArray.BubbleSort(actual, criterion);
            Assert.AreEqual(actual, expected);
        }
    }
}
