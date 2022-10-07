using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector3
    {
        public float x, y, z;

        /// <summary>
        /// Constructor that initializes the x, y, and z components
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3(float x, float y, float z=0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// The length or magnitude of the Vector
        /// </summary>
        public float Magnitude
        {
            get
            {
                return MathF.Sqrt(x * x + y * y + z * z);
            }
        }

        /// <summary>
        /// Normalize this Vector
        /// </summary>
        public void Normalize()
        {
            this /= Magnitude;
        }

        /// <summary>
        /// Returns a copy of the current Vector as it would be if normalized
        /// </summary>
        public Vector3 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        /// <summary>
        /// Return the dot product between this Vector and the other
        /// 
        /// Describes the amount of overlap between these two Vectors
        /// </summary>
        /// <param name="rhs">The other Vector</param>
        /// <returns></returns>
        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        /// <summary>
        /// Return the cross-product between this Vector and the other
        /// 
        /// Describes the vector that is perpendicular to the plane formed by this Vector and the other
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(y * rhs.z - z * rhs.y,
                               z * rhs.x - x * rhs.z,
                               x * rhs.y - y * rhs.x);
        }

        /// <summary>
        /// Multiply the current Vector's components by the other Vector's components
        /// </summary>
        /// <param name="rhs"></param>
        public void Scale(Vector3 rhs)
        {
            x *= rhs.x;
            y *= rhs.y;
            z *= rhs.z;
        }

        /// <summary>
        /// Returns a copy of the current Vector's components multiplied by the other Vector's components
        /// </summary>
        /// <param name="rhs"></param>
        public Vector3 Scaled(Vector3 rhs)
        {
            return new Vector3(x * rhs.x, y * rhs.y, z * rhs.z);
        }

        /// <summary>
        /// The sums of the Xs, Ys, and Zs, of the vectors
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator + (Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x,   // sum of the Xs
                               lhs.y + rhs.y,   // sum of the Ys
                               lhs.z + rhs.z);  // sum of the Zs
        }

        /// <summary>
        /// The differences of the Xs, Ys, and Zs, of the vectors
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x,   // difference of the Xs
                               lhs.y - rhs.y,   // difference of the Ys
                               lhs.z - rhs.z);  // difference of the Zs
        }

        /// <summary>
        /// The negated Vector
        /// </summary>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 rhs)
        {
            return new Vector3(-rhs.x,   // difference of the Xs
                               -rhs.y,   // difference of the Ys
                               -rhs.z);  // difference of the Zs
        }

        /// <summary>
        /// Scale a Vector by a scalar float
        /// 
        /// Multiplies each component of the Vector by the given scalar
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.x * scalar,   // product of the Xs
                               lhs.y * scalar,   // product of the Ys
                               lhs.z * scalar);  // product of the Zs
        }

        /// <summary>
        /// Divides a Vector by a scalar float
        /// 
        /// Divides each component of the Vector by the given scalar
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.x / scalar,   // result of division of the Xs
                               lhs.y / scalar,   // result of division of the Ys
                               lhs.z / scalar);  // result of division of the Zs
        }

        /// <summary>
        /// Scale a Vector by a scalar float
        /// 
        /// Multiplies each component of the Vector by the given scalar
        /// </summary>
        /// <param name="scalar"></param>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static Vector3 operator *(float scalar, Vector3 vec)
        {
            return new Vector3(vec.x * scalar,   // product of the Xs
                               vec.y * scalar,   // product of the Ys
                               vec.z * scalar);  // product of the Zs
        }

        // Equals(Vector3)
        // Equals(object) - override!
        // == operator
        // != operator
        // GetHashCode()
        // ToString()

        public bool Equals(Vector3 other)
        {
            if (MathUtils.ApproximatelyEqual(x, other.x) &&
                MathUtils.ApproximatelyEqual(y, other.y) &&
                MathUtils.ApproximatelyEqual(z, other.z))
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && Equals((Vector3)obj);
        }

        /// <summary>
        /// Determines if two vectors are approximately equal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>True if approximately equal, false if not</returns>
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Determines if two vectors are approximately inequal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>True if approximately inequal, false if not</returns>
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(x);
            hash.Add(y);
            hash.Add(z);

            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return x.ToString() + "," + y.ToString() + "," + z.ToString();
        }
    }
}
