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
            Console.WriteLine(BinarySearch.DoBinarySearch(arr, 5.6f));

            double[] arr2 = { 1.5, 2.9, 3.1, 3.8, 5.5 };
            Console.WriteLine(BinarySearch.DoBinarySearch(arr2, 3.1, (double first, double second) => { return first > second; }));


        }

    }
    
}
