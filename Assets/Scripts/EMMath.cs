using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyVector3
    {
        // Members
        public float x, y, z;
        //Length
        public float CalculateLength()
        {
            return Mathf.Sqrt(x * x + y * y + z * z);
        }
        public static float CalculateLength(MyVector3 x)
        {
            return x.CalculateLength();
        }
        //Opperators
        public static MyVector3 AddVectors(MyVector3 lhs, MyVector3 rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x + rhs.x;
            rv.y = lhs.y + rhs.y;
            rv.z = lhs.z + rhs.z;
            return rv;
        }
        public static MyVector3 operator +(MyVector3 lhs, MyVector3 rhs)
        {
            return AddVectors(lhs, rhs);
        }
        public static MyVector3 SubtractVectors(MyVector3 lhs, MyVector3 rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x - rhs.x;
            rv.y = lhs.y - rhs.y;
            rv.z = lhs.z - rhs.z;
            return rv;
        }
        public static MyVector3 operator -(MyVector3 lhs, MyVector3 rhs)
        {
            return SubtractVectors(lhs, rhs);
        }

        //Conversion
        public Vector3 UnityVector()
        {
            return new Vector3(x, y, z);
        }
        public static Vector3 UnityVector(MyVector3 x)
        {
            return x.UnityVector();
        }

        //Constructors
        public MyVector3(float xIn, float yIn, float zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
        }
        public MyVector3(float xIn, float yIn)
        {
            x = xIn;
            y = yIn;
            z = 0.0f;
        }
        public MyVector3(Vector3 vecIn)
        {
            x = vecIn.x;
            y = vecIn.y;
            z = vecIn.z;
        }
        public MyVector3()
        {
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
        }
    }
    public class MyVector4
    {
        // Members
        public float x, y, z, w;
        //Length
        public float CalculateLength()
        {
            return Mathf.Sqrt(x * x + y * y + z * z + w * w);
        }
        public static float CalculateLength(MyVector4 x)
        {
            return x.CalculateLength();
        }
        //Opperators
        public static MyVector4 AddVectors(MyVector4 lhs, MyVector4 rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x + rhs.x;
            rv.y = lhs.y + rhs.y;
            rv.z = lhs.z + rhs.z;
            rv.w = lhs.w + rhs.w;
            return rv;
        }
        public static MyVector4 operator +(MyVector4 lhs, MyVector4 rhs)
        {
            return AddVectors(lhs, rhs);
        }
        public static MyVector4 SubtractVectors(MyVector4 lhs, MyVector4 rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x - rhs.x;
            rv.y = lhs.y - rhs.y;
            rv.z = lhs.z - rhs.z;
            rv.w = lhs.w - rhs.w;
            return rv;
        }
        public static MyVector4 operator -(MyVector4 lhs, MyVector4 rhs)
        {
            return SubtractVectors(lhs, rhs);
        }

        //Conversion
        public Vector4 UnityVector()
        {
            return new Vector4(x, y, z, w);
        }
        public static Vector4 UnityVector(MyVector4 x)
        {
            return x.UnityVector();
        }

        //Constructors
        public MyVector4(float xIn, float yIn, float zIn, float wIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
            w = wIn;
        }
        public MyVector4(float xIn, float yIn, float zIn)
        {
            x = xIn;
            y = yIn;
            z = zIn;
            w = 0.0f;
        }
        public MyVector4(Vector4 vecIn)
        {
            x = vecIn.x;
            y = vecIn.y;
            z = vecIn.z;
            w = vecIn.w;
        }
        public MyVector4()
        {
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
            w = 0.0f;
        }
    }
}
