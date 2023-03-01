using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMMath
{
    public class MyTransform : MonoBehaviour
    {
        public MeshFilter mf;
        public MyVector3[] vertices;
        public MyVector3 forward;
        public MyVector3 up;
        public MyVector3 right;
        public MyVector3 position;
        public MyVector3 oldPosition;
        public MyVector3 rotation;
        public MyVector3 oldRotation;
        public MyVector3 scale;
        public MyVector3 oldScale;
        // Start is called before the first frame update
        void Start()
        {
            mf = gameObject.GetComponent<MeshFilter>();
            forward = new MyVector3(transform.forward);
            right = MyVector3.CrossProduct(new MyVector3(0, 1, 0), forward);
            up = MyVector3.CrossProduct(forward, right);
            position = new MyVector3(transform.position);
            rotation = new MyVector3(transform.rotation.eulerAngles);
            scale = new MyVector3(transform.lossyScale);
            vertices = new MyVector3[mf.mesh.vertexCount];
            for (int x = 0; x < mf.mesh.vertices.Length; x++)
            {
                vertices[x] = new MyVector3(mf.mesh.vertices[x]);
            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3[] newVertices = new Vector3[vertices.Length];
            for (int x = 0; x < vertices.Length; x++)
            {
                newVertices[x] = (MyMatrix4x4.TransformMatrix(position, rotation, scale) * vertices[x]).UnityVector();
            }
            Debug.Log(position.x + " " + position.y + " " + position.z);
            mf.mesh.vertices = newVertices;
            mf.mesh.RecalculateNormals();
            mf.mesh.RecalculateBounds();
        }
    }
}