namespace BinarySplit.Tests
{
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
}