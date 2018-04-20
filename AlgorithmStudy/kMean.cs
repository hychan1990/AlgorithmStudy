using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmStudy
{
    static class kMean
    {
        public static string[,] GenerateStarGrid(int SideLength,int density)
        {
            if (density>(SideLength*SideLength))
            {
                throw new Exception("density cannot more than size.");
            }
            string[,] starGrid = new string[SideLength, SideLength];
            int size = SideLength * SideLength;
            for (int i = 0; i < SideLength; i++)
            {
                for (int n = 0; n < SideLength; n++)
                {
                    starGrid.SetValue("口", i, n);
                }
            }
            int done = 0;
            while (done<density)
            {
                Random rand = new Random();
                int randX = rand.Next(SideLength);
                int randY = rand.Next(SideLength);
                while (starGrid[randX,randY] != "口")//已有星
                {
                    randX = rand.Next(SideLength);
                    randY = rand.Next(SideLength);
                }
                starGrid[randX,randY] = "ｘ";
                done++;
            }
            return starGrid;
        }
        public Array<string[,]> kMeansAlgo(string[,] starGrid, int n)
        {
            List<int[]> nPos = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                Random rand = new Random();
                int nx = rand.Next((int)Math.Sqrt(starGrid.Length));
                int ny = rand.Next((int)Math.Sqrt(starGrid.Length));
                int[] np = { nx, ny };
                nPos.Add(np);
            }
            foreach (int[] pos in nPos)
            {
                
            }
        }
    }
}
