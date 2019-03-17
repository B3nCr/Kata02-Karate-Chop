namespace BinarySplit.Tests
{
    internal class RecursiveSearcher : ISearcher
    {
        public int FindIndex(int valueToFind, int[] array)
        {
            return Split(valueToFind, array, 0, array.Length - 1);
        }

        private int Split(int valueToFind, int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
            {
                return -1;
            }

            var middleIndex = (rightIndex - leftIndex) / 2 + leftIndex;

            var value = array[middleIndex];
            if (value == valueToFind)
            {
                return middleIndex;
            }

            if (value < valueToFind)
            {
                return Split(valueToFind, array, middleIndex + 1, rightIndex);
            }

            if (value > valueToFind)
            {
                return Split(valueToFind, array, leftIndex, middleIndex - 1);
            }

            return -1;
        }
    }
}