using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
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

