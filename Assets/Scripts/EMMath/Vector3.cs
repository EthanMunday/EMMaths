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

        public static float RADIANS
        {
            get
            {
                return (180 / Mathf.PI);
            }
        }

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
        public static MyVector3 operator -(MyVector3 lhs)
        {
            return new MyVector3(-lhs.x, -lhs.y, -lhs.z);
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

        //Conversion
        public Vector3 UnityVector()
        {
            return new Vector3(x, y, z);
        }
        public static Vector3 UnityVector(MyVector3 x)
        {
            return x.UnityVector();
        }
        public float Sum()
        {
            return x + y + z;
        }
        public static float DotProduct(MyVector3 lhs, MyVector3 rhs, bool normalised = false)
        {
            float rv = 0.0f;

            

            rv = lhs.x * rhs.x  + lhs.y * rhs.y + lhs.z * rhs.z;

            return rv;
        }
        public static MyVector3 EulerAnglestoDirection(MyVector3 x, bool convertToRadians = false)
        {
            MyVector3 rv = new();
            if (convertToRadians)
            {
                x /= RADIANS;
            }
            rv.x = Mathf.Cos(x.x) * Mathf.Sin(x.y);
            rv.y = -Mathf.Sin(x.x);
            rv.z = Mathf.Cos(x.y) * Mathf.Cos(x.x);

            return rv;
        }
        public static MyMatrix4x4 LookAt(MyVector3 position, MyVector3 target)
        {
            MyVector3 newForward = -(position - target);
            MyVector3 newRight = CrossProduct(new MyVector3(0, 1, 0), newForward);
            MyVector3 newUp = CrossProduct(newForward, newRight);
            return new MyMatrix4x4(
                new MyVector4(newRight.x, newRight.y, newRight.z,0),
                new MyVector4(newUp.x, newUp.y, newUp.z,0),
                new MyVector4(newForward.x, newForward.y, newForward.z,0),
                new MyVector4(0,0,0,1));
        }
        public static MyVector3 CrossProduct(MyVector3 lhs, MyVector3 rhs, bool normalised = false)
        {
            MyVector3 rv = new MyVector3();

            if (normalised)
            {
                lhs = lhs.Normalise();
                rhs = rhs.Normalise();
            }

            rv.x = lhs.y * rhs.z - lhs.z * rhs.y;
            rv.y = lhs.z * rhs.x - lhs.x * rhs.z;
            rv.z = lhs.x * rhs.y - lhs.y * rhs.x;
            return rv;
        }
        public static MyVector3 Lerp(MyVector3 lhs, MyVector3 rhs, float ratio)
        {
            MyVector3 rv = new MyVector3();

            rv = (lhs * (1 - ratio)) + (rhs * ratio);

            return rv;
        }
        public static MyVector3 RotateVertexAroundAxis(float angle, MyVector3 axis, MyVector3 vertex)
        {
            MyVector3 rv = (vertex * Mathf.Cos(angle)) + 
            axis * DotProduct(vertex, axis) * (1 - Mathf.Cos(angle)) + 
            CrossProduct(axis, vertex) * Mathf.Sin(angle);

            return rv;
        }
        public MyQuaternion ToQuaternion(bool convertToRadians = false)
        {
            MyQuaternion rv = new MyQuaternion();

            if (convertToRadians)
            {
                x /= RADIANS;
                y /= RADIANS;
                z /= RADIANS;
            }

            float cx, cy, cz, sx, sy, sz;

            sx = Mathf.Sin(x / 2);
            sy = Mathf.Sin(y / 2);
            sz = Mathf.Sin(z / 2);
            cx = Mathf.Cos(x / 2);
            cy = Mathf.Cos(y / 2);
            cz = Mathf.Cos(z / 2);

            rv.x = cz * sx * cy + sz * cx * sy; 
            rv.y = cz * cx * sy - sz * sx * cy;
            rv.z = sz * cx * cy - cz * sx * sy;
            rv.w = cz * cx * cy + sz * sx * sy;

            return rv;
        }
        public MyMatrix4x4 ToRotationMatrix(bool convertToRadians = false)
        {
            if (convertToRadians)
            {
                x /= RADIANS;
                y /= RADIANS;
                z /= RADIANS;
            }

            return MyMatrix4x4.RotationMatrix(x, y, z);
        }

        // Events
        public bool EpsilonFixer()
        {
            bool isDirty = false;
            if (x < 0.000001)
            { 
                x = 0.0f;
                isDirty = true;
            }
            if (y < 0.000001)
            {
                y = 0.0f;
                isDirty = true;
            }
            if (z < 0.000001)
            {
                z = 0.0f;
                isDirty = true;
            }
            return isDirty;
        }
        public bool AngleClamp()
        {
            bool isDirty = false;
            if (x < 0.0f)
            {
                x += 360.0f;
                isDirty = true;
            }
            if (y < 0.0f)
            {
                y += 360.0f;
                isDirty = true;
            }
            if (z < 0.0f)
            {
                z += 360.0f;
                isDirty = true;
            }
            if (x > 360.0f)
            {
                x -= 360.0f;
                isDirty = true;
            }
            if (y > 360.0f)
            {
                y -= 360.0f;
                isDirty = true;
            }
            if (z > 360.0f)
            {
                z -= 360.0f;
                isDirty = true;
            }
            return isDirty;
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
        public MyVector3(MyVector2 vecIn)
        {
            x = vecIn.x;
            y = vecIn.y;
            z = 0.0f;
        }
        public MyVector3(MyVector4 vecIn)
        {
            x = vecIn.x;
            y = vecIn.y;
            z = vecIn.z;
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