using System;
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
    }

    public interface ISearcher
    {
        int FindIndex(int search, int[] array);
    }

    public class IterativeSearcher : ISearcher
    {
        public int FindIndex(int search, int[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            int middle = (right - left) / 2 + left;

            var value = array[middle];
            if (value == search)
            {
                return middle;
            }

            return -1;
        }
    }
}
