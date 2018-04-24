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
            List<star> listStar = kMean.generateStarGrid(100, 20);
            for (int i = 0; i < listStar.Count; i++)
            {
                Console.WriteLine("stars: "+listStar[i].pos.ToString());
            }
            List<k> ks = kMean.GenRandomK(100, 3);
            for (int i = 0; i < ks.Count; i++)
            {
                Console.WriteLine("init k: "+ks[i].pos.ToString());
            }
            List<k> listK = kMean.kMeansAlgo(100, listStar,ks,3);
            for (int i = 0; i < listK.Count; i++)
            {
                Console.WriteLine("k: "+listK[i].pos.ToString());
                for (int n = 0; n < listK[i].children.Count; n++)
                {
                    Console.WriteLine(" children:" + listK[i].children[n].pos.ToString());
                }
            }
            Recursive.OnePlusN(100);
            Console.Read();
        }
    }
}
