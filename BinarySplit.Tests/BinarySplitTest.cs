using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using Xunit.Abstractions;

namespace BinarySplit.Tests
{
    public class BinarySplitTest
    {
        private readonly ITestOutputHelper output;

        public BinarySplitTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [ClassData(typeof(BinarySearchTestData))]
        public void TestRecursiveSearcher(int expected, int search, int[] array)
        {
            ISearcher searcher = new RecursiveSearcher();

            var index = searcher.FindIndex(search, array);

            index.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(BinarySearchTestData))]
        public void TestIterativeSearcher(int expected, int search, int[] array)
        {
            ISearcher searcher = new IterativeSearcher();

            var index = searcher.FindIndex(search, array);

            index.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(BinarySearchTestData))]
        public void TestFunctionalSearcher(int expected, int search, int[] array)
        {
            ISearcher searcher = new FunctionalSearcher();

            var index = searcher.FindIndex(search, array);

            index.Should().Be(expected);
        }
    }

    public class FunctionalSearcher : ISearcher
    {
        public int FindIndex(int search, int[] array)
        {
            if (array.Length == 0)
            {
                return -1;
            }

            return array.BinarySearch(search, 0);
        }
    }

    public static class ArrayExtensions
    {
        public static int BinarySearch(this int[] array, int searchFor, int startIndex)
        {
            var mid = array.Length / 2;
            var current = array[mid];

            // Check weather the element in the middle is the element we are search for
            if (current == searchFor)
            {
                return mid + startIndex;
            }

            if (array.Length == 1)
            {
                return -1;
            }

            //// If there are only two elements in the array check if the second element is the element we are searching for
            //if (array.Length == 2)
            //{
            //    if (array[1] == searchFor)
            //    {
            //        return mid + 1;
            //    }

            //    return -1;
            //}

            if (current > searchFor)
            {
                return array
                    .Split(0, mid - 1)
                    .BinarySearch(searchFor, startIndex);
            }
            else
            {
                return array.Split(mid, array.Length -1).BinarySearch(searchFor, mid);
            }
        }

        public static int[] Split(this int[] array, int left, int right)
        {
            var length = right - left + 1;
            var newArray = new int[length];
            int newIndex = 0;
            for (int i = left; i <= right; i++)
            {
                newArray[newIndex] = array[i];
                newIndex++;
            }

            return newArray;
        }
    }
}
