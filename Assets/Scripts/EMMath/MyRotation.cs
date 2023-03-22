using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyRotation
    {
        public MyVector3 angle;
        [HideInInspector]
        public MyVector3 euler;
        [HideInInspector]
        public MyMatrix4x4 matrix;
        [HideInInspector]
        public MyQuaternion quaternion;

        public void UpdateFromAngle()
        {
            euler = angle / MyVector3.RADIANS;
            matrix = MyMatrix4x4.RotationMatrix(euler.x, euler.y, euler.z);
            quaternion = euler.ToQuaternion();
        }

        public void UpdatefromEuler()
        {
            angle = euler * MyVector3.RADIANS;
            matrix = MyMatrix4x4.RotationMatrix(euler.x, euler.y, euler.z);
            quaternion = euler.ToQuaternion();
        }

        public void UpdatefromMatrix()
        {
            euler = matrix.ToEuler();
            angle = euler * MyVector3.RADIANS;
            quaternion = matrix.ToQuat();
        }

        public void SetAngle(MyVector3 eulerIn)
        {
            angle = eulerIn * MyVector3.RADIANS;
            UpdateFromAngle();
        }

        public MyRotation()
        {
            angle = new MyVector3(0, 0, 0);
            UpdateFromAngle();
        }
        public MyRotation(MyVector3 vecIn)
        {
            angle = new MyVector3(vecIn.x, vecIn.y, vecIn.z);
            UpdateFromAngle();
        }
    }
}
