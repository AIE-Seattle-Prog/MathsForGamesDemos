using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;


namespace UnitTestProject
{
    public static class CompareUtils
    {
        public const float DEFAULT_TOLERANCE = 0.0001f;

        public static bool compare(float a, float b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a - b) > tolerance)
                return false;
            return true;
        }

        public static bool compare(Vector3 a, Vector3 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.x - b.x) > tolerance ||
                Math.Abs(a.y - b.y) > tolerance ||
                Math.Abs(a.z - b.z) > tolerance)
                return false;
            return true;
        }

        /*
        public static bool compare(Vector4 a, Vector4 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.x - b.x) > tolerance ||
                Math.Abs(a.y - b.y) > tolerance ||
                Math.Abs(a.z - b.z) > tolerance ||
                Math.Abs(a.w - b.w) > tolerance)
                return false;
            return true;
        }

        public static bool compare(Matrix3 a, Matrix3 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.m1 - b.m1) > tolerance || Math.Abs(a.m2 - b.m2) > tolerance || Math.Abs(a.m3 - b.m3) > tolerance ||
                Math.Abs(a.m4 - b.m4) > tolerance || Math.Abs(a.m5 - b.m5) > tolerance || Math.Abs(a.m6 - b.m6) > tolerance ||
                Math.Abs(a.m7 - b.m7) > tolerance || Math.Abs(a.m8 - b.m8) > tolerance || Math.Abs(a.m9 - b.m9) > tolerance)
                return false;
            return true;
        }

        public static bool compare(Matrix4 a, Matrix4 b, float tolerance = DEFAULT_TOLERANCE)
        {
            if (Math.Abs(a.m1 - b.m1) > tolerance || Math.Abs(a.m2 - b.m2) > tolerance || Math.Abs(a.m3 - b.m3) > tolerance || Math.Abs(a.m4 - b.m4) > tolerance ||
                Math.Abs(a.m5 - b.m5) > tolerance || Math.Abs(a.m6 - b.m6) > tolerance || Math.Abs(a.m7 - b.m7) > tolerance || Math.Abs(a.m8 - b.m8) > tolerance ||
                Math.Abs(a.m9 - b.m9) > tolerance || Math.Abs(a.m10 - b.m10) > tolerance || Math.Abs(a.m11 - b.m11) > tolerance || Math.Abs(a.m12 - b.m12) > tolerance ||
                Math.Abs(a.m13 - b.m13) > tolerance || Math.Abs(a.m14 - b.m14) > tolerance || Math.Abs(a.m15 - b.m15) > tolerance || Math.Abs(a.m16 - b.m16) > tolerance)
                return false;
            return true;
        }
        */
    }
}
