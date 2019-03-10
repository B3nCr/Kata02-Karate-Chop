using System;
using Xunit;
using FluentAssertions;

namespace BinarySplit.Tests
{
    public class BinarySplitTest
    {
        [Fact]
        public void CanAdd()
        {
            var splitter = new BinarySpliter();
            var index = splitter.chop(1, new[] { 1, 2, 3, 4, 5, 6 });
            index.Should().Be(1);
        }
    }

    internal class BinarySpliter
    {
        public int chop(int valueToFind, int[] array)
        {
            return -1;
        }
    }
}
