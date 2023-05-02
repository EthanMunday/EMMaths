using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MySphereCollision : MonoBehaviour
    {
        [HideInInspector] public MyVector3 centre;
        [HideInInspector] public float radius;

        private void Start()
        {
            MyTransform myTransform = GetComponent<MyTransform>();
            if (myTransform != null) centre = myTransform.position;
            else centre = new MyVector3(transform.position);
        }
        public bool IsColiding(MyVector3 otherCentre, float otherRadius)
        {
            MyVector3 midCentre = otherCentre - centre;
            float midRadiusSq = otherRadius + radius;
            midRadiusSq *= midRadiusSq;
            return midCentre.LengthSq() <= midRadiusSq;
        }

        public bool IsColiding(MySphereCollision otherSphere)
        {
            return IsColiding(otherSphere.centre, otherSphere.radius);
        }

        public bool IsColiding(Ray rayIn, MyVector3 otherPosition)
        {
            MyVector3 rayVector = new MyVector3(rayIn);
            MyVector3 positionVector = this.centre - otherPosition;
            MyVector3 projectionVector = MyVector3.DotProduct(positionVector, rayVector) / rayVector.Length() * rayVector.Normalise();
            projectionVector += otherPosition;
            return IsColiding(projectionVector, 0.3f);
        }

        public List<GameObject> CheckCollisions()
        {
            List<GameObject> colliders = new List<GameObject>();

            MySphereCollision[] otherSpheres = FindObjectsOfType<MySphereCollision>();

            foreach (MySphereCollision x in otherSpheres)
            {
                if (x != this && IsColiding(x))
                {
                    colliders.Add(x.gameObject);
                }
            }

            return colliders;
        }
    }
}
