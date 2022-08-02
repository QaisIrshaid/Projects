using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class prog
    {
        public static void Main(String[] args)
        {
            // Console.WriteLine(Sum(-1, 5));

            // bt.PreOrder(bt.root);
            //Console.WriteLine("");
            // Console.WriteLine(bt.find(10));

            // int[] arr = { 1,2,3,4,5,6};
            // int x = 4;
            // Console.WriteLine("index : "+binarySearch(arr, 0, (arr.Length - 1), x));
            // Console.WriteLine("index : " + binarySearch(arr, x));

            float[] arr = { 1.1f, 2.2f, 3.3f, 4.4f, 5.6f };
            Console.WriteLine(binarySearchMethods.binarySearch(arr, 5.6f));

            double[] arr2 = { 1.5, 2.9, 3.1, 3.8, 5.5 };
            Console.WriteLine(binarySearchMethods.binarySearch(arr2, 3.1, (double first, double second) => { return first > second; }));


        }

    }
    public class binarySearchMethods
    {
        public static int binarySearch(int[] arr, int start, int end, int x)
        {
            //Binary Search using recursive method
            
            if (end >= start)
            {
                int mid = start + (end - start) / 2;

                if (arr [mid] == x)
                    return mid;

                if (arr[mid] > x)
                    return binarySearch(arr, start, mid - 1, x);


                return binarySearch(arr, mid + 1, end, x);
            }

            return -1;

        }

        public static int binarySearch(int[] arr, int x)
        {
            //Binary Search using while loop

            int start = 0, end = arr.Length - 1;

            while (end >= start)
            {
                int mid = start + (end - start) / 2;
                
                if (x > arr[mid])
                    start = mid + 1;

                else if (x < arr[mid])
                    end = mid - 1;

                else
                    return mid;
            }
            return -1;

        }

        public static int binarySearch<T>(T[] arr, T x)
            where T : IComparable<T>
        {
            //Binary Search using generic type

            int start = 0, end = arr.Length - 1;
            while (end >= start)
            {
                int mid = start + (end - start) / 2;
                int result = x.CompareTo(arr[mid]);

                if (result > 0)
                    start = mid + 1;

                else if (result < 0)
                    end = mid - 1;

                else
                    return mid;
            }

            return -1;



        }
        public static int binarySearch<T>(T[] arr, T x, Func<T, T, bool> Action)
        {
            //Binary Search using lambda expression

            int start = 0, end = arr.Length - 1;
            while (end >= start)
            {
                int mid = start + (end - start) / 2;
                bool result = Action(x, arr[mid]);

                if (result)
                    start = mid + 1;

                else if (result)
                    end = mid - 1;

                else
                    return mid;
            }

            return -1;
        }
    }
}
