using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        public Matrix3(float m1, float m2, float m3,
                       float m4, float m5, float m6,
                       float m7, float m8, float m9)
        {
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;

            this.m4 = m4;
            this.m5 = m5;
            this.m6 = m6;

            this.m7 = m7;
            this.m8 = m8;
            this.m9 = m9;
        }

        public Matrix3(float diagonal)
        {
            this.m1 = diagonal;
            this.m2 = 0;
            this.m3 = 0;

            this.m4 = 0;
            this.m5 = diagonal;
            this.m6 = 0;

            this.m7 = 0;
            this.m8 = 0;
            this.m9 = diagonal;
        }

        public readonly static Matrix3 Identity = new Matrix3(1,0,0, 0,1,0, 0,0,1);


        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                // first column
                lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
                lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
                lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,
                // second column
                lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,
                lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
                lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,
                // third column
                lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
                lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
                lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9
                );
        }

        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.m1 * rhs.x + lhs.m4 * rhs.y + lhs.m7 * rhs.z,
                               lhs.m2 * rhs.x + lhs.m5 * rhs.y + lhs.m8 * rhs.z,
                               lhs.m3 * rhs.x + lhs.m6 * rhs.y + lhs.m9 * rhs.z);
        }

        public static Matrix3 operator *(Matrix3 lhs, float scalar)
        {
            lhs.m1 *= scalar;
            lhs.m2 *= scalar;
            lhs.m3 *= scalar;
            lhs.m4 *= scalar;
            lhs.m5 *= scalar;
            lhs.m6 *= scalar;
            lhs.m7 *= scalar;
            lhs.m8 *= scalar;
            lhs.m9 *= scalar;

            return lhs;
        }

        public static Matrix3 operator *(float scalar, Matrix3 rhs)
        {
            rhs.m1 *= scalar;
            rhs.m2 *= scalar;
            rhs.m3 *= scalar;
            rhs.m4 *= scalar;
            rhs.m5 *= scalar;
            rhs.m6 *= scalar;
            rhs.m7 *= scalar;
            rhs.m8 *= scalar;
            rhs.m9 *= scalar;

            return rhs;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return m1;
                    case 1:
                        return m2;
                    case 2:
                        return m3;
                    case 3:
                        return m4;
                    case 4:
                        return m5;
                    case 5:
                        return m6;
                    case 6:
                        return m7;
                    case 7:
                        return m8;
                    case 8:
                        return m9;
                    default:
                        throw new IndexOutOfRangeException(); // must be between 0-8 inclusive-inclusive
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        m1 = value;
                        break;
                    case 1:
                        m2 = value;
                        break;
                    case 2:
                        m3 = value;
                        break;
                    case 3:
                        m4 = value;
                        break;
                    case 4:
                        m5 = value;
                        break;
                    case 5:
                        m6 = value;
                        break;
                    case 6:
                        m7 = value;
                        break;
                    case 7:
                        m8 = value;
                        break;
                    case 8:
                        m9 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException(); // must be between 0-8 inclusive-inclusive
                }
            }
        }

        public static Matrix3 CreateTranslation(float x, float y)
        {
            Matrix3 matrix = Identity;

            // translation goes into the x/y of the third column
            matrix.m7 = x;
            matrix.m8 = y;

            return matrix;
        }

        public static Matrix3 CreateTranslation(Vector3 vec)
        {
            Matrix3 matrix = Identity;

            // translation goes into the x/y of the third column
            matrix.m7 = vec.x;
            matrix.m8 = vec.y;
            matrix.m9 = vec.z;

            return matrix;
        }

        public static Matrix3 CreateRotateX(float a)
        {
            return new Matrix3(
                // first column
                1,
                0,
                0,
                // second column
                0,
                MathF.Cos(a),
                -MathF.Sin(a),
                // third column
                0,
                MathF.Sin(a),
                MathF.Cos(a)
                );
        }

        public static Matrix3 CreateRotateY(float a)
        {
            return new Matrix3(
                // first column
                MathF.Cos(a),
                0,
                MathF.Sin(a),

                // second column
                0,
                1,
                0,

                // third column
                -MathF.Sin(a),
                0,
                MathF.Cos(a)
                );
        }

        public static Matrix3 CreateRotateZ(float a)
        {
            return new Matrix3(
                // first column
                MathF.Cos(a),
                -MathF.Sin(a),
                0,
                // second column
                MathF.Sin(a),
                MathF.Cos(a),
                0,
                // third column
                0,
                0,
                1
                );
        }

        public static Matrix3 CreateScale(float xScale, float yScale)
        {
            Matrix3 matrix = Identity;
            matrix.m1 = xScale;
            matrix.m5 = yScale;

            return matrix;
        }

        public void SetTranslation(float x, float y)
        {
            m7 = x;
            m8 = y;
        }

        public Vector3 GetTranslation()
        {
            return new Vector3(m7, m8, m9);
        }

        public void RotateZ(float radians)
        {
            this *= CreateRotateZ(radians);
        }

        // Equality operators
        // GetHashCode
        // ToString()

        public static bool operator ==(Matrix3 lhs, Matrix3 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Matrix3 lhs, Matrix3 rhs)
        {
            return !(lhs == rhs);
        }

        //
        // Value Equality
        //

        public bool Equals(Matrix3 other)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (!MathUtils.ApproximatelyEqual(this[i], other[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Matrix3 && Equals((Matrix3)obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(m1);
            hash.Add(m2);
            hash.Add(m3);
            hash.Add(m4);
            hash.Add(m5);
            hash.Add(m6);
            hash.Add(m7);
            hash.Add(m8);
            hash.Add(m9);
            return hash.ToHashCode();
        }

        //
        // Utilities
        //

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < 8; ++i)
            {
                output += this[i] + "\n";
            }
            output += this[8];

            return output;
        }
    }
}
