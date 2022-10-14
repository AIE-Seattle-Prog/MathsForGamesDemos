using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public static class CollisionTests
    {
        public static bool CirclePointTest(Vector3 circlePos, float circleRadius, Vector3 pointPos)
        {
            // get the distance
            Vector3 offset = circlePos - pointPos;
            float dist2 = offset.Dot(offset);

            // compare to radius of circle  (if less, collision! if more, no collision)
            return dist2 <= circleRadius * circleRadius;

            /* Slow and naive implementation of circle-pooint
            float dist = (circlePos - pointPos).Magnitude;
            return dist <= circleRadius;
            */
        }

        // CircleCircleTest

        // AABBPointTest

        // AABBAABBTest

        // CircleAABBTest
    }
}
