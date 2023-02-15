using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    [System.Serializable]
    public class MyMatrix4x4
    {
        // Members
        public float[,] values;

        // Operators
        public static Vector4 operator *(MyMatrix4x4 lhs, MyVector4 rhs)
        {
            Vector4 rv = new Vector4();

            rv.x = (lhs.values[0, 0] * rhs.x) + (lhs.values[1, 0] * rhs.x) + (lhs.values[2, 0] * rhs.x) + (lhs.values[3, 0] * rhs.x);
            rv.y = (lhs.values[0, 1] * rhs.y) + (lhs.values[1, 1] * rhs.y) + (lhs.values[2, 1] * rhs.y) + (lhs.values[3, 1] * rhs.y);
            rv.z = (lhs.values[0, 2] * rhs.z) + (lhs.values[1, 2] * rhs.z) + (lhs.values[2, 2] * rhs.z) + (lhs.values[3, 2] * rhs.z);
            rv.w = (lhs.values[0, 3] * rhs.w) + (lhs.values[1, 3] * rhs.w) + (lhs.values[2, 3] * rhs.w) + (lhs.values[3, 3] * rhs.w);

            return rv;
        }

        // Constructors
        public MyMatrix4x4(MyVector4 x, MyVector4 y, MyVector4 z, MyVector4 w)
        {
            values = new float[4, 4];

            values[0, 0] = x.x;
            values[0, 1] = x.y;
            values[0, 2] = x.z;
            values[0, 3] = x.w;

            values[1, 0] = y.x;
            values[1, 1] = y.y;
            values[1, 2] = y.z;
            values[1, 3] = y.w;

            values[2, 0] = z.x;
            values[2, 1] = z.y;
            values[2, 2] = z.z;
            values[2, 3] = z.w;

            values[3, 0] = w.x;
            values[3, 1] = w.y;
            values[3, 2] = w.z;
            values[3, 3] = w.w;
        }
        public MyMatrix4x4(MyVector3 x, MyVector3 y, MyVector3 z, MyVector3 w)
        {
            values = new float[4, 4];

            values[0, 0] = x.x;
            values[0, 1] = x.y;
            values[0, 2] = x.z;
            values[0, 3] = 0.0f;

            values[1, 0] = y.x;
            values[1, 1] = y.y;
            values[1, 2] = y.z;
            values[1, 3] = 0.0f;

            values[2, 0] = z.x;
            values[2, 1] = z.y;
            values[2, 2] = z.z;
            values[2, 3] = 0.0f;

            values[3, 0] = w.x;
            values[3, 1] = w.y;
            values[3, 2] = w.z;
            values[3, 3] = 1.0f;
        }
    }
}