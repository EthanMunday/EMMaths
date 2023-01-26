using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyVector4
    {
        // Members
        public float x, y, z, w;

        //Length
        public float Length()
        {
            return Mathf.Sqrt(LengthSq());
        }
        public static float Length(MyVector4 x)
        {
            return x.Length();
        }
        public float LengthSq()
        {
            return (x * x + y * y + z * z + w * w);
        }
        public static float LengthSq(MyVector4 x)
        {
            return x.LengthSq();
        }
        public MyVector4 Normalise()
        {
            MyVector4 rv = new MyVector4();
            rv.x = x;
            rv.y = y;
            rv.z = z;
            rv.w = w;
            rv /= rv.Length();
            return rv;
        }
        public static MyVector4 Normalise(MyVector4 x)
        {
            return x.Normalise();
        }

        //Opperators
        public static MyVector4 Add(MyVector4 lhs, MyVector4 rhs)
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
            return Add(lhs, rhs);
        }
        public static MyVector4 Add(MyVector4 lhs, float rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x + rhs;
            rv.y = lhs.y + rhs;
            rv.z = lhs.z + rhs;
            rv.w = lhs.w + rhs;
            return rv;
        }
        public static MyVector4 operator +(MyVector4 lhs, float rhs)
        {
            return Add(lhs, rhs);
        }
        public static MyVector4 Subtract(MyVector4 lhs, MyVector4 rhs)
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
            return Subtract(lhs, rhs);
        }
        public static MyVector4 Subtract(MyVector4 lhs, float rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x - rhs;
            rv.y = lhs.y - rhs;
            rv.z = lhs.z - rhs;
            rv.w = lhs.w - rhs;
            return rv;
        }
        public static MyVector4 operator -(MyVector4 lhs, float rhs)
        {
            return Subtract(lhs, rhs);
        }
        public static MyVector4 Multiply(MyVector4 lhs, MyVector4 rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x * rhs.x;
            rv.y = lhs.y * rhs.y;
            rv.z = lhs.z * rhs.z;
            rv.w = lhs.w * rhs.w;
            return rv;
        }
        public static MyVector4 operator *(MyVector4 lhs, MyVector4 rhs)
        {
            return Multiply(lhs, rhs);
        }
        public static MyVector4 Multiply(MyVector4 lhs, float rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x * rhs;
            rv.y = lhs.y * rhs;
            rv.z = lhs.z * rhs;
            rv.w = lhs.w * rhs;
            return rv;
        }
        public static MyVector4 operator *(MyVector4 lhs, float rhs)
        {
            return Multiply(lhs, rhs);
        }
        public static MyVector4 Divide(MyVector4 lhs, MyVector4 rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x / rhs.x;
            rv.y = lhs.y / rhs.y;
            rv.z = lhs.z / rhs.z;
            rv.w = lhs.w / rhs.w;
            return rv;
        }
        public static MyVector4 operator /(MyVector4 lhs, MyVector4 rhs)
        {
            return Divide(lhs, rhs);
        }
        public static MyVector4 Divide(MyVector4 lhs, float rhs)
        {
            MyVector4 rv = new MyVector4();
            rv.x = lhs.x / rhs;
            rv.y = lhs.y / rhs;
            rv.z = lhs.z / rhs;
            rv.w = lhs.w / rhs;
            return rv;
        }
        public static MyVector4 operator /(MyVector4 lhs, float rhs)
        {
            return Divide(lhs, rhs);
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