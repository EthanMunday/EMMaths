using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyTransform : MonoBehaviour
    {
        // Members
        public MyVector3 position;
        public MyRotation rotation;
        public MyVector3 scale;

        private MeshFilter mf;
        private MeshRenderer mr;
        private MyVector3[] vertices;
        private Vector3[] newVertices;
        private MyVector3 forward;
        private MyVector3 up;
        private MyVector3 right;
        
        // Behaviours
        void Start()
        {
            mf = gameObject.GetComponent<MeshFilter>();
            forward = new MyVector3(transform.forward);
            right = MyVector3.CrossProduct(new MyVector3(0, 1, 0), forward);
            up = MyVector3.CrossProduct(forward, right);
            vertices = new MyVector3[mf.mesh.vertexCount];
            newVertices = new Vector3[vertices.Length];
            for (int x = 0; x < mf.mesh.vertices.Length; x++)
            {
                vertices[x] = new MyVector3(mf.mesh.vertices[x]);
            }
        }
        void Update()
        {
            for (int x = 0; x < vertices.Length; x++)
            {
                newVertices[x] = (MyMatrix4x4.TransformMatrix(position, rotation.euler, scale) * vertices[x]).UnityVector();
            }
            mf.mesh.vertices = newVertices;
            mf.mesh.RecalculateNormals();
            mf.mesh.RecalculateBounds();
        }

        // Transformers
        public void Move(float x, float y, float z)
        {
            position += new MyVector3(x, y, z);
            position.EpsilonFixer();
        }
        public void Move(Vector3 x)
        {
            position += new MyVector3(x);
            position.EpsilonFixer();

        }
        public void Move(MyVector3 x)
        {
            position += x;
            position.EpsilonFixer();
        }

        public void Rotate(float x, float y, float z)
        {
            rotation.matrix += new MyVector3(x, y, z).ToRotationMatrix();
        }
        public void Rotate(Vector3 x)
        {
            rotation.matrix += new MyVector3(x).ToRotationMatrix();
        }
        public void Rotate(MyVector3 x)
        {
            rotation.matrix += x.ToRotationMatrix();
        }

        public void Scale(float x, float y, float z)
        {
            position += new MyVector3(x, y, z);
        }
        public void Scale(Vector3 x)
        {
            position += new MyVector3(x);
        }
        public void Scale(MyVector3 x)
        {
            position += x;
        }

        public MyTransform()
        {
            position = new MyVector3(0, 0, 0);
            rotation = new MyRotation();
            scale = new MyVector3(1, 1, 1);
        }
    }
}