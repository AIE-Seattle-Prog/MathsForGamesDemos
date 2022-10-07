using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public static class MathUtils
    {
        public static bool ApproximatelyEqual(float a, float b, float maxDelta = 0.0001f)
        {
            return MathF.Abs(a - b) < maxDelta;
        }

        // Min

        // Max

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }

            return value;
        }

        // Lerp

        // ReverseLerp

        // Deg2Rad

        // Rad2Deg
    }
}
