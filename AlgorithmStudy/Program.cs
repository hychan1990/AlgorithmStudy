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
            int[] TestingObject = new int[] { 4,3,2,1,5,8,7,9,0,-1,-5,-3,-2,-4 };
            Console.WriteLine(string.Join(",",Sorter.BubbleSort(TestingObject)));
            Console.WriteLine(string.Join(",", Sorter.SelectionSort(TestingObject)));
            Console.WriteLine(string.Join(",", Sorter.InsertionSort(TestingObject)));
            string[,] starGrid = kMean.GenerateStarGrid(10, 10);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                for (int n = 0; n < 10; n++)
                {
                    Console.Write(starGrid[i,n]);
                }
            }
            Console.Read();
        }
    }
}
