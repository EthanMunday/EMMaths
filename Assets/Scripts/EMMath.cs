using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyVector2
    {
        // Members
        public float x, y;

        //Length
        public float Length()
        {
            return Mathf.Sqrt(LengthSq());
        }
        public static float Length(MyVector2 x)
        {
            return x.Length();
        }
        public float LengthSq()
        {
            return (x * x + y * y);
        }
        public static float LengthSq(MyVector2 x)
        {
            return x.LengthSq();
        }
        public MyVector2 Normalise()
        {
            MyVector2 rv = new MyVector2();
            rv.x = x;
            rv.y = y;
            rv /= rv.Length();
            return rv;
        }
        public static MyVector2 Normalise(MyVector2 x)
        {
            return x.Normalise();
        }

        //Opperators
        public static MyVector2 Add(MyVector2 lhs, MyVector2 rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x + rhs.x;
            rv.y = lhs.y + rhs.y;
            return rv;
        }
        public static MyVector2 operator +(MyVector2 lhs, MyVector2 rhs)
        {
            return Add(lhs, rhs);
        }
        public static MyVector2 Add(MyVector2 lhs, float rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x + rhs;
            rv.y = lhs.y + rhs;
            return rv;
        }
        public static MyVector2 operator +(MyVector2 lhs, float rhs)
        {
            return Add(lhs, rhs);
        }
        public static MyVector2 Subtract(MyVector2 lhs, MyVector2 rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x - rhs.x;
            rv.y = lhs.y - rhs.y;
            return rv;
        }
        public static MyVector2 operator -(MyVector2 lhs, MyVector2 rhs)
        {
            return Subtract(lhs, rhs);
        }
        public static MyVector2 Subtract(MyVector2 lhs, float rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x - rhs;
            rv.y = lhs.y - rhs;
            return rv;
        }
        public static MyVector2 operator -(MyVector2 lhs, float rhs)
        {
            return Subtract(lhs, rhs);
        }
        public static MyVector2 Multiply(MyVector2 lhs, MyVector2 rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x * rhs.x;
            rv.y = lhs.y * rhs.y;
            return rv;
        }
        public static MyVector2 operator *(MyVector2 lhs, MyVector2 rhs)
        {
            return Multiply(lhs, rhs);
        }
        public static MyVector2 Multiply(MyVector2 lhs, float rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x * rhs;
            rv.y = lhs.y * rhs;
            return rv;
        }
        public static MyVector2 operator *(MyVector2 lhs, float rhs)
        {
            return Multiply(lhs, rhs);
        }
        public static MyVector2 Divide(MyVector2 lhs, MyVector2 rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x / rhs.x;
            rv.y = lhs.y / rhs.y;
            return rv;
        }
        public static MyVector2 operator /(MyVector2 lhs, MyVector2 rhs)
        {
            return Divide(lhs, rhs);
        }
        public static MyVector2 Divide(MyVector2 lhs, float rhs)
        {
            MyVector2 rv = new MyVector2();
            rv.x = lhs.x / rhs;
            rv.y = lhs.y / rhs;
            return rv;
        }
        public static MyVector2 operator /(MyVector2 lhs, float rhs)
        {
            return Divide(lhs, rhs);
        }

        //Conversion
        public Vector2 UnityVector()
        {
            return new Vector2(x, y);
        }
        public static Vector2 UnityVector(MyVector2 x)
        {
            return x.UnityVector();
        }

        //Constructors
        public MyVector2(float xIn, float yIn)
        {
            x = xIn;
            y = yIn;
        }
        public MyVector2(Vector2 vecIn)
        {
            x = vecIn.x;
            y = vecIn.y;
        }
        public MyVector2()
        {
            x = 0.0f;
            y = 0.0f;
        }
    }
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
        public static MyVector3 Multiply(MyVector3 lhs, MyVector3 rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x * rhs.x;
            rv.y = lhs.y * rhs.y;
            rv.z = lhs.z * rhs.z;
            return rv;
        }
        public static MyVector3 operator *(MyVector3 lhs, MyVector3 rhs)
        {
            return Multiply(lhs, rhs);
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
        public static MyVector3 Divide(MyVector3 lhs, MyVector3 rhs)
        {
            MyVector3 rv = new MyVector3();
            rv.x = lhs.x / rhs.x;
            rv.y = lhs.y / rhs.y;
            rv.z = lhs.z / rhs.z;
            return rv;
        }
        public static MyVector3 operator /(MyVector3 lhs, MyVector3 rhs)
        {
            return Divide(lhs, rhs);
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
