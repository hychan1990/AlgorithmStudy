using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmStudy
{
    public static class Sorter
    {
        public static int[] BubbleSort(int[] intArr)
        {
            for (int i = 0; i < intArr.Length-1; i++) //sort the first
            {
                for (int n = intArr.Length-1; n >i; n--) //start from right end
                {
                    int right = intArr[n];
                    int left = intArr[n - 1];
                    if (right<left)
                    {
                        //switch left and right
                        intArr[n - 1] = right;
                        intArr[n] = left;
                    }
                }
            }
            return intArr;
        }
        public static int[] SelectionSort(int[] intArr)
        {
            for (int n = 0; n < intArr.Length; n++)
            {
                int now = intArr[n];
                int smallest = now;
                int smallestPos = n;
                for (int i = n+1; i < intArr.Length; i++) //find smallest
                {
                    if (intArr[i]<= smallest)
                    {
                        smallest = intArr[i];
                        smallestPos = i;
                    }
                }
                //switch
                intArr[smallestPos] = now;
                intArr[n] = smallest;
            }
            return intArr;
        }
        public static int[] InsertionSort(int[] intArr)
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                int selected = intArr[i];
                for (int n = i; n > 0; n--)
                {
                    int sample = intArr[n];
                    if (selected<sample)
                    {
                        intArr[i] = sample;
                        intArr[n] = selected;
                        break;
                    }
                }
            }
            return intArr;
        }
    }
    
}
