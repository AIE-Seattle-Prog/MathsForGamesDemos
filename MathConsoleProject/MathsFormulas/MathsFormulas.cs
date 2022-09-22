using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIE
{
    public static class MathsFormulas
    {
        // Problem A - Basic Quadratic
        public static float BasicQuadratic(float x)
        {
            // x^2 + 2x - 7
            return x * x + 2 * x - 7;
        }

        // Problem B - Quadratic Roots
        public struct QuadraticRoots
        {
            public float rootA;
            public float rootB;
            public bool hasRoots;
        }

        public static QuadraticRoots GetQuadraticRoots(float a, float b, float c)
        {
            // calculate the numerator
            float numA = -b + MathF.Sqrt(b * b - 4 * a * c);
            float numB = -b - MathF.Sqrt(b * b - 4 * a * c);

            // calculate the denominator
            float den = 2 * a;

            // create a quadraticroots object
            QuadraticRoots roots = new QuadraticRoots();
            roots.rootA = numA / den;
            roots.rootB = numB / den;
            if((b * b - 4 * a * c) >= 0)
            {
                roots.hasRoots = false;
            }
            else
            {
                roots.hasRoots = true;
            }

            // return it
            return roots;
        }

        // Problem C - Linear Blend (aka lerp - linear interpolation)
        public static float Lerp(float start, float end, float time)
        {
            return start + time * (end - start);
        }

        // Problem D - Distance Between Two Points
        public static float Distance(float x1, float y1, float x2, float y2)
        {
            return MathF.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public struct Point2D
        {
            public float x;
            public float y;
        }
        public static float Distance(Point2D p1, Point2D p2)
        {
            return MathF.Sqrt((p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y));
        }
    }
}
