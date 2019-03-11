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
        [InlineData(-1, 3, new int[0])]
        [InlineData(-1, 3, new int[] { 1 })]
        [InlineData(0, 1, new int[] { 1 })]
        [InlineData(0, 1, new int[] { 1, 3, 5 })]
        [InlineData(1, 3, new int[] { 1, 3, 5 })]
        [InlineData(2, 5, new int[] { 1, 3, 5 })]
        //   assert_equal(2,  chop(5, [1, 3, 5]))
        //   assert_equal(-1, chop(0, [1, 3, 5]))
        //   assert_equal(-1, chop(2, [1, 3, 5]))
        //   assert_equal(-1, chop(4, [1, 3, 5]))
        //   assert_equal(-1, chop(6, [1, 3, 5]))
        //   assert_equal(0,  chop(1, [1, 3, 5, 7]))
        //   assert_equal(1,  chop(3, [1, 3, 5, 7]))
        //   assert_equal(2,  chop(5, [1, 3, 5, 7]))
        //   assert_equal(3,  chop(7, [1, 3, 5, 7]))
        //   assert_equal(-1, chop(0, [1, 3, 5, 7]))
        //   assert_equal(-1, chop(2, [1, 3, 5, 7]))
        //   assert_equal(-1, chop(4, [1, 3, 5, 7]))
        //   assert_equal(-1, chop(6, [1, 3, 5, 7]))
        //   assert_equal(-1, chop(8, [1, 3, 5, 7]))
        public void CanAdd(int expected, int search, int[] array)
        {
            var splitter = new BinarySplitter(this.output);

            var index = splitter.chop(search, array);

            index.Should().Be(expected);
        }
    }

    internal class BinarySplitter
    {
        private readonly ITestOutputHelper output;

        public BinarySplitter(ITestOutputHelper output)
        {
            this.output = output;
        }

        public int chop(int valueToFind, int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            if (array.Length == 1)
            {
                if (array[0] == valueToFind)
                {
                    return 0;
                }

                return -1;
            }

            var leftIndex = 0;
            var length = array.Length;
            var middleIndex = length / 2;
            var value = array[middleIndex];
            if (value == valueToFind)
            {
                return middleIndex;
            }

            if (value > valueToFind)
            {
                length = middleIndex;
                middleIndex = length / 2;
                value = array[middleIndex];
                if (value == valueToFind)
                {
                    return middleIndex;
                }
            }
            else
            {
                leftIndex = middleIndex;
                length = length - middleIndex + 1;
                middleIndex = length / 2 + middleIndex;
                output.WriteLine($"{middleIndex}");
                value = array[middleIndex];
                if (value == valueToFind)
                {
                    return middleIndex;
                }
            }

            return -1;
        }
    }
}
