using FluentAssertions;
using Xunit;

namespace BinarySplit.Tests
{
    public class ArraySplitTests
    {
        [Theory]
        [InlineData(0, 2, new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(0, 1, new[] { 1, 2 }, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(0, 0, new[] { 1 }, new[] { 1, 2, 3, 4, 5 })]
        public void TestArraySplit(int start, int end, int[] expected, int[] source)
        {
            var actual = source.Split(start, end);

            actual.Should().Equal(expected);
        }
    }
}
