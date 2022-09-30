using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public static class Random
    {
        private static System.Random instance = new System.Random();

        public static void SetSeed(int seed)
        {
            // reinitialized w/ provided seed
            instance = new System.Random(seed);
        }

        public static int Value
        {
            get
            {
                return instance.Next();
            }
        }

        public static float ValueF
        {
            get
            {
                return instance.NextSingle();
            }
        }

        public static int Range(int minInclusive, int maxInclusive)
        {
            return instance.Next(minInclusive, maxInclusive + 1);
        }

        public static float Range(float minInclusive, float maxInclusive)
        {
            float t = instance.NextSingle();
            float diff = maxInclusive - minInclusive;
            return minInclusive + t * diff;
        }
    }
}
