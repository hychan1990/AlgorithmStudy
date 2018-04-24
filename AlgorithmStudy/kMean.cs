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
        public star(twoDimensionPostion pos)
        {
            this.pos = pos;
        }
    }
    static class kMean
    {
        static Random rand = new Random();

        public static List<star> generateStarGrid(int SideLength, int density)
        {
            if (density > (SideLength * SideLength))
            {
                throw new Exception("density cannot more than size.");
            }
            List<star> stars = new List<star>();
            while (stars.Count < density)
            {
                twoDimensionPostion newPos = new twoDimensionPostion(rand.Next(SideLength), rand.Next(SideLength));
                star s = new star(newPos);
                stars.Add(s);
            }
            return stars;
        }
        public static List<k> kMeansAlgo(int SideLength,List<star> starGrid, List<k> ks, int k)
        {
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

        public static List<k> GenRandomK(int SideLength, int k)
        {
            List<k> ks = new List<k>();
            for (int i = 0; i < k; i++)
            {
                int kx = rand.Next(SideLength);
                int ky = rand.Next(SideLength);
                twoDimensionPostion kp = new twoDimensionPostion(kx, ky);
                ks.Add(new k(kp));
            }

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
                //Dictionary<k, double> kDist = new Dictionary<k, double>();
                List<k> kList = new List<k>();
                List<double> distList = new List<double>();
                foreach (k k in ks)//find nearest k
                {
                    double dist = calDistance(star.pos, k.pos);
                    //kDist.Add(k, dist);
                    kList.Add(k);
                    distList.Add(dist);
                }
                //k selectedK = kDist.Min(x => x.Key);
                k selectedK = kList[distList.IndexOf(distList.Min())];
                selectedK.children.Add(star);
                
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
