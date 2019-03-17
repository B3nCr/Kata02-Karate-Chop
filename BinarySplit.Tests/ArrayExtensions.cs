namespace BinarySplit.Tests
{
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

            if (current > searchFor)
            {
                return array
                    .Split(0, mid - 1)
                    .BinarySearch(searchFor, startIndex);
            }

            return array.Split(mid, array.Length -1).BinarySearch(searchFor, mid);
        }

        public static int[] Split(this int[] array, int left, int right)
        {
            var length = right - left + 1;
            var newArray = new int[length];
            var newIndex = 0;

            for (var i = left; i <= right; i++)
            {
                newArray[newIndex] = array[i];
                newIndex++;
            }

            return newArray;
        }
    }
}