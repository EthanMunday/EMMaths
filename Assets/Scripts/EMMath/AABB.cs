using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyAABB3
    {
        public MyVector3 minExtent;
        public MyVector3 maxExtent;
        
        public float Top
        {
            get { return maxExtent.y; }
        }
        public float Bottom
        {
            get { return minExtent.y; }
        }
        public float Right
        {
            get { return maxExtent.x; }
        }
        public float Left
        {
            get { return minExtent.x; }
        }
        public float Front
        {
            get { return maxExtent.z; }
        }
        public float Back
        {
            get { return maxExtent.z; }
        }

        public static bool IsIntersecting(MyAABB3 b1, MyAABB3 b2)
        {
            return !(b2.Left > b1.Right
                || b2.Right < b1.Left
                || b2.Top < b1.Bottom
                || b2.Bottom > b1.Top
                || b2.Back > b1.Front
                || b2.Front < b1.Back);
        }

        MyAABB3(MyVector3 min, MyVector3 max)
        {
            minExtent = min;
            maxExtent = max;
        }

    }
}
