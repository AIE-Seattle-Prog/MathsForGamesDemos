using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

using static UnitTestProject.CompareUtils;

namespace UnitTestProject
{
    [TestClass]
    public class Vector3Tests
    {
        [TestMethod]
        public void Vector3Addition()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            Vector3 v3c = v3a + v3b;

            Assert.IsTrue(compare(new Vector3(18.5f, -44.24f, 850), v3c));
        }

        [TestMethod]
        public void Vector3Subtraction()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            Vector3 v3c = v3a - v3b;

            Assert.IsTrue(compare(new Vector3(8.5f, -52.22f, 874), v3c));
        }

        [TestMethod]
        public void Vector3PostScale()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3c = v3a * 0.256f;

            Assert.IsTrue(compare(new Vector3(3.45600008965f, -12.3468809128f, 220.672012329f), v3c));
        }

        [TestMethod]
        public void Vector3PreScale()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3c = 0.256f * v3a;

            Assert.IsTrue(compare(new Vector3(3.45600008965f, -12.3468809128f, 220.672012329f), v3c));
        }

        [TestMethod]
        public void Vector3Magnitude()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            float mag3 = v3a.Magnitude;

            Assert.AreEqual(mag3, 863.453735352f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector3Normalise()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            v3a.Normalize();

            Assert.IsTrue(compare(v3a, new Vector3(0.0156349f, -0.0558571f, 0.998316f)));
        }

        [TestMethod]
        public void Vector3Dot()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            float dot3 = v3a.Dot(v3b);

            Assert.AreEqual(dot3, -10468.9375f, DEFAULT_TOLERANCE);
        }

        [TestMethod]
        public void Vector3Cross()
        {
            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = new Vector3(5, 3.99f, -12);
            Vector3 v3c = v3a.Cross(v3b);

            Assert.IsTrue(compare(v3c, new Vector3(-2860.62011719f, 4472.00000000f, 295.01498413f)));
        }
    }
}
