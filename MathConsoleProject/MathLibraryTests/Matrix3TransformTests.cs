using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class Matrix3TransformTests
    {
        [TestMethod]
        public void Vector3MatrixTransform()
        {
            Matrix3 m3b = Matrix3.CreateRotateY(1.76f);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3b = m3b * v3a;

            // https://www.wolframalpha.com/input/?i=%7B+++++%7Bcos%281.76%29%2C+0%2C+-sin%281.76%29%7D%2C+++++%7B0%2C+1%2C+0%7D%2C+++++%7Bsin%281.76%29%2C+0%2C+cos%281.76%29%7D+%7D+*+%7B%7B13.5%7D%2C+%7B-48.23%7D%2C+%7B862%7D%7D
            Assert.AreEqual(new Vector3(-849.156067f, -48.23f, -148.863144f), v3b);
        }

        [TestMethod]
        public void Vector3MatrixTransform2()
        {
            Matrix3 m3c = Matrix3.CreateRotateZ(9.62f);

            Vector3 v3a = new Vector3(13.5f, -48.23f, 862);
            Vector3 v3c = m3c * v3a;

            // https://www.wolframalpha.com/input/?i=%7B+%7Bcos%289.62%29%2C+sin%289.62%29%2C+0%7D%2C+%7B-sin%289.62%29%2C+cos%289.62%29%2C+0%7D%2C+%7B0%2C+0%2C+1%7D+%7D+*+%7B%7B13.5%7D%2C+%7B-48.23%7D%2C+%7B862%7D%7D
            Assert.AreEqual(new Vector3(-3.8877f, 49.9326f, 862f), v3c);
        }

        [TestMethod]
        public void Matrix3SetRotateX()
        {
            Matrix3 m3a = Matrix3.CreateRotateX(3.98f);

            // https://www.wolframalpha.com/input/?i=%7B+++++%7B1%2C+0%2C+0%7D%2C+++++%7B0%2C+cos%283.98%29%2C+sin%283.98%29%7D%2C+++++%7B0%2C+-sin%283.98%29%2C+cos%283.98%29%7D+%7D
            Assert.AreEqual(new Matrix3(1, 0, 0,
                            0, -0.668648f, 0.743579f,
                            0, -0.743579f, -0.668648f), m3a);
        }

        [TestMethod]
        public void Matrix3SetRotateY()
        {
            Matrix3 m3b = Matrix3.CreateRotateY(1.76f);

            // https://www.wolframalpha.com/input/?i=%7B+++++%7Bcos%281.76%29%2C+0%2C+-sin%281.76%29%7D%2C+++++%7B0%2C+1%2C+0%7D%2C+++++%7Bsin%281.76%29%2C+0%2C+cos%281.76%29%7D+%7D
            Assert.AreEqual(new Matrix3(-0.188077f, 0, 0.982154f,
                            0, 1, 0,
                            -0.982154f, 0, -0.188077f), m3b);
        }

        [TestMethod]
        public void Matrix3SetRotateZ()
        {
            Matrix3 m3c = Matrix3.CreateRotateZ(9.62f);

            // https://www.wolframalpha.com/input/?i=%7B+%7Bcos%289.62%29%2C+sin%289.62%29%2C+0%7D%2C+%7B-sin%289.62%29%2C+cos%289.62%29%2C+0%7D%2C+%7B0%2C+0%2C+1%7D+%7D
            Assert.AreEqual(new Matrix3(-0.981005f, 0.193984f, 0,
                             -0.193984f, -0.981005f, 0,
                             0, 0, 1), m3c);
        }

        [TestMethod]
        public void Vector3MatrixTranslation2()
        {
            // homogeneous point translation
            Matrix3 m3c = Matrix3.CreateRotateZ(2.2f);
            m3c.m7 = 55; m3c.m8 = 44; m3c.m9 = 1;

            Vector3 v3a = new Vector3(13.5f, -48.23f, 1);

            Vector3 v3c = m3c * v3a;

            Assert.AreEqual(new Vector3(8.061456f, 61.46871f, 1), v3c);
        }

        [TestMethod]
        public void Vector3MatrixTranslation4()
        {
            // homogeneous point translation
            Matrix3 m3c = Matrix3.CreateRotateZ(2.2f);
            m3c.m7 = 55; m3c.m8 = 44; m3c.m9 = 1;

            Vector3 v3a = new Vector3(13.5f, -48.23f, 0);

            Vector3 v3c = m3c * v3a;

            Assert.AreEqual(new Vector3(-46.93855f, 17.46871f, 0), v3c);
        }
    }
}
