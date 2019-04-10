using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class SearchClass
    {
        public long counter;

        public long SimpleSearch(int[] arr, int number)
        {
            for(long i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number) return i;
            }
            return -1;
        }

        public long SimpleSearchWithCounter(int[] arr, int number)
        {
            this.counter = 0;
            for (long i = 0; i < arr.Length; i++)
            {
                this.counter++;
                if (arr[i] == number) return i;
            }
            return -1;
        }

        public long BinarySearch(int[] arr, int number)
        {
            int left = 0, right = arr.Length - 1, middle;
            while (left <= right)
            {
                middle = (left + right) / 2;
                if (arr[middle] < number)
                    left = middle + 1;
                else if (arr[middle] > number)
                    right = middle - 1;
                else
                    return middle;
            }
            return -1;
        }

        public long BinarySearchWithCounter(int[] arr, int number)
        {
            this.counter = 0;
            int left = 0, right = arr.Length - 1, middle;
            while (left <= right)
            {
                this.counter++;
                middle = (left + right) / 2;
                if (arr[middle] < number)
                    left = middle + 1;
                else if (arr[middle] > number)
                    right = middle - 1;
                else
                    return middle;
            }
            return -1;
        }
    }
}
