using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Util
{
    public class RandomUtil
    {
        public static int[] Rand(int minValue, int maxValue, int number)
        {
            int[] a = new int[number];
            System.Random r = new System.Random();

            for (int i = 0; i < number; ++i)
                a[i] = r.Next(minValue, maxValue);

            return a;

        }
        public static int Rand(int minValue, int maxValue)
        {
            System.Random r = new System.Random();

            return r.Next(minValue, maxValue);
        }
    }
}
