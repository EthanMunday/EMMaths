using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MySphereCollision : MonoBehaviour
    {
        public MyVector3 centre;
        public float radius;

        private void Start()
        {
            MyTransform transform = GetComponent<MyTransform>();
            if (transform != null) centre = transform.position;
        }

        public bool IsColiding(MySphereCollision otherSphere)
        {
            MyVector3 midCentre = otherSphere.centre - centre;
            float midRadiusSq = otherSphere.radius + radius;
            midRadiusSq *= midRadiusSq;
            return midCentre.LengthSq() <= midRadiusSq;
        }

        public List<GameObject> CheckCollisions()
        {
            List<GameObject> colliders = new List<GameObject>();

            MySphereCollision[] otherSpheres = FindObjectsOfType<MySphereCollision>();
            Debug.Log(otherSpheres);

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
