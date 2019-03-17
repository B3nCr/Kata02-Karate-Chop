namespace BinarySplit.Tests
{
    public class IterativeSearcher : ISearcher
    {
        public int FindIndex(int search, int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (right - left) / 2 + left;

                var value = array[middle];
                if (value == search)
                {
                    return middle;
                }

                if (value < search)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}