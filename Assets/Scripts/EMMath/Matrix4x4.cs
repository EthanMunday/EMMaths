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
        public static MyMatrix4x4 operator +(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
        {
            MyMatrix4x4 rv = new MyMatrix4x4();

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    rv.values[x, y] = lhs.values[x, y] + rhs.values[x, y];
                }
            }

            return rv;
        }
        public static MyMatrix4x4 operator -(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
        {
            MyMatrix4x4 rv = new MyMatrix4x4();

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    rv.values[x, y] = lhs.values[x, y] - rhs.values[x, y];
                }
            }

            return rv;
        }
        public static MyMatrix4x4 operator *(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
        {
            MyMatrix4x4 rv = new MyMatrix4x4();

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    rv.values[x, y] = (lhs.GetColumn(y + 1) * rhs.GetRow(x + 1)).Sum();
                }
            }

            return rv;
        }
        public static MyVector4 operator *(MyMatrix4x4 lhs, MyVector4 rhs)
        {
            MyVector4 rv = new MyVector4();

            rv.x = (lhs.values[0, 0] * rhs.x) + (lhs.values[1, 0] * rhs.y) + (lhs.values[2, 0] * rhs.z) + (lhs.values[3, 0] * rhs.w);
            rv.y = (lhs.values[0, 1] * rhs.x) + (lhs.values[1, 1] * rhs.y) + (lhs.values[2, 1] * rhs.z) + (lhs.values[3, 1] * rhs.w);
            rv.z = (lhs.values[0, 2] * rhs.x) + (lhs.values[1, 2] * rhs.y) + (lhs.values[2, 2] * rhs.z) + (lhs.values[3, 2] * rhs.w);
            rv.w = (lhs.values[0, 3] * rhs.x) + (lhs.values[1, 3] * rhs.y) + (lhs.values[2, 3] * rhs.z) + (lhs.values[3, 3] * rhs.w);

            return rv;
        }
        public static MyVector3 operator *(MyMatrix4x4 lhs, MyVector3 rhs)
        {
            MyVector3 rv = new MyVector3();

            rv.x = (lhs.values[0, 0] * rhs.x) + (lhs.values[1, 0] * rhs.y) + (lhs.values[2, 0] * rhs.z) + (lhs.values[3, 0] * 1);
            rv.y = (lhs.values[0, 1] * rhs.x) + (lhs.values[1, 1] * rhs.y) + (lhs.values[2, 1] * rhs.z) + (lhs.values[3, 1] * 1);
            rv.z = (lhs.values[0, 2] * rhs.x) + (lhs.values[1, 2] * rhs.y) + (lhs.values[2, 2] * rhs.z) + (lhs.values[3, 2] * 1);

            return rv;
        }

        // Conversion
        public MyVector4 GetColumn(int x)
        {
            MyVector4 rv = new MyVector4();

            if (x < 5 && x > 0)
            {
                rv.x = values[0, x - 1];
                rv.y = values[1, x - 1];
                rv.z = values[2, x - 1];
                rv.w = values[3, x - 1];
            }

            return rv;
        }
        public MyVector4 GetRow(int x)
        {
            MyVector4 rv = new MyVector4();

            if (x < 5 && x > 0)
            {
                rv.x = values[x - 1, 0];
                rv.y = values[x - 1, 1];
                rv.z = values[x - 1, 2];
                rv.w = values[x - 1, 3];
            }

            return rv;
        }

        // Identifiers
        public MyMatrix4x4 Identity
        {
            get
            {
                return new MyMatrix4x4(
                new MyVector4(1, 0, 0, 0),
                new MyVector4(0, 1, 0, 0),
                new MyVector4(0, 0, 1, 0),
                new MyVector4(0, 0, 0, 1));
            }
        }
        public MyMatrix4x4 TranslationMatrix()
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, 1, 0),
            new MyVector3(0, 0, 1),
            new MyVector3(values[0, 3], values[1, 3], values[2, 3]));
            return rv;
        }
        public static MyMatrix4x4 TranslationMatrix(float x, float y, float z)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, 1, 0),
            new MyVector3(0, 0, 1),
            new MyVector3(x, y, z));
            return rv;
        }
        public MyMatrix4x4 InvTranslationMatrix()
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, 1, 0),
            new MyVector3(0, 0, 1),
            new MyVector3(-values[0,3], -values[1,3], -values[2,3]));
            return rv;
        }
        public static MyMatrix4x4 InvTranslationMatrix(float x, float y, float z)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, 1, 0),
            new MyVector3(0, 0, 1),
            new MyVector3(-x, -y, -z));
            return rv;
        }
        public static MyMatrix4x4 PitchMatrix(float x)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(1, 0, 0),
            new MyVector3(0, Mathf.Cos(x), Mathf.Sin(x)),
            new MyVector3(0, -Mathf.Sin(x), Mathf.Cos(x)),
            new MyVector3(0, 0, 0));
            return rv;
        }
        public static MyMatrix4x4 YawMatrix(float x)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(Mathf.Cos(x), 0, -Mathf.Sin(x)),
            new MyVector3(0, 1, 0),
            new MyVector3(Mathf.Sin(x), 0, Mathf.Cos(x)),
            new MyVector3(0, 0, 0));
            return rv;
        }
        public static MyMatrix4x4 RollMatrix(float x)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(Mathf.Cos(x), Mathf.Sin(x), 0),
            new MyVector3(-Mathf.Sin(x), Mathf.Cos(x), 0),
            new MyVector3(0, 0, 1),
            new MyVector3(0, 0, 0));
            return rv;
        }
        public static MyMatrix4x4 RotationMatrix(float pitch, float yaw, float roll)
        {
            MyMatrix4x4 rv = YawMatrix(yaw) * PitchMatrix(pitch) * RollMatrix(roll);
            return rv;
        }
        public MyMatrix4x4 InvRotationMatrix()
        {
            MyMatrix4x4 rv = new MyMatrix4x4(GetColumn(1), GetColumn(2), GetColumn(3), GetColumn(4));
            return rv;
        }
        public static MyMatrix4x4 InvRotationMatrix(MyMatrix4x4 rotMatrix)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(rotMatrix.GetColumn(1), rotMatrix.GetColumn(2), rotMatrix.GetColumn(3), rotMatrix.GetColumn(4));
            return rv;
        }
        public static MyMatrix4x4 ScaleMatrix(float x, float y, float z)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(x ,0, 0),
            new MyVector3(0, y, 0),
            new MyVector3(0, 0, z),
            new MyVector3(0, 0, 0));
            return rv;
        }
        public MyMatrix4x4 InvScaleMatrix()
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(1 / values[0,0], 0, 0),
            new MyVector3(0, 1 / values[1,1], 0),
            new MyVector3(0, 0, 1 / values[2,2]),
            new MyVector3(0, 0, 0));
            return rv;
        }
        public static MyMatrix4x4 InvScaleMatrix(float x, float y, float z)
        {
            MyMatrix4x4 rv = new MyMatrix4x4(
            new MyVector3(1/x, 0, 0),
            new MyVector3(0, 1/y, 0),
            new MyVector3(0, 0, 1/z),
            new MyVector3(0, 0, 0));
            return rv;
        }
        public static MyMatrix4x4 TransformMatrix(MyVector3 t, MyVector3 r, MyVector3 s)
        {
            MyMatrix4x4 rv = TranslationMatrix(t.x, t.y, t.z) * RotationMatrix(r.x, r.y, r.z) * ScaleMatrix(s.x, s.y, s.z);
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
        public MyMatrix4x4()
        {
            values = new float[4, 4];
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    values[x, y] = 0.0f;
                }
            }
        }
    }
}