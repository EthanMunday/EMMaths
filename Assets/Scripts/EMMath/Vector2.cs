using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    [System.Serializable]
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

        //Conversion
        public Vector2 UnityVector()
        {
            return new Vector2(x, y);
        }
        public static Vector2 UnityVector(MyVector2 x)
        {
            return x.UnityVector();
        }
        public float Sum()
        {
            return x + y;
        }
        public static float DotProduct(MyVector2 lhs, MyVector2 rhs, bool normalised = false)
        {
            float rv = 0.0f;

            if (normalised)
            {
                lhs = lhs.Normalise();
                rhs = rhs.Normalise();
            }

            rv = lhs.x * rhs.x + lhs.y * rhs.y;

            return rv;
        }
        public static float VectortoRadians(MyVector2 x)
        {
            return Mathf.Atan2(x.y, x.x);
        }
        public static MyVector2 DegreestoVector(float x, float length = 1.0f)
        {
            x *= (180 / Mathf.PI);
            return new MyVector2(Mathf.Cos(x), Mathf.Sin(x)) * length;
        }
        public static MyVector2 RadianstoVector(float x, float length = 1.0f)
        {
            return new MyVector2(Mathf.Cos(x), Mathf.Sin(x)) * length;
        }
        public static MyVector2 Lerp(MyVector2 lhs, MyVector2 rhs, float ratio)
        {
            MyVector2 rv = new MyVector2();

            rv = (lhs * (1 - ratio)) + (rhs * ratio);

            return rv;
        }

        //Constructors
        public MyVector2(float xIn, float yIn)
        {
            x = xIn;
            y = yIn;
        }
        public MyVector2(MyVector3 vecIn)
        {
            x = vecIn.x;
            y = vecIn.y;
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

}

