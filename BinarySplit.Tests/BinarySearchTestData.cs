﻿using Xunit;

namespace BinarySplit.Tests
{
    public class BinarySearchTestData : TheoryData<int, int, int[]>
    {
        public BinarySearchTestData()
        {
            Add(-1, 3, new int[0]);
            Add(-1, 3, new int[] { 1 });
            Add(0, 1, new int[] { 1 });
            Add(0, 1, new int[] { 1, 3, 5 });
            Add(1, 3, new int[] { 1, 3, 5 });
            Add(2, 5, new int[] { 1, 3, 5 });
            Add(-1, 0, new int[] { 1, 3, 5 });
            Add(-1, 2, new int[] { 1, 3, 5 });
            Add(-1, 4, new int[] { 1, 3, 5 });
            Add(-1, 6, new int[] { 1, 3, 5 });
            Add(0, 1, new int[] { 1, 3, 5, 7 });
            Add(1, 3, new int[] { 1, 3, 5, 7 });
            Add(2, 5, new int[] { 1, 3, 5, 7 });
            Add(3, 7, new int[] { 1, 3, 5, 7 });
            Add(-1, 0, new int[] { 1, 3, 5, 7 });
            Add(-1, 2, new int[] { 1, 3, 5, 7 });
            Add(-1, 4, new int[] { 1, 3, 5, 7 });
            Add(-1, 6, new int[] { 1, 3, 5, 7 });
            Add(-1, 8, new int[] { 1, 3, 5, 7 });
        }
    }
}