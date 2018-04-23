using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmStudy
{
    class twoDimensionPostion
    {
        public int x { get; set; }
        public int y { get; set; }
        public twoDimensionPostion(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override String ToString()
        {
            string pos = x + "," + y;
            return pos;
        }
    }
    class k
    {
        public twoDimensionPostion pos;
        public List<star> children = new List<star>();
        public k(twoDimensionPostion pos)
        {
            this.pos = pos;
        }
    }
    class star
    {
        public twoDimensionPostion pos;
        public k parent;
        public star(twoDimensionPostion pos)
        {
            this.pos = pos;
        }
    }
    static class kMean
    {
        static Random rand = new Random();
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

        public static List<star> generateStarGrid(int SideLength, int density)
        {
            if (density > (SideLength * SideLength))
            {
                throw new Exception("density cannot more than size.");
            }
            List<star> stars = new List<star>();
            Random rand = new Random();
            while (stars.Count < density)
            {
                twoDimensionPostion newPos = new twoDimensionPostion(rand.Next(SideLength), rand.Next(SideLength));
                star s = new star(newPos);
                stars.Add(s);
            }
            return stars;
        }
        public static List<k> kMeansAlgo(int SideLength,List<star> starGrid, int k)
        {
            List<k> ks = new List<k>();
            for (int i = 0; i < k; i++)
            {
                int kx = rand.Next(SideLength);
                int ky = rand.Next(SideLength);
                twoDimensionPostion kp = new twoDimensionPostion(kx, ky);
                ks.Add(new k(kp));
            }
            //k have children, star have parent now.
            UpdateParentChildren(ref starGrid, ref ks);
            //compare new old
            bool haveChange = false;
            do
            {
                //move
                MoveK(k, ks, ref haveChange);
                UpdateParentChildren(ref starGrid, ref ks);
            } while (haveChange);
                return ks;
        }

        private static void MoveK(int k, List<k> ks,ref bool haveChange)
        {
            bool[] kHaveChange = new bool[k];
            for (int i = 0; i < ks.Count; i++)
            {
                twoDimensionPostion oldKPos = ks[i].pos;
                //cal avg pos of children
                int totalx = 0;
                int totaly = 0;
                for (int n = 0; n < ks[i].children.Count; n++)
                {
                    totalx += ks[i].children[n].pos.x;
                    totaly += ks[i].children[n].pos.y;
                }
                twoDimensionPostion newKPos = new twoDimensionPostion(ks[i].children.Count>0?totalx / ks[i].children.Count:totalx, ks[i].children.Count>0? totaly / ks[i].children.Count:totaly);
                ks[i].pos = newKPos;
                ks[i].children = new List<star>();
                if (oldKPos.x!=newKPos.x || oldKPos.y!=newKPos.y)
                {
                    kHaveChange[i] = true;
                }
                else
                {
                    kHaveChange[i] = false;
                }
            }
            haveChange = false;
            for (int i = 0; i < kHaveChange.Length; i++)
            {
                if (kHaveChange[i])
                {
                    haveChange = true;
                }
            }
        }

        private static void UpdateParentChildren(ref List<star> starGrid, ref List<k> ks)
        {
            //find nearest k of stars
            foreach (star star in starGrid)
            {
                double shortestDist = double.MaxValue;
                foreach (k k in ks)
                {
                    double dist = calDistance(star.pos, k.pos);
                    if (dist<= shortestDist)
                    {
                        star.parent = k; //mark parent
                        shortestDist = dist;
                    }
                }
                star.parent.children.Add(star);
            }
        }

        private static double calDistance(twoDimensionPostion posA, twoDimensionPostion posB)
        {
            double a = posA.x - posB.x;
            double b = posA.y - posB.y;
            double c = Math.Sqrt(a * a + b * b);
            return c;
        }
    }
}
