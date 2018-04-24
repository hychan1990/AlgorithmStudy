using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy
{
    static class Recursive
    {
        public static void OnePlusN(int n)
        {
            if (n>0)
            {
                n--;
                OnePlusN(n);
                string f = string.Format("+{0}", n.ToString());
                Console.Write(f);
            }
        }
    }
}
