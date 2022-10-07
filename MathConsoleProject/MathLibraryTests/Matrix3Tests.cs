using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class Matrix3Tests
    {
        [TestMethod]
        public void Matrix3Multiply()
        {
            Matrix3 m3a = new Matrix3(1, 3, 1, 2, 2, 2, 3, 1, 3);
            Matrix3 m3c = new Matrix3(4, 6, 4, 5, 5, 6, 6, 4, 5);

            Matrix3 m3d = m3a * m3c;

            // https://www.wolframalpha.com/input/?i=%7B%7B1%2C2%2C3%7D%2C%7B3%2C2%2C1%7D%2C%7B1%2C2%2C3%7D%7D+*+%7B%7B4%2C5%2C6%7D%2C%7B6%2C5%2C4%7D%2C%7B4%2C6%2C5%7D%7D
            Assert.AreEqual(new Matrix3(28, 28, 28, 33, 31, 33, 29, 31, 29), m3d);
        }

        [TestMethod]
        public void Vector3MatrixTranslation3()
        {
            // homogeneous point translation
            Matrix3 m3b = new Matrix3(1, 0, 0,
                                      0, 1, 0,
                                      55, 44, 1);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 0);

            Vector3 v3b = m3b * v3a;

            Assert.AreEqual(new Vector3(13.5f, -48.23f, 0), v3b);
        }

        [TestMethod]
        public void Vector3MatrixTranslation()
        {
            // homogeneous point translation
            Matrix3 m3b = new Matrix3(1, 0, 0,
                                      0, 1, 0,
                                      55, 44, 1);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 1);

            Vector3 v3b = m3b * v3a;

            Assert.AreEqual(new Vector3(68.5f, -4.23f, 1), v3b);
        }
    }
}
