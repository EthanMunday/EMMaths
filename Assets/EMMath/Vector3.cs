using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    [System.Serializable]
    public class MyVector3
    {
        // Members
        public float x, y, z;

        //Length
        public float Length()
        {
            return Mathf.Sqrt(LengthSq());
        }
        public static float Length(MyVector3 x)
        {
            return x.Length();
        }
        public float LengthSq()
        {
            return (x * x + y * y + z * z);
        }
        public static float LengthSq(MyVector3 x)
        {
            return x.LengthSq();
        }
        public MyVector3 Normalise()
        {
            MyVector3 rv = new MyVector3();
            rv.x = x;
            rv.y = y;
            rv.z = z;
            rv /= rv.Length();
            return rv;
        }
        public static MyVector3 Normalise(MyVector3 x)
        {
            return x.Normalise();
        }

        //Opperators
        public static MyVector3 Add(MyVector3 lhs, MyVector3 rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x + rhs.x;
            rv.y = lhs.y + rhs.y;
            rv.z = lhs.z + rhs.z;
            return rv;
        }
        public static MyVector3 operator +(MyVector3 lhs, MyVector3 rhs)
        {
            return Add(lhs, rhs);
        }
        public static MyVector3 Add(MyVector3 lhs, float rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x + rhs;
            rv.y = lhs.y + rhs;
            rv.z = lhs.z + rhs;
            return rv;
        }
        public static MyVector3 operator +(MyVector3 lhs, float rhs)
        {
            return Add(lhs, rhs);
        }
        public static MyVector3 Subtract(MyVector3 lhs, MyVector3 rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x - rhs.x;
            rv.y = lhs.y - rhs.y;
            rv.z = lhs.z - rhs.z;
            return rv;
        }
        public static MyVector3 operator -(MyVector3 lhs, MyVector3 rhs)
        {
            return Subtract(lhs, rhs);
        }
        public static MyVector3 Subtract(MyVector3 lhs, float rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x - rhs;
            rv.y = lhs.y - rhs;
            rv.z = lhs.z - rhs;
            return rv;
        }
        public static MyVector3 operator -(MyVector3 lhs, float rhs)
        {
            return Subtract(lhs, rhs);
        }
        public static MyVector3 Multiply(MyVector3 lhs, float rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x * rhs;
            rv.y = lhs.y * rhs;
            rv.z = lhs.z * rhs;
            return rv;
        }
        public static MyVector3 operator *(MyVector3 lhs, float rhs)
        {
            return Multiply(lhs, rhs);
        }
        public static MyVector3 Divide(MyVector3 lhs, float rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x / rhs;
            rv.y = lhs.y / rhs;
            rv.z = lhs.z / rhs;
            return rv;
        }
        public static MyVector3 operator /(MyVector3 lhs, float rhs)
        {
            return Divide(lhs, rhs);
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

}