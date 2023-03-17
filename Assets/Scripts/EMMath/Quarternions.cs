using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyQuarternion
    {
        public float w, x, y, z;

        public static MyQuarternion operator * (MyQuarternion lhs, MyQuarternion rhs)
        {
            MyVector3 lhsAxis = lhs.GetAxis();
            MyVector3 rhsAxis = rhs.GetAxis();
            MyQuarternion rv = new MyQuarternion();
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
        public MyQuarternion Inverse()
        {
            MyQuarternion rv = new MyQuarternion();

            rv.w = w;
            rv.SetAxis(-GetAxis());

            return rv;
        }
        public static MyVector3 RotateVector(MyQuarternion quat, MyVector3 vector)
        {
            MyQuarternion rv = new MyQuarternion();

            //quat.NormaliseAxis();

            MyQuarternion vQuart = new MyQuarternion(vector);

            rv = quat * vQuart * quat.Inverse();

            return rv.GetAxis();
        }

        
        public static MyQuarternion Slerp(MyQuarternion a, MyQuarternion b, float t)
        {
            t = Mathf.Clamp(t, 0.0f, 1.0f);
            MyQuarternion midpoint = b * a.Inverse();
            MyVector4 axAngle = midpoint.GetAxisAngle();
            MyQuarternion fractional = new MyQuarternion(axAngle.w * t, new MyVector3(axAngle.x, axAngle.y, axAngle.z));
            return fractional * a;
        }

        public MyQuarternion(float angle, MyVector3 axis, bool normalised = false)
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
        public MyQuarternion(MyVector3 axis)
        {
            w = 0.0f;
            x = axis.x;
            y = axis.y;
            z = axis.z;
        }
        public MyQuarternion()
        {
            w = 0.0f;
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
        }
    }
}

