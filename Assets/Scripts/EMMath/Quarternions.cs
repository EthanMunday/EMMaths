using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    [System.Serializable]
    public class MyQuaternion
    {
        public float w, x, y, z;

        public static MyQuaternion operator * (MyQuaternion lhs, MyQuaternion rhs)
        {
            MyVector3 lhsAxis = lhs.GetAxis();
            MyVector3 rhsAxis = rhs.GetAxis();
            MyQuaternion rv = new MyQuaternion();
            rv.w = (rhs.w * lhs.w) - MyVector3.DotProduct(rhsAxis, lhsAxis);
            rv.SetAxis((rhsAxis * lhs.w) + (lhsAxis * rhs.w) + MyVector3.CrossProduct(lhsAxis, rhsAxis));
            return rv;
        }
        
        public void SetAxis(MyVector3 axis)
        {
            x = axis.x;
            y = axis.y;
            z = axis.z;
        }
        public void NormaliseAxis()
        {
            SetAxis(GetAxis().Normalise());
        }
        public MyVector3 GetAxis()
        {
            return new MyVector3(x, y, z);
        }
        public MyVector4 GetAxisAngle()
        {
            MyVector4 rv = new MyVector4();

            float halfAngle = Mathf.Acos(w);
            rv.w = halfAngle * 2;
            rv.x = x / Mathf.Sin(halfAngle);
            rv.y = y / Mathf.Sin(halfAngle);
            rv.z = z / Mathf.Sin(halfAngle);


            return rv;
        }
        public MyQuaternion Inverse()
        {
            MyQuaternion rv = new MyQuaternion();

            rv.w = w;
            rv.SetAxis(-GetAxis());

            return rv;
        }
        public static MyVector3 RotateVector(MyQuaternion quat, MyVector3 vector)
        {
            MyQuaternion rv = new MyQuaternion();

            //quat.NormaliseAxis();

            MyQuaternion vQuart = new MyQuaternion(vector);

            rv = quat * vQuart * quat.Inverse();

            return rv.GetAxis();
        }
        public static MyQuaternion Slerp(MyQuaternion a, MyQuaternion b, float t)
        {
            t = Mathf.Clamp(t, 0.0f, 1.0f);
            MyQuaternion midpoint = b * a.Inverse();
            MyVector4 axAngle = midpoint.GetAxisAngle();
            MyQuaternion fractional = new MyQuaternion(axAngle.w * t, new MyVector3(axAngle.x, axAngle.y, axAngle.z));
            return fractional * a;
        }
        public MyMatrix4x4 ToMatrix()
        {
            MyMatrix4x4 rv = new MyMatrix4x4();
            float wx, wy, wz, xx, yy, yz, xy, xz, zz, x2, y2, z2;

            x2 = x + x; y2 = y + y;
            z2 = z + z;
            xx = x * x2; xy = x * y2; xz = x * z2;
            yy = y * y2; yz = y * z2; zz = z * z2;
            wx = w * x2; wy = w * y2; wz = w * z2;
            rv.values[0,0] = 1.0f - (yy + zz); 
            rv.values[1,0] = xy - wz;
            rv.values[2,0] = xz + wy; 
            rv.values[3,0] = 0.0f;
            rv.values[0,1] = xy + wz; 
            rv.values[1,1] = 1.0f - (xx + zz);
            rv.values[2,1] = yz - wx; 
            rv.values[3,1] = 0.0f;
            rv.values[0,2] = xz - wy; 
            rv.values[1,2] = yz + wx;
            rv.values[2,2] = 1.0f - (xx + yy); 
            rv.values[3,2] = 0.0f;
            rv.values[0,3] = 0; 
            rv.values[1,3] = 0;
            rv.values[2,3] = 0; 
            rv.values[3,3] = 1;

            return rv;
        }
        public MyVector3 ToEuler()
        {
            MyVector3 rv = new MyVector3();

            double test = x * y + z * w;
            if (test > 0.499)
            {
                rv.y = 2 * Mathf.Atan2(y, w);
                rv.x = Mathf.PI / 2;
                rv.z = 0;
                return rv;
            }

            if (test < -0.499)
            {
                rv.y = -2 * Mathf.Atan2(y, w);
                rv.x = -Mathf.PI / 2;
                rv.z = 0;
                return rv;
            }

            float sinr_cosp = 2 * (w * y + x * z);
            float cosr_cosp = 1 - 2 * (x * y + x * x);
            rv.y = Mathf.Atan2(sinr_cosp, cosr_cosp);

            float sinp = Mathf.Sqrt(1 + 2 * (w * x - y * z));
            float cosp = Mathf.Sqrt(1 - 2 * (w * x - y * z));
            rv.x = 2 * Mathf.Atan2(sinp, cosp) - Mathf.PI / 2;

            float siny_cosp = 2 * (w * z + y * x);
            float cosy_cosp = 1 - 2 * (x * x + z * z);
            rv.z = Mathf.Atan2(siny_cosp, cosy_cosp);

            return rv;
        }

        public MyQuaternion(float angle, MyVector3 axis, bool normalised = false)
        {
            float halfAngle = angle / 2;
            if (normalised)
            {
                axis = axis.Normalise();
            }
            w = Mathf.Cos(halfAngle);
            x = axis.x * Mathf.Sin(halfAngle);
            y = axis.y * Mathf.Sin(halfAngle);
            z = axis.z * Mathf.Sin(halfAngle);
            
        }
        public MyQuaternion(MyVector3 axis)
        {
            w = 0.0f;
            x = axis.x;
            y = axis.y;
            z = axis.z;
        }
        public MyQuaternion()
        {
            w = 0.0f;
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
        }
    }
}

