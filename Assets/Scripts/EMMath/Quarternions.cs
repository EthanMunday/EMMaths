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
            MyVector3 lhsAxis = new MyVector3(lhs.x, lhs.y, lhs.z);
            MyVector3 rhsAxis = new MyVector3(rhs.x, rhs.y, rhs.z);
            MyQuarternion rv = new MyQuarternion(rhs.w * lhs.w - MyVector3.DotProduct(rhsAxis,lhsAxis),
            lhsAxis * rhs.w + MyVector3.CrossProduct(lhsAxis,rhsAxis));

            return rv;
        }
        public MyQuarternion Inverse()
        {
            MyQuarternion rv = new MyQuarternion();

            rv.w = w;
            rv.x = -x;
            rv.y = -y;
            rv.z = -z;

            return rv;
        }

        public MyQuarternion(float angle, MyVector3 axis)
        {
            float halfAngle = angle / 2;
            w = Mathf.Cos(halfAngle);
            x = axis.x * Mathf.Sin(halfAngle);
            y = axis.y * Mathf.Sin(halfAngle);
            z = axis.z * Mathf.Sin(halfAngle);
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

