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

        public static float AngleFrom2D(float x, float y)
        {
            return MathF.Atan2(y, x);
        }

        // Deg2Rad
        public const float Deg2Rad = MathF.PI * 2.0f / 360.0f;

        // Rad2Deg
        public const float Rad2Deg = 1.0f / Deg2Rad;
    }
}
