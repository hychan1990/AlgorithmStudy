using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] TestingObject = new int[] { 4,3,2,1,3 };
            Console.WriteLine(string.Join(",",Sorter.BubbleSort(TestingObject)));
            Console.WriteLine(string.Join(",", Sorter.SelectionSort(TestingObject)));
            Console.Read();
        }
    }
}
