using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public static class BinarySearch
    {
        public static int DoBinarySearch(int[] arr, int start, int end, int x)
        {
            //Binary Search using recursive method

            if (end >= start)
            {
                int mid = start + (end - start) / 2;

                if (arr[mid] == x)
                {
                    return mid; 
                }

                if (arr[mid] > x)
                {
                    return DoBinarySearch(arr, start, mid - 1, x);
                }

                return DoBinarySearch(arr, mid + 1, end, x);

            }

            return -1;

        }

        public static int DoBinarySearch(int[] arr, int x)
        {
            //Binary Search using while loop

            int start = 0, end = arr.Length - 1;

            while (end >= start)
            {
                int mid = start + (end - start) / 2;

                if (x > arr[mid])
                {
                    start = mid + 1;
                }

                else if (x < arr[mid])
                {
                    end = mid - 1;
                }

                else
                { 
                    return mid;
                }

            }

            return -1;

        }

        public static int DoBinarySearch<T>(T[] arr, T x)
            where T : IComparable<T>
        {
            //Binary Search using generic type

            int start = 0, end = arr.Length - 1;

            while (end >= start)
            {
                int mid = start + (end - start) / 2;
                int result = x.CompareTo(arr[mid]);

                if (result > 0)
                { 
                    start = mid + 1;
                }

                else if (result < 0)
                { 
                    end = mid - 1;
                }

                else
                { 
                    return mid; 
                }

            }

            return -1;

        }
        public static int DoBinarySearch<T>(T[] arr, T x, Func<T, T, bool> compare)
        {
            //Binary Search using lambda expression

            int start = 0, end = arr.Length - 1;

            while (end >= start)
            {
                int mid = start + (end - start) / 2;
                bool result = compare(x, arr[mid]);

                if (result)
                {
                    start = mid + 1;
                }

                else if (result)
                {
                    end = mid - 1;
                }

                else
                { 
                    return mid; 
                }

            }

            return -1;

        }
    }
}
